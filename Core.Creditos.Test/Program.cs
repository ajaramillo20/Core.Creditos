using Newtonsoft.Json;
using System.Dynamic;

dynamic flexible = new ExpandoObject();
flexible.Int = 3;
flexible.String = "hi";

var dictionary = (IDictionary<string, object>)flexible;
dictionary.Add("Bool", false);

var serialized = JsonConvert.SerializeObject(dictionary);
var deserialized = JsonConvert.DeserializeObject<Dictionary<string, object>>(serialized);
var x = 0;
