# Message Format

This document specifies the expected format of the JSON files used by Compendia

## Client - Server communication

The JSON object shall consist of
- A property "command" (string). One of "addUser", "addEntry" or "getEntries".
- A property "parameters" (object). It shall consist of
  - A property "userName" (string), if "command" is "addUser"
  - A property "userId" (integer), if "command" is "addEntry" or "getEntries"
  - A property "templateId" (integer), if "command" is "addEntry" or "getEntries"
  - A property "since" (string; Format: "YYYY-Mon-DD HH:MM:SS"), if "command" is "getEntries"
  - A property "entry" (object; As defined below), if "command" is "addEntry"
- The response shall additionally include
  - A property "success" (boolean).
  - A object "result", if "success" is true. It shall consist of
    - A property "userId" (integer), if "command" is "addUser"
    - A property "entryId" (integer), if "command" is "addEntry"
    - A property "entries" (array), if "command" is "getEntries". It shall contain objects that consist of
      - A property "entryId" (integer)
      - A property "entry" (object; As defined below)
  - A property "error" (string), if "success" is false

### Example: addUser

#### Request
```json
{
  "command": "addUser",
  "parameters": {
    "userName": "Max Mustermann"
  }
}
```

#### Response
```json
{
  "command": "addUser",
  "success": true,
  "parameters": {
    "userName": "Max Mustermann"
  },
  "result": {
    "userId": 0
  }
}
```

### Example: addEntry

#### Request
```json
{
  "command": "addEntry",
  "parameters": {
    "userId": 0,
    "templateId": 0,
    "entry": null
  }
}
```

#### Response
```json
{
  "command": "addEntry",
  "success": true,
  "parameters": {
    "userId": 0,
    "templateId": 0,
    "entry": null
  },
  "result": {
    "entryId": 0
  }
}
```

### Example: getEntries

#### Request
```json
{
  "command": "getEntries",
  "parameters": {
    "userId": 0,
    "templateId": 0,
    "since": "2020-Feb-02 12:34:56"
  }
}
```

#### Response
```json
{
  "command": "getEntries",
  "success": true,
  "parameters": {
    "since": "2020-Feb-02 12:34:56",
    "userId": 0,
    "templateId": 0
  },
  "result": {
    "entries": [
      {
        "entryId": 0,
        "entry": null
      }
    ]
  }
}
```

## Template definitions

TODO

## Entry data

TODO

