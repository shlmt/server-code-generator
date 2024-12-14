using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGenerator
{
    internal class Utils
    {

        public static void CreateFolder(string path)
        {
            Console.Write("create folder");
            Directory.CreateDirectory(path);
            Console.WriteLine(" successfully");
        }

        public static void CreateFile(string path, string content, string description)
        {
            Console.Write($"create {description}");
            File.WriteAllText(path, content);
            Console.WriteLine(" successfully");
        }

        public static void InstallPackages(string cli, string path, string packages)
        {
            Console.Write("install packages");
            if (cli == "npm")
            {
                RunNpmCommand(path, $"install {packages}");
                Console.WriteLine(" successfully");
            }
            else Console.WriteLine(" unsuccessfuly");
        }

        public static void RunNpmCommand(string directoryPath, string arguments)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C npm {arguments}",
                WorkingDirectory = directoryPath,
                CreateNoWindow = true,
                UseShellExecute = false
            };
            using (var process = Process.Start(processStartInfo))
            {
                process.WaitForExit();
            }
        }


    }
}
