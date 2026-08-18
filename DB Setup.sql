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
INSERT INTO Provincia(Nombre) VALUES ('Buenos Aires')
INSERT INTO Provincia(Nombre) VALUES ('Santa Fe')
INSERT INTO Provincia(Nombre) VALUES ('Mendoza')
INSERT INTO Provincia(Nombre) VALUES ('Misiones')
INSERT INTO Provincia(Nombre) VALUES ('Corrientes')
INSERT INTO Provincia(Nombre) VALUES ('Cordoba')
INSERT INTO Provincia(Nombre) VALUES ('Entre Rios')
INSERT INTO Provincia(Nombre) VALUES ('Formosa')
INSERT INTO Provincia(Nombre) VALUES ('Salta')
INSERT INTO Provincia(Nombre) VALUES ('Jujuy')
INSERT INTO Provincia(Nombre) VALUES ('Catamarca')
INSERT INTO Provincia(Nombre) VALUES ('La Rioja')
INSERT INTO Provincia(Nombre) VALUES ('Rio Negro')
INSERT INTO Provincia(Nombre) VALUES ('Neuquen')
INSERT INTO Provincia(Nombre) VALUES ('San Juan')
INSERT INTO Provincia(Nombre) VALUES ('San Luis')
INSERT INTO Provincia(Nombre) VALUES ('Santa Cruz')
INSERT INTO Provincia(Nombre) VALUES ('Chubut')
INSERT INTO Provincia(Nombre) VALUES ('Chaco')
INSERT INTO Provincia(Nombre) VALUES ('Tucuman')
INSERT INTO Provincia(Nombre) VALUES ('Santiago del Estero')
INSERT INTO Provincia(Nombre) VALUES ('La Pampa')
INSERT INTO Provincia(Nombre) VALUES ('Tierra del Fuego')

CREATE TABLE Ciudad(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Provincia INT NOT NULL, CONSTRAINT FK_Ciudad_Provincia FOREIGN KEY (Provincia) REFERENCES Provincia(ID),
    Nombre NVARCHAR(128) NOT NULL,
)

-- 1. Buenos Aires (ID: 1) - Más de 5 ciudades
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'La Plata');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Mar del Plata');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Bahía Blanca');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Tandil');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'San Nicolás de los Arroyos');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Junín');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Olavarría');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Pergamino');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Necochea');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Campana');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Zárate');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Chivilcoy');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Azul');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Tres Arroyos');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (1, 'Luján');

-- 2. Santa Fe (ID: 2)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (2, 'Santa Fe de la Vera Cruz');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (2, 'Rosario');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (2, 'Rafaela');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (2, 'Venado Tuerto');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (2, 'Reconquista');

-- 3. Mendoza (ID: 3)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (3, 'Mendoza');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (3, 'San Rafael');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (3, 'Godoy Cruz');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (3, 'San Martín');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (3, 'Tunuyán');

-- 4. Misiones (ID: 4)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (4, 'Posadas');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (4, 'Oberá');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (4, 'Eldorado');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (4, 'Puerto Iguazú');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (4, 'Apóstoles');

-- 5. Corrientes (ID: 5)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (5, 'Corrientes');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (5, 'Goya');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (5, 'Paso de los Libres');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (5, 'Curuzú Cuatiá');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (5, 'Mercedes');

-- 6. Córdoba (ID: 6)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (6, 'Córdoba');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (6, 'Río Cuarto');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (6, 'Villa María');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (6, 'Carlos Paz');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (6, 'San Francisco');

-- 7. Entre Ríos (ID: 7)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (7, 'Paraná');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (7, 'Concordia');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (7, 'Gualeguaychú');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (7, 'Concepción del Uruguay');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (7, 'Gualeguay');

-- 8. Formosa (ID: 8)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (8, 'Formosa');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (8, 'Clorinda');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (8, 'Pirané');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (8, 'El Colorado');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (8, 'Las Lomitas');

-- 9. Salta (ID: 9)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (9, 'Salta');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (9, 'San Ramón de la Nueva Orán');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (9, 'Tartagal');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (9, 'Cafayate');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (9, 'General Güemes');

-- 10. Jujuy (ID: 10)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (10, 'San Salvador de Jujuy');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (10, 'San Pedro de Jujuy');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (10, 'Palpalá');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (10, 'Libertador General San Martín');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (10, 'La Quiaca');

-- 11. Catamarca (ID: 11)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (11, 'San Fernando del Valle de Catamarca');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (11, 'Andalgalá');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (11, 'Tinogasta');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (11, 'Belén');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (11, 'Santa María');

