-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 20. Jan 2020 um 17:11
-- Server-Version: 10.4.11-MariaDB
-- PHP-Version: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `compendia`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tblcompendiausers`
--

CREATE TABLE `tblcompendiausers` (
  `UID` int(11) NOT NULL,
  `UserName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tbldefaulttemplates`
--

CREATE TABLE `tbldefaulttemplates` (
  `ID` int(11) NOT NULL,
  `templateName` varchar(100) NOT NULL,
  `templateXML` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tblpublictemplates`
--

CREATE TABLE `tblpublictemplates` (
  `ID` int(11) NOT NULL,
  `templateName` varchar(100) NOT NULL,
  `templateXML` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `tblcompendiausers`
--
ALTER TABLE `tblcompendiausers`
  ADD PRIMARY KEY (`UID`),
  ADD KEY `userNameIndex` (`UID`);

--
-- Indizes für die Tabelle `tbldefaulttemplates`
--
ALTER TABLE `tbldefaulttemplates`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `templateName` (`templateName`),
  ADD KEY `templateNameIndex` (`templateName`);

--
-- Indizes für die Tabelle `tblpublictemplates`
--
ALTER TABLE `tblpublictemplates`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `tblcompendiausers`
--
ALTER TABLE `tblcompendiausers`
  MODIFY `UID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `tbldefaulttemplates`
--
ALTER TABLE `tbldefaulttemplates`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `tblpublictemplates`
--
ALTER TABLE `tblpublictemplates`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
