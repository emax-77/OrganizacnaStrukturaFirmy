# Organizačná štruktúra firmy

WinForms aplikácia vo VB.NET (.NET Framework 4.8) pre správu organizačnej štruktúry firmy a zamestnancov.

## SQL skript pre vytvorenie databázy (MS SQL Server)

```sql
CREATE DATABASE OrganizacnaStruktura;
GO

USE OrganizacnaStruktura;
GO

CREATE TABLE Zamestnanec (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titul NVARCHAR(50) NULL,
    Meno NVARCHAR(100) NOT NULL,
    Priezvisko NVARCHAR(100) NOT NULL,
    Telefon NVARCHAR(20) NULL,
    Email NVARCHAR(200) NULL,
    OddelenieId INT NOT NULL
);
GO

CREATE TABLE Firma (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nazov NVARCHAR(200) NOT NULL,
    Kod NVARCHAR(50) NOT NULL,
    RiaditelId INT NULL
);
GO

CREATE TABLE Divizia (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirmaId INT NOT NULL,
    Nazov NVARCHAR(200) NOT NULL,
    Kod NVARCHAR(50) NOT NULL,
    VeduciDivizieId INT NULL
);
GO

CREATE TABLE Projekt (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DiviziaId INT NOT NULL,
    Nazov NVARCHAR(200) NOT NULL,
    Kod NVARCHAR(50) NOT NULL,
    VeduciProjektuId INT NULL
);
GO

CREATE TABLE Oddelenie (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProjektId INT NOT NULL,
    Nazov NVARCHAR(200) NOT NULL,
    Kod NVARCHAR(50) NOT NULL,
    VeduciOddeleniaId INT NULL
);
GO

ALTER TABLE Divizia
ADD CONSTRAINT FK_Divizia_Firma
FOREIGN KEY (FirmaId) REFERENCES Firma(Id);
GO

ALTER TABLE Projekt
ADD CONSTRAINT FK_Projekt_Divizia
FOREIGN KEY (DiviziaId) REFERENCES Divizia(Id);
GO

ALTER TABLE Oddelenie
ADD CONSTRAINT FK_Oddelenie_Projekt
FOREIGN KEY (ProjektId) REFERENCES Projekt(Id);
GO

ALTER TABLE Zamestnanec
ADD CONSTRAINT FK_Zamestnanec_Oddelenie
FOREIGN KEY (OddelenieId) REFERENCES Oddelenie(Id);
GO

ALTER TABLE Firma
ADD CONSTRAINT FK_Firma_Riaditel
FOREIGN KEY (RiaditelId) REFERENCES Zamestnanec(Id);
GO

ALTER TABLE Divizia
ADD CONSTRAINT FK_Divizia_Veduci
FOREIGN KEY (VeduciDivizieId) REFERENCES Zamestnanec(Id);
GO

ALTER TABLE Projekt
ADD CONSTRAINT FK_Projekt_Veduci
FOREIGN KEY (VeduciProjektuId) REFERENCES Zamestnanec(Id);
GO

ALTER TABLE Oddelenie
ADD CONSTRAINT FK_Oddelenie_Veduci
FOREIGN KEY (VeduciOddeleniaId) REFERENCES Zamestnanec(Id);
GO

CREATE INDEX IX_Divizia_FirmaId ON Divizia(FirmaId);
CREATE INDEX IX_Projekt_DiviziaId ON Projekt(DiviziaId);
CREATE INDEX IX_Oddelenie_ProjektId ON Oddelenie(ProjektId);
CREATE INDEX IX_Zamestnanec_OddelenieId ON Zamestnanec(OddelenieId);
GO
```

## Nastavenie pripojenia

V súbore `App.config` uprav pripojovací reťazec `OrganizacnaStruktura` podľa svojho SQL Servera.
