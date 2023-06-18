using Newtonsoft.Json.Linq;

#region Path Setup
string fileName = "file.json";
string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
string baseDirJson = Path.Combine(Directory.GetParent(baseDir)
	.Parent.Parent.Parent.Parent.FullName,fileName);

Console.WriteLine($"{baseDir}{Environment.NewLine}{baseDirJson}");
#endregion

#region JSON Setup
var jsonTextData = File.ReadAllText(baseDirJson);
JObject o = JObject.Parse(jsonTextData);

var team = o["team"];
#endregion

#region Raw JToken
Console.WriteLine("\nRaw JToken\n==========\n");

foreach (JToken item in team)
{
	// Keys are case sensitive
	Console.WriteLine(item["id"]);
	Console.WriteLine(item["Name"]);
	Console.WriteLine(item["Age"]);
}
#endregion

#region Using LINQ
Console.WriteLine("\nUsing LINQ\n==========\n");

team.Select((item) =>
	new Person
	{
		Id = Convert.ToInt32(item["id"]),
		Name = item["Name"].ToString(),
		Age = Convert.ToInt32(item["Age"])
	}
).ToList().ForEach(item =>
{
	Console.WriteLine(item.Id);
	Console.WriteLine(item.Name);
	Console.WriteLine(item.Age);
});
#endregion