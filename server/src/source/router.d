module source.router;

import std.format;

import lighttp;
import std.json;

/++
Defines the ressources, that can be used by the client;

Examples:
---
// For each ressource define a function according to the following pattern:
@Get("ressource", "path" /*, ... (e.g. "REGEX")*/) /* for: /ressource/path */ toRessource(ServerResponse response /*, additional parameters for generic ressource identifiers defined by regexes */)
{
    response.contentType = "application/json";

    JSONValue body = [
        /* define json fields here; E.g.:
        
        "users": JSONValue()
        
        */
    ];

    /* Initialise the json fields; E.g.:
    
    body["users"] = Database.getUsers();

    */

    response.body = body.toString;
}
---
+/
class Router
{

    /++
    Ressource; Index page
    +/
    @Get("") void toRoot(ServerResponse response)
    {
        response.body = "
                        <html>
                        <head><title>Compendia</title></head>
                        <body>
                        <h1>Compendia Server</h1>
                        Use these links for .json files containing live data from the database:
                        <ul>
                            <li> <a href=\"/users\">/users</a> </li>
                            <li> <a href=\"/users\">/users</a>/USERNAME </li>
                        </ul>
                        </body>
                        </html>";
    }

    /++
    Ressource; Available users
    +/
    @Get("users") toUsers(ServerResponse response)
    {
        response.contentType = "application/json";
        
        JSONValue body = [
            "users": JSONValue()
        ];
        
        body["users"] = ["sewpalu", "DerToaster", "nikolai"];
        
        response.body = body.toString;
    }

    /++
    Ressource; Data of specific user
    +/
    @Get("users", "([a-z0-9]*)") toUser(ServerResponse response, string username)
    {
        response.contentType = "application/json";

        JSONValue body = [
            "user": JSONValue(),
            "tables": JSONValue(),
            "permissions": JSONValue()
        ];
        
        body["user"] = username;
        body["tables"] = ["testTable0", "testTable1"];
        
        response.body = body.toString;
    }
}
