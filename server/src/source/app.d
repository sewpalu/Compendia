import vibe.vibe;

// import app_router;

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
  import std.json;

  JSONValue outMessage = ["sender": "server"];

  try
  {
    auto inMessage = cast(JSONValue) req.json;

    auto command = inMessage["command"].str;
    outMessage.object["command"] = JSONValue(command);
    switch (command)
    {
      case "addEntry":
      {
        auto userId = inMessage["userId"].integer;
        auto templateId = inMessage["templateId"].integer;
        auto entry = inMessage["entry"].toString;

        outMessage.object["entryId"] = JSONValue(dbAddEntry(userId, templateId, entry));
      }
      break;

      case "addUser":
      {
        auto userName = inMessage["userName"].toString;

        outMessage.object["userId"] = JSONValue(dbAddUser(userName));
      }
      break;

      case "getEntries":
      {
      }
      break;

      default:
      break;
    }

    outMessage.object["success"] = true;
  }
  catch (JSONException e)
  {
    logInfo(e.msg);
    outMessage.object["success"] = JSONValue(false);
    outMessage.object["error"] = JSONValue(e.msg);
  }

  res.writeJsonBody(outMessage);
}

int dbAddEntry(long userId, long templateId, string entry)
{
  return 0;
}

int dbAddUser(string userName)
{
  return 0;
}

