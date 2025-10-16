-- =========================================================
-- BASE DE DATOS: Sistema de Recuerdos de Pepe
-- Autor: Manuela Cortés Granados
-- Fecha: 15/10/2025
-- Descripción: Modelo entidad-relación completo para SQL Server
-- =========================================================

-- Crear base de datos (opcional)
CREATE DATABASE SistemaRecuerdos;
GO

USE SistemaRecuerdos;
GO

-- =========================================================
-- TABLA: Usuarios
-- =========================================================
CREATE TABLE Usuarios (
    UsuarioId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    EsActivo BIT DEFAULT 1
);
GO

-- =========================================================
-- TABLA: Recuerdos
-- =========================================================
CREATE TABLE Recuerdos (
    RecuerdoId INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(MAX),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaEvento DATETIME NOT NULL,
    Estado NVARCHAR(20) CHECK (Estado IN ('Sospecha', 'Confirmado')) DEFAULT 'Sospecha',
    CreadorId INT NOT NULL,
    ConfirmadoPorId INT NULL,
    FechaConfirmacion DATETIME NULL,
    FOREIGN KEY (CreadorId) REFERENCES Usuarios(UsuarioId),
    FOREIGN KEY (ConfirmadoPorId) REFERENCES Usuarios(UsuarioId)
);
GO

-- =========================================================
-- TABLA: Lugares
-- =========================================================
CREATE TABLE Lugares (
    LugarId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(MAX),
    Direccion NVARCHAR(255),
    CreadorId INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CreadorId) REFERENCES Usuarios(UsuarioId)
);
GO

-- =========================================================
-- TABLA INTERMEDIA: Recuerdos_Lugares
-- =========================================================
CREATE TABLE Recuerdos_Lugares (
    RecuerdoId INT NOT NULL,
    LugarId INT NOT NULL,
    AsociadoPorId INT NOT NULL,
    FechaAsociacion DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (RecuerdoId, LugarId),
    FOREIGN KEY (RecuerdoId) REFERENCES Recuerdos(RecuerdoId),
    FOREIGN KEY (LugarId) REFERENCES Lugares(LugarId),
    FOREIGN KEY (AsociadoPorId) REFERENCES Usuarios(UsuarioId)
);
GO

-- =========================================================
-- TABLA: Objetos
-- =========================================================
CREATE TABLE Objetos (
    ObjetoId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(MAX),
    CreadorId INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CreadorId) REFERENCES Usuarios(UsuarioId)
);
GO

-- =========================================================
-- TABLA INTERMEDIA: Recuerdos_Objetos
-- =========================================================
CREATE TABLE Recuerdos_Objetos (
    RecuerdoId INT NOT NULL,
    ObjetoId INT NOT NULL,
    AsociadoPorId INT NOT NULL,
    FechaAsociacion DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (RecuerdoId, ObjetoId),
    FOREIGN KEY (RecuerdoId) REFERENCES Recuerdos(RecuerdoId),
    FOREIGN KEY (ObjetoId) REFERENCES Objetos(ObjetoId),
    FOREIGN KEY (AsociadoPorId) REFERENCES Usuarios(UsuarioId)
);
GO

-- =========================================================
-- TABLA: Personas
-- =========================================================
CREATE TABLE Personas (
    PersonaId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(MAX),
    CreadorId INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CreadorId) REFERENCES Usuarios(UsuarioId)
);
GO

-- =========================================================
-- TABLA INTERMEDIA: Recuerdos_Personas
-- =========================================================
CREATE TABLE Recuerdos_Personas (
    RecuerdoId INT NOT NULL,
    PersonaId INT NOT NULL,
    AsociadoPorId INT NOT NULL,
    FechaAsociacion DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (RecuerdoId, PersonaId),
    FOREIGN KEY (RecuerdoId) REFERENCES Recuerdos(RecuerdoId),
    FOREIGN KEY (PersonaId) REFERENCES Personas(PersonaId),
    FOREIGN KEY (AsociadoPorId) REFERENCES Usuarios(UsuarioId)
);
GO

-- =========================================================
-- TABLA: Notas
-- =========================================================
CREATE TABLE Notas (
    NotaId INT IDENTITY(1,1) PRIMARY KEY,
    RecuerdoId INT NOT NULL,
    Texto NVARCHAR(MAX) NOT NULL,
    CreadorId INT NOT NULL,
    AsociadoPorId INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (RecuerdoId) REFERENCES Recuerdos(RecuerdoId),
    FOREIGN KEY (CreadorId) REFERENCES Usuarios(UsuarioId),
    FOREIGN KEY (AsociadoPorId) REFERENCES Usuarios(UsuarioId)
);
GO

-- =========================================================
-- TABLAS: PalabrasClave y su relación con Recuerdos
-- =========================================================
CREATE TABLE PalabrasClave (
    PalabraId INT IDENTITY(1,1) PRIMARY KEY,
    Texto NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE Recuerdos_PalabrasClave (
    RecuerdoId INT NOT NULL,
    PalabraId INT NOT NULL,
    PRIMARY KEY (RecuerdoId, PalabraId),
    FOREIGN KEY (RecuerdoId) REFERENCES Recuerdos(RecuerdoId),
    FOREIGN KEY (PalabraId) REFERENCES PalabrasClave(PalabraId)
);
GO

-- =========================================================
-- TABLA: HistorialEnviosCorreo
-- =========================================================
CREATE TABLE HistorialEnviosCorreo (
    EnvioId INT IDENTITY(1,1) PRIMARY KEY,
    FechaEnvio DATETIME DEFAULT GETDATE(),
    TotalRecuerdos INT,
    EnviadoA NVARCHAR(150),
    EstadoEnvio NVARCHAR(50)
);
GO

-- =========================================================
-- FIN DEL SCRIPT
-- =========================================================
PRINT '✅ Modelo entidad-relación creado correctamente en la base de datos SistemaRecuerdos.';
GO
