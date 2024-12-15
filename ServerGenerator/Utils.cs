
using System.Diagnostics;
using System.Net.Http.Headers;

namespace ServerGenerator
{
    internal class Utils
    {
        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            return char.ToUpper(input[0]) + input.Substring(1);
        }

        public static bool CreateFolder(string path, string desc)
        {
            try
            {
                Console.Write("create folder "+desc);
                Directory.CreateDirectory(path);
                Console.WriteLine(" successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" unsuccessfully, Error: {ex.Message}");
                return false;
            }

        }

        public static bool CreateFile(string path, string content, string description)
        {
            try
            {
                Console.Write($"create {description}");
                File.WriteAllText(path, content);
                Console.WriteLine(" successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" unsuccessfully, Error: {ex.Message}");
                return false;
            }
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
