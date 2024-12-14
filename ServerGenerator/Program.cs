using ServerGenerator;

Model[] models = [
   new NodeModel()
    {
        Name = "person",
        Properties = [
            new NodeProperty()
            {
                Name = "name",
                Type = DataType.String,
                DefaultValue = "123",
                IsRequired = true,
                IsUnique = true,
                IsLowerCase = true,
                IsTrim = true
            },
            new NodeProperty()
            {
                Name = "age",
                Type = DataType.Number,
                Min = 0,
                Max = 120
            },
            new NodeProperty()
            {
                Name = "numbers",
                Type = DataType.Doubles,
                DefaultValue = "[1.5,2,3]"
            }
        ]
    },
    new NodeModel()
    {
        Name = "item",
        Properties = [
            new NodeProperty()
            {
                Name = "type",
                Type = DataType.String,
                Enum = ["a","b","c"],
                IsImmutable = true,
            },
            new NodeProperty()
            {
                Name = "desc",
                Type = DataType.String,
                Min = 0,
                Max = 50
            },
            new NodeProperty()
            {
                Name = "creator",
                Type = DataType.ObjectId,
                Ref = "person"
            }
        ]
    }
];

ProjectInfo.RootDirectory = "C:\\Users\\משתמש\\הנדסת תוכנה";
ProjectInfo.ProjectName = "example-server";

Server server = new NodeServer()
{
    Language = "nodejs",
    Database = "mongodb",
    DataBaseURL = "mongodb://localhost:27017/example",
    Models = models
};

bool success = server.Generate();

Console.WriteLine(ProjectInfo.ProjectName+" "+ success);
