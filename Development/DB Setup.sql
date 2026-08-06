USE master;
GO

IF (DB_ID('FurrosDB') IS NOT NULL)
BEGIN
    ALTER DATABASE FurrosDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

    DROP DATABASE FurrosDB;
END
GO

CREATE DATABASE FurrosDB;
GO

USE FurrosDB;
GO

-- que hace lo de arriba? basicamente:
-- USE MASTER es para que deje de usar FurrosDB, asi cuando la vaya a borrar, se pueda ya que la "dejas de usar"
-- Ese IF, se fija si existe la DB, y si existe, le pone ese "alter" para que solo deje que un solo usuario la use, y luego los desconecte a todos, para luego hacerle DROP
-- Luego basicamente la crea, y la usa
-- todo esto, para que cara que se le da a "ejecutar", la DB se cree de cero y asi poder ir cambiando cosas dinamicamente

-------------------- DIRECCIONES PATH ------------------------------------------------------------

CREATE TABLE Provincia(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(64) NOT NULL,
)

CREATE TABLE Ciudad(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Provincia INT NOT NULL, CONSTRAINT FK_Ciudad_Provincia FOREIGN KEY (Provincia) REFERENCES Provincia(ID),
    Nombre NVARCHAR(128) NOT NULL,
)

CREATE TABLE Direccion(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Ciudad INT NOT NULL, CONSTRAINT FK_Direccion_Ciudad FOREIGN KEY (Ciudad) REFERENCES Ciudad(ID),
    Calle NVARCHAR(128),
    Altura INT,
    PlantaDepartamento VARCHAR(16),
)

CREATE TABLE Persona(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombres NVARCHAR(128) NOT NULL,
    Apellidos NVARCHAR(128) NOT NULL,
    DNI INT UNIQUE NOT NULL,
    Telefono VARCHAR(30) UNIQUE,
    Direccion INT, CONSTRAINT FK_Persona_Direccion FOREIGN KEY (Direccion) REFERENCES Direccion(ID),
    Imagen_URL NVARCHAR(1024),
    Legajo INT UNIQUE NOT NULL,
    Activo BIT,
)

CREATE TABLE Usuario(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Persona INT, CONSTRAINT FK_Usuario_Persona FOREIGN KEY (Persona) REFERENCES Persona(ID),
    IntentosFallidos INT,
    HoraUltimoIntento DATETIME,
    Username VARCHAR(64) UNIQUE NOT NULL,
    Email NVARCHAR(256) UNIQUE NOT NULL,
    Activo BIT,
)


CREATE TABLE PasswordState(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Usuario INT, CONSTRAINT FK_PasswordState_Usuario FOREIGN KEY (Usuario) REFERENCES Usuario(ID),
    FechaCambio DATETIME NOT NULL,
    PasswordHash BINARY(32) UNIQUE NOT NULL,
)

-------------------- ROLES PATH ------------------------------------------------------------

CREATE TABLE Permiso(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(MAX),
)

CREATE TABLE Rol(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Rango DECIMAL(5, 2) NOT NULL,
    Descripcion VARCHAR(MAX),
)

CREATE TABLE INTER_Rol_Permiso(
    ID_Rol INT,
    ID_Permiso INT,
    PRIMARY KEY (ID_Rol, ID_Permiso),
    CONSTRAINT FK_Perm_Rol FOREIGN KEY (ID_Rol) REFERENCES Rol(ID),
    CONSTRAINT FK_Rol_Perm FOREIGN KEY (ID_Permiso) REFERENCES Permiso(ID),
)

CREATE TABLE TempRol(
    Usuario INT,
    Rol INT,
    PRIMARY KEY(Usuario, Rol),
    CONSTRAINT FK_TempRol_Usuario FOREIGN KEY (Usuario) REFERENCES Usuario(ID), 
    CONSTRAINT FK_TempRol_Rol FOREIGN KEY (Rol) REFERENCES Rol(ID),
    FechaExpir DATETIME,
    Descripcion VARCHAR(MAX),
)


-------------------- RESPUESTAS PATH ------------------------------------------------------------

CREATE TABLE Pregunta(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Texto VARCHAR(MAX) NOT NULL,
)

