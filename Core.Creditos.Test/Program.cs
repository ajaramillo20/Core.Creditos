using Core.Common.Util.Helper.API;
using Core.Creditos.Adapters;
using Core.Creditos.DataAccess.Usuarios;
using Newtonsoft.Json;
using System.Dynamic;

//dynamic flexible = new ExpandoObject();
//flexible.Int = 3;
//flexible.String = "hi";

//var dictionary = (IDictionary<string, object>)flexible;
//dictionary.Add("Bool", false);

//var serialized = JsonConvert.SerializeObject(dictionary);
//var deserialized = JsonConvert.DeserializeObject<Dictionary<string, object>>(serialized);
//var x = 0;


//QueueResponsables.StartQueueService();

//var x = QueueResponsables.GetResponsable();
//var y = QueueResponsables.GetResponsable();
ValidarUsuarioResponsableDAL.Execute("ajaramillo");
ValidarUsuarioResponsableDAL.Execute("asdasd");

return 0;