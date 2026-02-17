# Organizačná štruktúra firmy

WinForms aplikácia vo VB.NET pre správu organizačnej štruktúry firmy a zamestnancov.

## Všeobecné poznámky 

Použil som slovenské názvy tried, metód a niektorých premenných.
V práci používame prevažne MySQL, trochu som bojoval s MS SQL Serverom.
V SSMS mi nešlo spustiť naraz všetky SQL príkazy v jednom skripte, aj keď medzi nimi bol príkaz GO – tak som skript rozdelil do dvoch častí. Viď nižšie.
Nakoľko ide o malý projekt, neriešim tu indexy – len tabuľky a ich väzby.
Z rovnakého dôvodu sa nepoužíva ORM a LINQ, len čistý ADO.NET.
Niektoré polia som možno predimenzoval (napr. titul alebo kód). Chápem, že v realite by ich veľkosť závisela od zadania (požiadaviek).
Nebol som si úplne istý, čo sa bude zapisovať do poľa "Kód", tak som ho nastavil ako String.
Pre UI som použil len základné WinForms. Je funkčné, ale dosť jednoduché.
Základné validácie sú implementované, v reálnom projekte by som zrejme riešil aj kontrolu formátu telefónneho čísla, jeho duplicitu atď.
Je tu naviac možnosť editovať vlastné názvy všetkých uzlov a ich kódy.

## Poznámky k dátovým triedam

Dátové triedy dedia z jednej spoločnej triedy `ZakladnyCRUD.vb`. 
Typ uzla organizačnej štruktúry je Enum `TypUzla` (Firma, Divizia, Projekt, Oddelenie).
`ZaradenieId` je ID uzla, ku ktorému sa viaže zvolené Zaradenie (Riaditeľ/Vedúci divízie/Vedúci projektu/Vedúci oddelenia).
`ZaradenieTyp` určuje typ vedúcej funkcie – bežný zamestnanec (bez vedúcej funkcie) má `ZaradenieTyp = Nothing`.

## Nastavenie pripojenia

V súbore `App.config` uprav pripojovací reťazec `OrganizacnaStruktura` podľa svojho SQL Servera.

### SQL skript 1 - vytvorenie databázy

```
CREATE DATABASE OrganizacnaStruktura;
```

### SQL skript 2  - vytvorenie tabuliek

```
USE OrganizacnaStruktura;
GO

CREATE TABLE Zamestnanec (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titul NVARCHAR(50) NULL,
    Meno NVARCHAR(100) NOT NULL,
    Priezvisko NVARCHAR(100) NOT NULL,
    Telefon NVARCHAR(20) NULL,
    Email NVARCHAR(200) NULL,
    Zaradenie NVARCHAR(100) NOT NULL,
    ZaradenieId INT NOT NULL,
    UzolTyp NVARCHAR(50) NOT NULL,
    UzolId INT NOT NULL
);

CREATE TABLE Firma (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nazov NVARCHAR(200) NOT NULL,
    Kod NVARCHAR(50) NOT NULL,
    RiaditelId INT NULL
);

CREATE TABLE Divizia (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirmaId INT NOT NULL,
    Nazov NVARCHAR(200) NOT NULL,
    Kod NVARCHAR(50) NOT NULL,
    VeduciDivizieId INT NULL
);

CREATE TABLE Projekt (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DiviziaId INT NOT NULL,
    Nazov NVARCHAR(200) NOT NULL,
    Kod NVARCHAR(50) NOT NULL,
    VeduciProjektuId INT NULL
);

CREATE TABLE Oddelenie (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProjektId INT NOT NULL,
    Nazov NVARCHAR(200) NOT NULL,
    Kod NVARCHAR(50) NOT NULL,
    VeduciOddeleniaId INT NULL
);

ALTER TABLE Divizia
ADD CONSTRAINT FK_Divizia_Firma
FOREIGN KEY (FirmaId) REFERENCES Firma(Id);

ALTER TABLE Projekt
ADD CONSTRAINT FK_Projekt_Divizia
FOREIGN KEY (DiviziaId) REFERENCES Divizia(Id);

ALTER TABLE Oddelenie
ADD CONSTRAINT FK_Oddelenie_Projekt
FOREIGN KEY (ProjektId) REFERENCES Projekt(Id);

ALTER TABLE Firma
ADD CONSTRAINT FK_Firma_Riaditel
FOREIGN KEY (RiaditelId) REFERENCES Zamestnanec(Id);

ALTER TABLE Divizia
ADD CONSTRAINT FK_Divizia_Veduci
FOREIGN KEY (VeduciDivizieId) REFERENCES Zamestnanec(Id);

ALTER TABLE Projekt
ADD CONSTRAINT FK_Projekt_Veduci
FOREIGN KEY (VeduciProjektuId) REFERENCES Zamestnanec(Id);

ALTER TABLE Oddelenie
ADD CONSTRAINT FK_Oddelenie_Veduci
FOREIGN KEY (VeduciOddeleniaId) REFERENCES Zamestnanec(Id);
```

## Obrázky

<img width="1117" height="424" alt="image" src="https://github.com/user-attachments/assets/b86b3810-d0df-4396-a2e9-2b5ab88b8854" />
<img width="1113" height="415" alt="image" src="https://github.com/user-attachments/assets/79f89e4a-39de-4bc7-9270-7118eee3c26d" />

