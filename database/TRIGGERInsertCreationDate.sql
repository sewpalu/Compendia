/*Trigger to auto insert the creation date of a entry*/
CREATE TRIGGER setEntryCreationDate BEFORE INSERT ON tblMain FOR EACH ROW BEGIN SET NEW.entryDate = now(); END 