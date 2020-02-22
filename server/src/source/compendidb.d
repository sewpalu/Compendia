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

  final Tuple!(DateTime, JSONValue)[string] getEntries(
      string userName, string templateUuid, DateTime since)
  {
    import std.algorithm;
    switchToUserDb(userName);
    auto results =
      m_connection.query(
          "SELECT entryUuid, entryDate, entryText
           FROM tblMain WHERE entryDate > ? AND usedTemplateID LIKE (SELECT ID FROM tblTemplates WHERE UUID LIKE ?)",
           since, templateUuid);
    Tuple!(DateTime, JSONValue)[string] ret;
    foreach (row; results)
      ret[row[0].get!string] =
          tuple(row[1].get!DateTime, parseJSON(row[2].get!string));
    return ret;
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

