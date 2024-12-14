﻿namespace ServerGenerator.nodejs
{
    internal class NodeModel : Model
    {
        public override bool Generate()
        {
            string propertiesCode = "";
            foreach (NodeProperty property in Properties)
            {
                propertiesCode += property.Generate();
            }

            string modelCode = "// this file generated by shlmt/ServerGenerator\r\n" +
                "\r\n" +
                "const mongoose = require('mongoose')\r\n" +
                "\r\n" +
                $"const {Name}Schema = new mongoose.Schema(\r\n" +
                "    {\r\n" +
                $"{propertiesCode}" +
                "    },\r\n" +
                "    {\r\n" +
                "        timestamps:true\r\n" +
                "    }\r\n" +
                ")\r\n" +
                "\r\n" +
                $"module.exports = mongoose.model('{Utils.CapitalizeFirstLetter(Name)}',{Name}Schema)";

            try
            {
                string directoryPath = Path.Combine(ProjectInfo.RootDirectory, ProjectInfo.ProjectName, "models");
                Utils.CreateFolder(directoryPath);
                Utils.CreateFile(Path.Combine(directoryPath, Name + ".js"), modelCode, "models/" + Name);
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
