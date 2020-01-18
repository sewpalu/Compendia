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
  struct Response
  {
    string message;
    Json originalRequest;
  }

  res.writeJsonBody(Response("Hey there, I'm using Dlang!", req.json));
}

