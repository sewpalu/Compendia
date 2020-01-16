CREATE DATABASE userDB_##USER##;
CONNECT userDB_##USER##;

CREATE TABLE IF NOT EXISTS tblMain (ID int AUTO_INCREMENT NOT NULL, entryTitle varchar(100) NOT NULL, entryDate DATE, usedTemplateID int NOT NULL, CONSTRAINT mainPrimKey PRIMARY KEY (ID));
CREATE INDEX entryTitleIndex ON tblMain(entryTitle);

CREATE TABLE IF NOT EXISTS tblEntryTemplateRelation (mainEntryID int, templateEntryID int, CONSTRAINT entryRelationPrimKey PRIMARY KEY(tblMainEntryID, tblTemplateEntryID));

CREATE TABLE IF NOT EXISTS tblTemplates (ID int AUTO_INCREMENT NOT NULL, templateName varchar(100) NOT NULL UNIQUE, templateXML TEXT NOT NULL, CONSTRAINT templatePrimKey PRIMARY KEY(ID)) AS SELECT DISTINCT defTempl.templateName, defTempl.templateXML FROM compendia.tbldefaulttemplates defTempl NATURAL JOIN compendia.tblpublictemplates ORDER BY defTempl.ID;