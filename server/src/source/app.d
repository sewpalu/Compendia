import std.json;
import std.datetime.date;

import vibe.vibe;

void main()
{
  auto router = new URLRouter;
  // router.registerWebInterface(new AppRouter);
  router.get("/", &parseReq);
  router.post("/", &parseReq);

  auto listener = listenHTTP(initSettings(), router);
  runApplication();
}

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

void parseReq(HTTPServerRequest req, HTTPServerResponse res)
{
  immutable commands = [
    "addEntry": &onAddEntry,
    "addUser": &onAddUser,
    "getEntries": &onGetEntries
  ];

  JSONValue outMessage = void;

  try
  {
    auto inMessage = cast(JSONValue) req.json;
    auto command = inMessage["command"].str;
    outMessage = ["command": command];
    
    immutable(JSONValue function(JSONValue))* commandPtr = command in commands;
    if (commandPtr ! is null)
      outMessage.object["result"] = (*commandPtr)(inMessage["parameters"]);
    
    outMessage.object["success"] = true;
  }
  catch (JSONException e)
  {
    outMessage = ["success": false];
    outMessage.object["error"] = "JSONException: " ~ e.msg;
  }
  catch (TimeException e)
  {
    outMessage = ["success": false];
    outMessage.object["error"] = "TimeException: " ~ e.msg;
  }

  res.writeJsonBody(outMessage);
}

JSONValue onAddEntry(JSONValue json)
{
  auto userId = json["userId"].integer;
  auto templateId = json["templateId"].integer;
  auto entry = json["entry"];
  return JSONValue(["entryId": dbAddEntry(userId, templateId, entry)]);
}

JSONValue onAddUser(JSONValue json)
{
  auto userName = json["userName"].str;
  return JSONValue(["userId": dbAddUser(userName)]);
}

JSONValue onGetEntries(JSONValue json)
{
  import std.algorithm;
  auto userId = json["userId"].integer;
  auto templateId = json["templateId"].integer;
  auto sinceTime = DateTime.fromSimpleString(json["since"].str);

  import std.range;
  auto entries = dbGetEntries(userId, templateId, sinceTime);
  JSONValue[] jsonEntries;
  auto transformedEntries = entries.byKeyValue.map!(entry => JSONValue(["id": JSONValue(entry.key), "data": JSONValue(entry.value)]));
  foreach (entry; transformedEntries)
    jsonEntries ~= entry; // TODO Optimize this
  return JSONValue(["entries": jsonEntries]);
}

int dbAddEntry(long userId, long templateId, JSONValue entry)
{
  return 0;
}

int dbAddUser(string userName)
{
  return 0;
}

JSONValue[int] dbGetEntries(long userId, long templateId, DateTime since)
{
  return [0 : JSONValue()];
}