CREATE TABLE Respuesta(
    Pregunta INT,
    Usuario INT,
    PRIMARY KEY (Pregunta, Usuario),
    CONSTRAINT FK_Respuesta_Pregunta FOREIGN KEY (Pregunta) REFERENCES Pregunta(ID),
    CONSTRAINT FK_Respuesta_Usuario FOREIGN KEY (Usuario) REFERENCES Usuario(ID),
    Texto VARCHAR(512) NOT NULL,
)

--------------------------------------------------------------------------------------------
GO
--------------------------------------------------------------------------------------------
-------------------- PROCEDURES ------------------------------------------------------------
--------------------------------------------------------------------------------------------


CREATE PROCEDURE GetUserIDByInput(@Input VARCHAR(64), @ID INT OUTPUT) AS BEGIN SET NOCOUNT ON;
    SELECT @ID = ID FROM Usuario WHERE (@Input = Email or @Input = Username) AND Activo = 1;
END;
GO

CREATE PROCEDURE GetUserData (@ID INT, @AllowInactives BIT) AS BEGIN SET NOCOUNT ON;
    SELECT * FROM Usuario WHERE ID = @ID AND (@AllowInactives = 1 OR Activo = 1);
END;
GO

CREATE PROCEDURE GetPersonaData (@ID INT, @AllowInactives BIT) AS BEGIN SET NOCOUNT ON;
    SELECT * FROM Persona WHERE ID = @ID AND (@AllowInactives = 1 OR Activo = 1);
END;
GO


CREATE PROCEDURE ComprobeUserCredentials (@Input VARCHAR(256), @Hash BINARY(32), @ReturnID INT OUTPUT) AS BEGIN SET NOCOUNT ON;
	DECLARE @UserID INT = (SELECT ID FROM Usuario WHERE (@Input = Email or @Input = Username) AND Activo = 1);
    -- Este if basicamente primero comprueba que USERID exista, luego obtiene el primer resultado (con el TOP(1) de ahi) de PasswordHash, 
    -- donde el usuario coincida y al estar ordenado por fecha, descendientemente, naturalmente la fecha mas alta y nueva está primero 
    -- (por eso funciona TOP) luego al final, compara el hash mas nuevo del usuario, con el hash ingresado, y si es el mismo ahi returnea la UserID
	IF @Userid IS NOT NULL AND 
    (
		SELECT TOP(1) PasswordHash 
		FROM PasswordState 
		WHERE @UserID = Usuario
		ORDER BY FechaCambio DESC
	) = @Hash
	BEGIN
		SET @ReturnID = @UserID
	END ELSE BEGIN
		SET @ReturnID = -1;
	END
END;
GO

CREATE PROCEDURE RegisterDireccion(@Ciudad INT, @Calle NVARCHAR(128), @Altura INT, @PD VARCHAR(16), @DireccionID INT OUTPUT) AS BEGIN SET NOCOUNT ON;
    IF (@Ciudad IS NULL) BEGIN RETURN 1; END -- check no null obligatory parameter
    SELECT @DireccionID = ID FROM Direccion WHERE Ciudad = @Ciudad 
      AND (Calle = @Calle OR (Calle IS NULL AND @Calle IS NULL))
      AND (Altura = @Altura OR (Altura IS NULL AND @Altura IS NULL))
      AND (PlantaDepartamento = @PD OR (PlantaDepartamento IS NULL AND @PD IS NULL));

    IF @DireccionID IS NULL BEGIN
         INSERT INTO Direccion (Ciudad, Calle, Altura, PlantaDepartamento) VALUES(@Ciudad, @Calle, @Altura, @PD)
         SET @DireccionID = SCOPE_IDENTITY();
    END
END;
GO

