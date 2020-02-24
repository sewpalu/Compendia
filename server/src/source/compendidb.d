import std.json;
import std.datetime.date;
import std.format;
import std.uuid;
import std.typecons;

import mysql;

class CompendiDb
{
  private
  {
    static s_connectionParams =
      "host=85.214.251.189;port=3306;user=root;pwd=m4n_p4g3_4_life";

    Connection m_connection;
  }

  final connect()
  {
    m_connection = new Connection(s_connectionParams);
  }

  final string addEntry(
      string userName, string templateUuid, JSONValue definition)
  {
    auto entryUuid = randomUUID.toString;
    switchToUserDb(userName);
    auto res = m_connection.exec("CALL insertEntry(?, ?, ?)",
          templateUuid, entryUuid, definition.toString);
    return entryUuid;
  }

  final string addTemplate(
      string userName, bool isPublic, string name, JSONValue definition)
  {
    import std.conv; // bool.to!string
    auto uuid = randomUUID.toString;
    switchToUserDb(userName);
    auto res = m_connection.exec("CALL addTemplate(?, ?, ?, ?)",
          uuid, isPublic, name, definition.toString);
    return uuid; 
  }

  final addUser(string userName)
  {
  }

  final Tuple!(DateTime, "timestamp", JSONValue, "definition")[string] getEntries(
      string userName, string templateUuid, DateTime since)
  {
    import std.algorithm;
    switchToUserDb(userName);
    auto results =
      m_connection.query(
          "SELECT entryUUID, entryDate, entryText
           FROM tblMain WHERE entryDate > ? AND usedTemplateID LIKE (SELECT ID FROM tblTemplates WHERE UUID LIKE ?)",
           since, templateUuid);
    Tuple!(DateTime, "timestamp", JSONValue, "definition")[string] ret;
    foreach (row; results)
      ret[row[0].get!string] =
          tuple(row[1].get!DateTime, parseJSON(row[2].get!string));
    return ret;
  }

  final Tuple!(string, "name", JSONValue, "definition")[string] getTemplates(
      string userName)
  {
    import std.algorithm;
    switchToUserDb(userName);

    Tuple!(string, "name", JSONValue, "definition")[string] ret;
    auto results =
      m_connection.query(
          "SELECT UUID, templateName, templateXML FROM tblTemplates");
    foreach (row; results)
      ret[row[0].get!string] =
          tuple(row[1].get!string, parseJSON(row[2].get!string));

    results =
      m_connection.query(
          "SELECT UUID, templateName, templateXML
          FROM compendia_main.tblPublicTemplates");
    foreach (row; results)
      ret[row[0].get!string] =
          tuple(row[1].get!string, parseJSON(row[2].get!string));

    results =
      m_connection.query(
          "SELECT UUID, templateName, templateXML
          FROM compendia_main.tblDefaultTemplates");
    foreach (row; results)
      ret[row[0].get!string] =
          tuple(row[1].get!string, parseJSON(row[2].get!string));

    return ret;
  }

  bool getUser(string userName)
  {
    auto results =
      m_connection.query("SELECT * FROM compendia_main.tblCompendiaUsers
          WHERE UserName LIKE ?", userName);
    foreach (row; results)
      return true;
    return false;
  }

  final close()
  {
    m_connection.close();
  }
    
  private
  {
    final switchToUserDb(string userName)
    {
      m_connection.exec(format!"use %s_db"(userName));
    }
  }
}

