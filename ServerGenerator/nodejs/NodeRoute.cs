﻿
namespace ServerGenerator.nodejs
{
    internal class NodeRoute : Route
    {
        public override bool Generate()
        {
            string upperName = Utils.CapitalizeFirstLetter(Name);

            string routeCode = "// this file generated by shlmt/ServerGenerator\r\n" +
                "\r\n" + 
                "const express = require('express')\r\n" +
                "const router = express.Router()\r\n" +
                $"const {{getAll{upperName}s ,get{upperName}ById ,create{upperName} ,update{upperName} ,delete{upperName}}} = require('../controllers/{Name}Controller')\r\n" +
                "\r\n" +
                $"router.get('/', getAll{upperName}s)\r\n" +
                $"router.get('/:id', get{upperName}ById)\r\n" +
                "\r\n" +
                $"router.post('/', create{upperName})\r\n" +
                "\r\n" +
                $"router.put('/:id', update{upperName})\r\n" +
                "\r\n" +
                $"router.delete('/:id', delete{upperName})\r\n" +
                "\r\n" +
                "module.exports = router";

            return Utils.CreateFile(Path.Combine(ProjectInfo.RootDirectory, ProjectInfo.ProjectName, "routes", Name + "Route.js"), routeCode, "routes/" + Name + "Route.js");
        }
    }
}