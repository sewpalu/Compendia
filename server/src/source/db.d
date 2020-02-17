import std.json;
import std.datetime.date;

import mysql;

class Db
{
  Connection m_connection;
  this()
  {
    connect();
  }

  final connect()
  {
    m_connection = new Connection("host=h2869529.stratoserver.net;port=3306;user=root;pwd=m4n_p4g3_4_life!");
  }

  int addEntry(long userId, long templateId, JSONValue entry)
  {
    return 0;
  }

  int addUser(string userName)
  {
    return 0;
  }

  JSONValue[int] getEntries(long userId, long templateId, DateTime since)
  {
    return [0 : JSONValue()];
  }

  final close()
  {
    m_connection.close();
  }
    
}

