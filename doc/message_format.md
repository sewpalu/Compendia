# Message Format

This document specifies the expected format of the JSON files used by Compendia

## Client - Server communication

The JSON object shall consist of
- A property "command" (string). One of "addUser", "addEntry", "addTemplates", "getUser", "getTemplates" or "getEntries".
- A property "parameters" (object). Provided attributes by command:
  - "addUser": "userName"
  - "addEntry": "userName", "templateUuid", "entryDefinition"
  - "addTemplate": "userName", "isPublicTemplate", "templateName", "templateDefinition"
  - "getUser": "userName"
  - "getEntries": "userName", "templateUuid", "since"
  - "getTemplates": "userName"
- The response shall additionally include
  - A property "success" (boolean).
  - A object "result", if "success" is true. Provided attributes by command:
    - "addUser": None
    - "addEntry": "entryUuid"
    - "addTemplate": "templateUuid"
    - "getUser": "doesUserExist"
    - "getEntries": "entries"
    - "getTemplates": "templates"
  - A property "error" (string), if "success" is false

Used attributes are:
- "userName" (string)
- "templateUuid" (string)
- "since" (string; Format: "YYYY-Mon-DD HH:MM:SS")
- "isPublicTemplate" (boolean)
- "doesUserExist" (boolean)
- "templateName" (string)
- "templateDefinition" (object)
- "entryDefinition" (object)
- "entryUuid" (string)
- "creationTime" (string; Format: "YYYY-Mon-DD HH:MM:SS")
- "entries" (array); Its elements shall be objects that consist of the attributes "entryUuid", "creationTime" and "entryDefinition"
- "templates" (array); Its elements shall be objects that consist of the attributes "templateUuid", "templateName" and "templateDefinition"


### Example: addUser

#### Request
```json
{
  "command": "addUser",
  "parameters": {
    "userName": "testuser"
  }
}
```

#### Response
```json
{
  "command": "addUser",
  "success": true,
  "parameters": {
    "userName": "testuser"
  },
  "result": {}
}
```

### Example: addEntry

#### Request
```json
{
  "command": "addEntry",
  "parameters": {
    "userName": "testuser",
    "templateUuid": "fff4eb8b-677f-4c15-9da3-330927ab1ddb",
    "entryDefinition": {
      "some": "data"
    }
  }
}
```

#### Response
```json
{
  "command": "addEntry",
  "success": true,
  "parameters": {
    "entryDefinition": {
      "some": "data"
    },
    "userName": "testuser",
    "templateUuid": "fff4eb8b-677f-4c15-9da3-330927ab1ddb"
  },
  "result": {
    "entryUuid": "91af9b36-9337-4873-a1c3-6fd7eab8d0a2"
  }
}
```

### Example: addTemplate

#### Request
```json
{
  "command": "addTemplate",
  "parameters": {
    "userName": "testuser",
    "isPublicTemplate": false,
    "templateName": "testtemplate",
    "templateDefinition": {
      "some": "data"
    }
  }
}
```

#### Response
```json
{
"command": "addTemplate",
"success": true,
"parameters": {
    "isPublicTemplate": false,
    "templateName": "testtemplate",
    "templateDefinition": {
      "some": "data"
    },
    "userName": "testuser"
  },
  "result": {
    "templateUuid": "fff4eb8b-677f-4c15-9da3-330927ab1ddb"
  }
}
```
### Example: getUser

#### Request
```json
{
  "command": "getUser",
  "parameters": {
    "userName": "testuser"
  }
}
```

#### Response
```json
{
  "command": "getUser",
  "success": true,
  "parameters": {
    "userName": "testuser"
  },
  "result": {
    "doesUserExist": true
  }
}
```

### Example: getEntries

#### Request
```json
 {
  "command": "getEntries",
  "parameters": {
    "userName": "testuser",
    "templateUuid": "fff4eb8b-677f-4c15-9da3-330927ab1ddb",
    "since": "2020-Jan-01 12:00:00"
  }
}
```

#### Response
```json
{
  "command": "getEntries",
  "success": true,
  "parameters": {
    "since": "2020-Jan-01 12:00:00",
    "userName": "testuser",
    "templateUuid": "fff4eb8b-677f-4c15-9da3-330927ab1ddb"
  },
  "result": {
    "entries": [
      {
        "entryUuid": "91af9b36-9337-4873-a1c3-6fd7eab8d0a2",
        "entryDefinition": {
          "some": "data"
        },
        "creationTime": "2020-Feb-22 19:34:29"
      }
    ]
  }
}
```

### Example: getTemplates

#### Request
```json
{
  "command": "getTemplates",
  "parameters": {
    "userName": "testuser"
  }
}
```

#### Response
```json
{
  "command": "getTemplates",
  "success": true,
  "parameters": {
    "userName": "testuser"
  },
  "result": {
    "templates": [
      {
        "templateName": "testtemplate",
        "templateDefinition": {
          "some": "data"
        },
        "templateUuid": "983155e6-7a20-4046-ae56-18db61bec2f4"
      },
      {
        "templateName": "testtemplate",
        "templateDefinition": {
          "some": "data"
        },
        "templateUuid": "fff4eb8b-677f-4c15-9da3-330927ab1ddb"
      }
    ]
  }
}
```

