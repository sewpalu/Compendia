import vibe.vibe;

void main()
{
  auto settings = new HTTPServerSettings;
  settings.port = 8080;
  settings.bindAddresses = ["0.0.0.0"];

  readOption("port|p", &settings.port,
      "Sets the port used for serving HTTP.");
  readOption("bind-address|bind", &settings.bindAddresses[0],
      "Sets the address used for serving HTTP");

  auto listener = listenHTTP(settings, &parseReq);
  runApplication();
}

void parseReq(HTTPServerRequest req, HTTPServerResponse res)
{
  res.writeBody("Hey there, I'm using Dlang!");
}

/*
import std.stdio;

import lighttp;

import source.router;

void main()
{
	auto server = new Server;
	server.host("127.0.0.1", 8080);
	server.router.add(new Router);
	server.router.add(Get("hi"), new Resource("text/html", "<h1>Hello World! - 3</h1>"));
	server.run();
}
*/

