# JsonObject
Easily use JSON-formatted files in C # with the JSONObject syntax of Processing.

## 1. JsonObject

### Example Usage

```c#
using System;
using JSON;

class Program
{
    static void Main ()
    {
        JsonObject json = new JsonObject ();

        json.SetInt ("id", 0);
        json.SetString ("species", "Panthera leo");
        json.SetString ("name", "Lion");

        Console.WriteLine (json.ToJson(prettyPrint:true));
    }
}
```



#### Result

```json
{
        "id": 0,
        "species": "Panthera leo",
        "name": "Lion"
}
```



## 2. JsonArray

### Example Usage

```c#
using System;
using JSON;

class Program
{
    static void Main ()
    {
        JsonArray json = new JsonArray ();

        json.Append (32);
        json.Append (1.5f);
        json.Append ("grape");
        json.Append (true);

        JsonObject obj = new JsonObject ();
        obj.SetFloat ("persistence", 0.75f);
        json.Append (obj);

        JsonArray arr = new JsonArray ();
        arr.Append ("red");
        arr.Append ("green");
        arr.Append ("blue");
        json.Append (arr);
        
        Console.WriteLine (json.ToJson(prettyPrint:true));
    }
}

```



#### Result

```json
[
        32,
        1.5,
        "grape",
        true,
        {
                "persistence": 0.75
        },
        [
                "red",
                "green",
                "blue"
        ]
]
```

 