CREATE PROCEDURE RegisterPersona (
    @Nombres NVARCHAR(128), 
    @Apellidos NVARCHAR(128),
    @DNI INT,
    @Telefono VARCHAR(30),
    @Img NVARCHAR(1024),
    @Legajo INT,
    
    @Ciudad INT, @Calle NVARCHAR(128), @Altura INT, @PD VARCHAR(16),

    @PersonaID INT OUTPUT
) AS BEGIN SET NOCOUNT ON;
    IF NOT EXISTS (SELECT ID FROM Persona WHERE (DNI = @DNI OR Legajo = @Legajo)) BEGIN
        DECLARE @DirID INT; EXEC RegisterDireccion @Ciudad, @Calle, @Altura, @PD, @DirID;
        INSERT INTO Persona (Nombres, Apellidos, DNI, Telefono, Direccion, Imagen_URL, Legajo)
        VALUES (@Nombres, @Apellidos, @DNI, @Telefono, @DirID, @Img, @Legajo);
        SET @PersonaID = SCOPE_IDENTITY();
    END
END;
GO

CREATE PROCEDURE AddPasswordState (
    @Usuario INT,
    @PasswordHash BINARY(32),
    @HashID INT = -1 OUTPUT
) AS BEGIN SET NOCOUNT ON;
    INSERT INTO PasswordState (Usuario, FechaCambio, PasswordHash) VALUES (@Usuario, GETDATE(), @PasswordHash)
    SET @HashID = SCOPE_IDENTITY();
END;
GO

CREATE PROCEDURE AddTempRol (
    @Usuario INT,
    @Rol INT,
    @RolExpir DATETIME,
    @RolDesc VARCHAR(MAX)
) AS BEGIN SET NOCOUNT ON;
    IF NOT EXISTS (SELECT Rol FROM TempRol WHERE (Rol = @Rol AND FechaExpir = @RolExpir)) BEGIN
        INSERT INTO TempRol (Usuario, Rol, FechaExpir, Descripcion)
        VALUES (@Usuario, @Rol, @RolExpir, @RolDesc)
    END
END;
GO


CREATE PROCEDURE RegisterUsuario (
    @Username VARCHAR(64),
    @Email VARCHAR(64),
    @PasswordHash BINARY(32),
    @Rol INT,
    @RolExpir DATETIME,
    @RolDesc VARCHAR(MAX),

    @Nombres NVARCHAR(128), 
    @Apellidos NVARCHAR(128),
    @DNI INT,
    @Telefono VARCHAR(30),
    @Img NVARCHAR(1024),
    @Legajo INT,
    
    @Ciudad INT, @Calle NVARCHAR(128), @Altura INT, @PD VARCHAR(16),

    @UserID INT OUTPUT
) AS BEGIN SET NOCOUNT ON;
    IF NOT EXISTS (SELECT ID FROM Usuario WHERE (Username = @Username OR Email = @Email)) BEGIN
        DECLARE @PersID INT; EXEC RegisterPersona @Nombres, @Apellidos, @DNI, @Telefono, @Img, @Legajo, @Ciudad, @Calle, @Altura, @PD, @PersID;

        INSERT INTO Usuario(Username, Email, Persona, HoraUltimoIntento, IntentosFallidos)
        VALUES (@Username, @Email, @PersID, GETDATE(), 0);
        SET @UserID = SCOPE_IDENTITY();

        EXEC AddPasswordState @UserID, @PasswordHash;
        EXEC AddTempRol @UserID, @Rol, @RolExpir, @RolDesc;
    END
END;
GO

CREATE PROCEDURE RegisterUsuarioByDNI (
    @Username VARCHAR(64),
    @Email VARCHAR(64),
    @PasswordHash BINARY(32),
    @Rol INT,
    @RolExpir DATETIME,
    @RolDesc VARCHAR(MAX),
    @DNI INT,

    @UserID INT OUTPUT
) AS BEGIN SET NOCOUNT ON;
    IF NOT EXISTS (SELECT ID FROM Usuario WHERE (Username = @Username OR Email = @Email)) BEGIN
        DECLARE @persID INT = (SELECT ID FROM Persona WHERE DNI = @DNI)
        IF (@persID IS NOT NULL) BEGIN
            INSERT INTO Usuario(Username, Email, Persona, HoraUltimoIntento, IntentosFallidos)
            VALUES (@Username, @Email, @PersID, GETDATE(), 0);
            SET @UserID = SCOPE_IDENTITY();

            EXEC AddPasswordState @UserID, @PasswordHash;
        END
    END
END;
GO