-- 12. La Rioja (ID: 12)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (12, 'La Rioja');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (12, 'Chilecito');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (12, 'Aimogasta');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (12, 'Chamical');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (12, 'Chepes');

-- 13. Río Negro (ID: 13)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (13, 'Viedma');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (13, 'San Carlos de Bariloche');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (13, 'General Roca');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (13, 'Cipolletti');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (13, 'San Antonio Oeste');

-- 14. Neuquén (ID: 14)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (14, 'Neuquén');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (14, 'San Martín de los Andes');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (14, 'Cutral Có');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (14, 'Zapala');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (14, 'Plottier');

-- 15. San Juan (ID: 15)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (15, 'San Juan');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (15, 'Caucete');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (15, 'San José de Jáchal');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (15, 'Rivadavia');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (15, 'Santa Lucía');

-- 16. San Luis (ID: 16)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (16, 'San Luis');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (16, 'Villa Mercedes');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (16, 'Merlo');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (16, 'Juana Koslay');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (16, 'La Toma');

-- 17. Santa Cruz (ID: 17)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (17, 'Río Gallegos');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (17, 'Caleta Olivia');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (17, 'El Calafate');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (17, 'Puerto Deseado');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (17, 'Las Heras');

-- 18. Chubut (ID: 18)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (18, 'Rawson');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (18, 'Comodoro Rivadavia');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (18, 'Trelew');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (18, 'Puerto Madryn');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (18, 'Esquel');

-- 19. Chaco (ID: 19)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (19, 'Resistencia');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (19, 'Presidencia Roque Sáenz Peña');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (19, 'Villa Ángela');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (19, 'Charata');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (19, 'Castelli');

-- 20. Tucumán (ID: 20)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (20, 'San Miguel de Tucumán');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (20, 'Concepción');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (20, 'Yerba Buena');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (20, 'Tafí Viejo');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (20, 'Aguilares');

-- 21. Santiago del Estero (ID: 21)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (21, 'Santiago del Estero');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (21, 'La Banda');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (21, 'Termas de Río Hondo');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (21, 'Frías');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (21, 'Añatuya');

-- 22. La Pampa (ID: 22)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (22, 'Santa Rosa');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (22, 'General Pico');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (22, 'Eduardo Castex');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (22, 'Toay');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (22, '25 de Mayo');

-- 23. Tierra del Fuego (ID: 23)
INSERT INTO Ciudad(Provincia, Nombre) VALUES (23, 'Ushuaia');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (23, 'Río Grande');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (23, 'Tolhuin');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (23, 'Puerto Almanza');
INSERT INTO Ciudad(Provincia, Nombre) VALUES (23, 'San Sebastián');


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
    Activo BIT NOT NULL,
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
    
    @Provincia INT,
    @Ciudad INT,
    @Calle NVARCHAR(128),
    @Altura INT,
    @PD VARCHAR(16),

    @PersonaID INT OUTPUT
) AS BEGIN SET NOCOUNT ON;
    DECLARE @FoundPers INT = (SELECT ID FROM Persona WHERE (DNI = @DNI OR Legajo = @Legajo));
    IF (@FoundPers IS NULL) BEGIN
        DECLARE @DirID INT; 
        EXEC RegisterDireccion @Ciudad, @Calle, @Altura, @PD, @DirID OUTPUT;
        INSERT INTO Persona (Nombres, Apellidos, DNI, Telefono, Direccion, Imagen_URL, Legajo, Activo)
        VALUES (@Nombres, @Apellidos, @DNI, @Telefono, @DirID, @Img, @Legajo, 1);
        SET @PersonaID = SCOPE_IDENTITY();
    END ELSE BEGIN
        SET @PersonaID = @FoundPers;
    END
END;
GO

CREATE PROCEDURE UpdatePersona (
    @ID INT,
    @Nombres NVARCHAR(128), 
    @Apellidos NVARCHAR(128),
    @DNI INT,
    @Telefono VARCHAR(30),
    @Img NVARCHAR(1024),
    @Legajo INT
) AS BEGIN SET NOCOUNT ON;
    DECLARE @FoundPers INT = (SELECT ID FROM Persona WHERE ID = @ID);
    IF (@FoundPers IS NOT NULL) BEGIN
        UPDATE Persona SET
        Nombres = @Nombres,
        Apellidos = @Apellidos,
        DNI = @DNI,
        Telefono = @Telefono,
        Imagen_URL = @Img,
        Legajo = @Legajo
    WHERE ID = @ID;
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
    
    @Ciudad INT,
    @Calle NVARCHAR(128),
    @Altura INT,
    @PD VARCHAR(16),

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