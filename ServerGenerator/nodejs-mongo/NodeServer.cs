﻿namespace ServerGenerator.nodejs
{
    internal class NodeServer : Server
    {
        public override bool Generate()
        {
            string routesCode = "//routes\r\n";
            string directoryPath = Path.Combine(ProjectInfo.RootDirectory, ProjectInfo.ProjectName, "models");
            if (!Utils.CreateFolder(directoryPath, "models")) return false;

            directoryPath = Path.Combine(ProjectInfo.RootDirectory, ProjectInfo.ProjectName, "controllers");
            if (!Utils.CreateFolder(directoryPath, "controllers")) return false;

            directoryPath = Path.Combine(ProjectInfo.RootDirectory, ProjectInfo.ProjectName, "routes");
            if (!Utils.CreateFolder(directoryPath, "routes")) return false;

            foreach (Model model in Models)
            {
                if (model.Generate())
                {
                    Controller controller = new NodeController()
                    {
                        Model = model,
                    };
                    if (controller.Generate())
                    {
                        Route route = new NodeRoute()
                        {
                            Name = model.Name
                        };
                        if (route.Generate())
                        {
                            routesCode += $"app.use(\"/api/{model.Name}\", require('./routes/{model.Name}Route'))\r\n";
                        }
                    }

                }
            }


            string serverCode = "// this file generated by shlmt/ServerGenerator\r\n" +
                "\r\n" +
                "require(\"dotenv\").config()\r\n" +
                "const express = require(\"express\")\r\n" +
                "const cors = require(\"cors\")\r\n" +
                "const corsOptions = require(\"./config/corsOptions\")\r\n" +
                "const connectDB = require(\"./config/dbConn\")\r\n" +
                "const mongoose = require(\"mongoose\")\r\n" +
                "\r\n" +
                "const app = express()\r\n" +
                "const PORT = process.env.PORT || 1234\r\n" +
                "connectDB()\r\n" +
                "\r\n" +
                "app.use(cors(corsOptions))\r\n" +
                "app.use(express.json())\r\n" +
                "app.use(express.static(\"public\"))\r\n" +
                "\r\n" +
                $"{routesCode}\r\n" +
                "\r\n" +
                "mongoose.connection.once('open',()=>{{\r\n " +
                "   console.log(\"connected to mongoDB\")\r\n" +
                "    app.listen(PORT, ()=>{{\r\n" +
                "        console.log(`server running on ${PORT}`)\r\n" +
                "    }})\r\n}})\r\n" +
                "\r\n" +
                "mongoose.connection.on(\"error\", err=>{{\r\n" +
                "    console.log(err);\r\n}})";

            string corsOptionsCode = "// this file generated by shlmt/ServerGenerator\r\n" +
                "\r\n" +
                "const allowedOrigins = [\r\n" +
                "    'http://localhost:3000',\r\n" +
                "    'http://localhost:4200',\r\n" +
                "    process.env.CLIENT_URL\r\n\r\n" +
                "]\r\n" +
                "\r\n" +
                "const corsOptions = {\r\n" +
                "    origin: (origin, callback) => {\r\n" +
                "        if (allowedOrigins.indexOf(origin) !== -1 || !origin) {\r\n" +
                "            callback(null, true)\r\n" +
                "        } else {\r\n" +
                "            callback(new Error('Not allowed by CORS'))\r\n" +
                "        }\r\n" +
                "    },\r\n" +
                "    credentials: true,\r\n" +
                "    optionsSuccessStatus: 200\r\n" +
                "}\r\n" +
                "\r\n" +
                "module.exports = corsOptions ";

            string dbConnCode = "// this file generated by shlmt/ServerGenerator\r\n" +
                "\r\n" +
                "const mongoose = require(\"mongoose\")\r\n" +
                "\r\n" +
                "const connectDB = async ()=>{\r\n" +
                "    try {\r\n" +
                $"        await mongoose.connect(process.env.DATEBASE_URL)\r\n" +
                "    } catch (error) {\r\n" +
                "        console.log(\"error_db:\"+error);\r\n" +
                "    }\r\n" +
                "}\r\n" +
                "\r\n" +
                "module.exports = connectDB";

            string envCode = "// this file generated by shlmt/ServerGenerator\r\n" +
                "\r\n" +
                "PORT = 1234\r\n" +
                $"DATEBASE_URL = {DataBaseURL}\r\n" +
                "CLIENT_URL = localhost:3000";

            try
            {
                directoryPath = Path.Combine(ProjectInfo.RootDirectory, ProjectInfo.ProjectName);
                if (!Utils.CreateFolder(directoryPath, ProjectInfo.ProjectName)) return false;

                Utils.CreateFile(Path.Combine(directoryPath, "server.js"), serverCode, "server.js");
                Utils.RunCommand("npm", "init -y", directoryPath);
                Utils.RunCommand("npm", "install express cors dotenv mongoose", directoryPath);

                Utils.CreateFile(Path.Combine(directoryPath, ".env"), envCode, ".env");

                string configPath = Path.Combine(directoryPath, "config");
                Utils.CreateFolder(configPath, "config");

                Utils.CreateFile(Path.Combine(configPath, "corsOptions.js"), corsOptionsCode, "corsOptions.js");
                Utils.CreateFile(Path.Combine(configPath, "dbConn.js"), dbConnCode, "dbConn.js");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }

            return true;
        }
    }
}
