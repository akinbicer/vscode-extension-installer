using VsCodeExtension.Helpers;

namespace VsCodeExtension;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Please enter the path to the extensions JSON file:");
            var jsonFilePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(jsonFilePath) || !File.Exists(jsonFilePath))
            {
                Console.WriteLine("Invalid file path or file does not exist.");
                return;
            }

            ExtensionHelper.InstallExtensions(jsonFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
    }
}