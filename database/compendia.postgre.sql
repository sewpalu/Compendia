-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 20. Jan 2020 um 17:11
-- Server-Version: 10.4.11-MariaDB
-- PHP-Version: 7.4.1

START TRANSACTION;


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: compendia
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle tblcompendiausers
--

CREATE TABLE tblcompendiausers (
  UID int NOT NULL,
  UserName varchar NOT NULL
);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle tbldefaulttemplates
--

CREATE TABLE tbldefaulttemplates (
  ID int NOT NULL,
  templateName varchar NOT NULL,
  templateXML text DEFAULT NULL
);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle tblpublictemplates
--

CREATE TABLE tblpublictemplates (
  ID int NOT NULL,
  templateName varchar NOT NULL,
  templateXML text DEFAULT NULL
);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle tblcompendiausers
--
ALTER TABLE tblcompendiausers
  ADD PRIMARY KEY (UID);

--
-- Indizes für die Tabelle tbldefaulttemplates
--
ALTER TABLE tbldefaulttemplates
  ADD PRIMARY KEY (ID);

--
-- Indizes für die Tabelle tblpublictemplates
--
ALTER TABLE tblpublictemplates
  ADD PRIMARY KEY (ID);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

/*
--
-- AUTO_INCREMENT für Tabelle tblcompendiausers
--
ALTER TABLE tblcompendiausers
  ALTER UID NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle tbldefaulttemplates
--
ALTER TABLE tbldefaulttemplates
  ALTER ID NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle tblpublictemplates
--
ALTER TABLE tblpublictemplates
  ALTER ID NOT NULL AUTO_INCREMENT;*/
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
