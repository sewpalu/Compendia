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
