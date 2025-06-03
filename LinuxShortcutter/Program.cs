// See https://aka.ms/new-console-template for more information
using System;
    public class Program // Awake();
    {
        static void Main() // Main() occurs at program startup // 1st method run // stati
        {
            Console.WriteLine("Welcome to an example krint.dev terminal Script using C#");
            
            // Start an instance of menuManager
            MenuManager menuManager = new MenuManager();
            menuManager.Menu();
        }
    }