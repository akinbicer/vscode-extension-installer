using System.Diagnostics;
using Newtonsoft.Json;
using VsCodeExtension.Models;

namespace VsCodeExtension.Helpers;

public class ExtensionHelper
{
    public static void InstallExtensions(string jsonFilePath)
    {
        var jsonText = File.ReadAllText(jsonFilePath);
        var extensions = JsonConvert.DeserializeObject<List<Extension>>(jsonText);

        if (extensions == null)
        {
            Console.WriteLine("No extensions found in the JSON file.");
            return;
        }

        foreach (var extension in extensions) InstallExtension(extension);
    }

    public static void InstallExtension(Extension extension)
    {
        try
        {
            Console.WriteLine($"Installing extension: {extension.Identifier?.Id}");

            var processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c code --install-extension {extension.Identifier?.Id} --force",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();

            var output = process.StandardOutput.ReadToEnd();

            Console.WriteLine(new string('=', 20));
            Console.WriteLine($"Output: {output}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error installing extension {extension.Identifier?.Id}: {ex.Message}");
        }
    }
}