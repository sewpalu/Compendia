# Message Format

This document specifies the expected format of the JSON files used by Compendia

## Client - Server communication

The JSON object shall consist of
- A property "sender", specifying the author of the message. Either "client" or "server".
- A property "command", specifying the action performed by the server either as a request from the client or in response from the server specifying what operation it is responding to. On of "addUser", "addEntry" or "getEntries"
- If sent from the client:
  - If "command" is set to "addUser":
    - A property "userName", specifying the username.
  - If "command" is set to "addEntry":
    - A property "userId", specifying the ID of the user for whomst the entry shall be added.
    - A property "templateId", specifying the template to which the entry belongs.
    - A property "entry", containing the entry data as specified below.
  - If "command" is set to "getEntries":
    - TODO: Specify the required fields for "getEntries"
- If sent as a response from the server:
  - A property "success", specifying if the operation could be performed successfuly. Either true or false.
  - If "success" is set to false
    - A property "error", containing further information as to why the operation failed.
  - If "command" is set to "getEntries"
    - A property "entries", containing an array of entry data as specified below.

### Example: addUser

#### Request
```json
{
	"sender": "client",
	"command": "addUser",
	"userName": "Max Mustermann"
}
```

#### Response
```json
{
  "command": "addUser",
  "success": true,
  "sender": "server",
  "userId": 0
}
```


## Template definitions

TODO

## Entry data

TODO

