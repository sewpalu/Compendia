import std.json;
import std.datetime.date;
import std.format;
import std.uuid;

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

  final string addEntry(string userName, long templateId, JSONValue entry)
  {
    auto entryUuid = randomUUID().toString();
    switchToUserDb(userName);
    auto res = m_connection.query(
        format!"CALL insertEntry(%d, '%s', '%s')"(templateId, entryUuid, entry.toString));
    return entryUuid;
  }

  final addUser(string userName)
  {
  }

  final JSONValue[int] getEntries(long userId, long templateId, DateTime since)
  {
    return [0 : JSONValue()];
  }

  final close()
  {
    m_connection.close();
  }
    
  private
  {
    final switchToUserDb(string userName)
    {
      m_connection.exec("use userdb_test");
      //m_connection.exec(format!"use %s_db"(userName));
    }
  }
}

