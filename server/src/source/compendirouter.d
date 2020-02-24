import std.json;
import std.datetime.date;

import vibe.vibe;
import mysql;

import compendidb;

class CompendiRouter
{
  private
  {
    CompendiDb m_db = new CompendiDb;
    URLRouter m_router = new URLRouter;
  }

  final serve()
  {
    m_db.connect();
    m_router.post("/", &parseRequest);
    auto listener = listenHTTP(initSettings(), m_router);
    runApplication();
    m_db.close();
  }

  private
  {
    HTTPServerSettings initSettings()
    {
      auto settings = new HTTPServerSettings;
      settings.port = 8080;
      settings.bindAddresses = ["0.0.0.0"];

      readOption("port|p", &settings.port,
          "Sets the port used for serving HTTP.");
      readOption("bind-address|bind", &settings.bindAddresses[0],
          "Sets the address used for serving HTTP");

      return settings;
    }

    final parseRequest(HTTPServerRequest req, HTTPServerResponse res)
    {
      immutable commands = [
        "addEntry": &onAddEntry,
        "addUser": &onAddUser,
        "addTemplate": &onAddTemplate,
        "getUser": &onGetUser,
        "getEntries": &onGetEntries,
        "getTemplates": &onGetTemplates
      ];

      JSONValue[string] dummy;
      JSONValue outMessage = dummy;

      try
      {
        auto inMessage = cast(JSONValue) req.json;
        auto command = inMessage["command"].str;
        outMessage.object["command"] = command;
        auto parameters = inMessage["parameters"];
        outMessage.object["parameters"] = parameters;
        
        immutable(JSONValue delegate(JSONValue))* commandPtr = command in commands;
        if (commandPtr ! is null)
          outMessage.object["result"] = (*commandPtr)(inMessage["parameters"]);
        else
          throw new JSONException("Invalid command \"" ~ command ~ "\"");
        
        outMessage.object["success"] = true;
      }
      catch (JSONException e)
      {
        outMessage.object["success"] = false;
        outMessage.object["error"] = "JSONException: " ~ e.msg;
      }
      catch (TimeException e)
      {
        outMessage.object["success"] = false;
        outMessage.object["error"] = "TimeException: " ~ e.msg;
      }
      catch (MYX e)
      {
        outMessage.object["success"] = false;
        outMessage.object["error"] = "MySqlException: " ~ e.msg;
      }

      res.writeJsonBody(outMessage);
    }
    
    JSONValue onAddEntry(JSONValue json)
    {
      auto userName = json["userName"].str;
      auto templateUuid = json["templateUuid"].str;
      auto definition = json["entryDefinition"];
      return JSONValue(
          ["entryUuid": m_db.addEntry(userName, templateUuid, definition)]);
    }

    JSONValue onAddUser(JSONValue json)
    {
      auto userName = json["userName"].str;
      JSONValue[string] empty;
      return JSONValue(empty);
    }

    JSONValue onAddTemplate(JSONValue json)
    {
      import std.conv; // str.to!bool
      auto userName = json["userName"].str;
      auto isPublic = json["isPublicTemplate"].str.to!bool;
      auto name = json["templateName"].str;
      auto definition = json["templateDefinition"];
      return JSONValue(
          ["templateUuid":
              m_db.addTemplate(userName, isPublic, name, definition)]);
    }

    JSONValue onGetUser(JSONValue json)
    {
      auto userName = json["userName"].str;
      return JSONValue(["doesUserExist": m_db.getUser(userName)]);
    }

    JSONValue onGetEntries(JSONValue json)
    {
      import std.algorithm;
      auto userName = json["userName"].str;
      auto templateUuid = json["templateUuid"].str;
      auto since= DateTime.fromSimpleString(json["since"].str);

      auto entries = m_db.getEntries(userName, templateUuid, since);
      JSONValue[] jsonEntries;
      auto transformedEntries = entries.byKeyValue.map!(
          entry => JSONValue([
            "entryUuid": JSONValue(entry.key),
            "creationTime": JSONValue(entry.value.timestamp.toSimpleString),
            "entryDefinition": entry.value.definition]));
      foreach (entry; transformedEntries)
        jsonEntries ~= entry;
      return JSONValue(["entries": jsonEntries]);
    }

    JSONValue onGetTemplates(JSONValue json)
    {
      import std.algorithm;
      auto userName = json["userName"].str;

      auto entries = m_db.getTemplates(userName);
      JSONValue[] jsonEntries;
      auto transformedEntries = entries.byKeyValue.map!(
          entry => JSONValue([
            "templateUuid": JSONValue(entry.key),
            "templateName": JSONValue(entry.value.name),
            "templateDefinition": entry.value.definition]));
      foreach (entry; transformedEntries)
        jsonEntries ~= entry;
      return JSONValue(["templates": jsonEntries]);
    }
  }
}
