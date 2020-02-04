/* Insert Anleitung um Eintrag abzulegen */
/* ID des Templates ermitteln, WICHTIG: Es muss der STRING_NAME des Templates übergeben werden, da die IDs in beiden DB's unterschiedlich sein können */
CREATE PROCEDURE insertEntry(
  IN TEMPLATE_NAME VARCHAR(100),
  IN ENTRY_NAME VARCHAR(100),
  IN ENTRY_JSON TEXT)
LANGUAGE plpgsql
AS $$
  DECLARE
    TEMPLATE_ID INT;
  BEGIN
    TEMPLATE_ID := (SELECT T.ID FROM tblTemplates T WHERE T.templateName LIKE TEMPLATE_NAME);
    INSERT INTO tblMain(entryTitle, usedTemplateID, entryText)
      VALUES (ENTRY_NAME, TEMPLATE_ID, ENTRY_JSON);
  END
$$; 
