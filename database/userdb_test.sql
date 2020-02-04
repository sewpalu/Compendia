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
-- Datenbank: `userdb_test`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tblmain`
--

CREATE TABLE `tblmain` (
  `ID` int(11) NOT NULL,
  `entryTitle` varchar(100) NOT NULL,
  `entryDate` date DEFAULT NULL,
  `usedTemplateID` int(11) NOT NULL,
  `entryText` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Trigger `tblmain`
--
DELIMITER $$
CREATE TRIGGER `setEntryCreationDate` BEFORE INSERT ON `tblmain` FOR EACH ROW BEGIN SET NEW.entryDate = now();
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tbltemplates`
--

CREATE TABLE `tbltemplates` (
  `ID` int(11) NOT NULL,
  `templateName` varchar(100) NOT NULL,
  `templateXML` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `tblmain`
--
ALTER TABLE `tblmain`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `entryTitleIndex` (`entryTitle`);

--
-- Indizes für die Tabelle `tbltemplates`
--
ALTER TABLE `tbltemplates`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `templateName` (`templateName`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `tblmain`
--
ALTER TABLE `tblmain`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `tbltemplates`
--
ALTER TABLE `tbltemplates`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
