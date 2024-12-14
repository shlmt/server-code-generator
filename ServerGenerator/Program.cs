using ServerGenerator;

Server server = new NodeServer()
{
    Name = "example-server",
    Language = "nodejs",
    Database = "mongodb",
    DataBaseURL = "mongodb://localhost:27017/example",
    RootDirectory = "C:\\Users\\משתמש\\הנדסת תוכנה"
};

bool success = server.Generate();

Console.WriteLine(server.Name+" "+ success);
