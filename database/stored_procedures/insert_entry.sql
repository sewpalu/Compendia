/* Insert Anleitung um Eintrag abzulegen */
/* ID des Templates ermitteln, WICHTIG: Es muss der STRING_NAME des Templates übergeben werden, da die IDs in beiden DB's unterschiedlich sein können */
DELIMITER $$
CREATE PROCEDURE `insertEntry`
(IN `TEMPLATE_NAME` VARCHAR(100), IN `ENTRY_UUID` VARCHAR(100), IN `ENTRY_JSON` TEXT) 
COMMENT 'Creates entries' NOT DETERMINISTIC CONTAINS SQL 
SQL SECURITY DEFINER 
BEGIN 
DECLARE TEMPLATE_ID INT; 
SET TEMPLATE_ID = (SELECT T.ID FROM tblTemplates T WHERE T.templateName LIKE TEMPLATE_NAME); 
INSERT INTO tblMain(entryTitle, usedTemplateID, entryText) VALUES (ENTRY_UUID, TEMPLATE_ID, ENTRY_JSON); 
END 
DELIMITER ; $$