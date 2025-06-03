using System;

public class MenuManager
{
    public string? currentSelection {get; private set;}
    private readonly PackageSearcher packageSearcher = PackageSearcher.Instance;
    
    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("---------Menu----------");
            Console.WriteLine("Enter package/program name");

            currentSelection = Console.ReadLine();
            
            packageSearcher.FindPackage(currentSelection);
            packageSearcher.DpkgSearch(currentSelection);
        }
    }
}