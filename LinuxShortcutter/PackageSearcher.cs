using System;
using System.Diagnostics;

public class PackageSearcher
{
    private static PackageSearcher? _instance; // Singleton instance
    private PackageSearcher() { } // Private constructor
    
    public static PackageSearcher Instance // public static method to get the _instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PackageSearcher();
            }
            return _instance;
        }
    }
    
    public void FindPackage(string currentSelection)
    {
        Console.WriteLine("FindPackage CurrentSelection: " + currentSelection);

        try
        {
            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash";
            process.StartInfo.Arguments = $"-c \"find / -iname '{currentSelection}' 2>/dev/null\"";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            
            process.Start();
            
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            
            if (string.IsNullOrEmpty(result))  { Console.WriteLine("find NO MATCHES"); }
            else { Console.WriteLine("find Search Results:\n" + result); }
        }
        
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
    
    public void DpkgSearch(string currentSelection)
    {
        Console.WriteLine("DpkgSearch PackageCurrentSelection: " + currentSelection);

        try
        {
            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash";
            process.StartInfo.Arguments = $"-c \"dpkg --list | grep -i '{currentSelection}'\"";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            
            if (string.IsNullOrEmpty(result))  { Console.WriteLine("DpkgSearch NO MATCHES"); }

            else{ Console.WriteLine("dpkg Search Results:\n" + result); }
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    
    
}