using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AplicatieProiect.Data;
namespace AplicatieProiect.Models;
using System;
using System.Diagnostics; // Adaugă această linie pentru a utiliza System.Diagnostics

class Program
{
    static void Main()
    {
        // Restul codului programului
        string link = "https://www.exemplu.com";
        OpenWebPage(link);
    }

    static void OpenWebPage(string url)
    {
        try
        {
            // Utilizează clasa Process din System.Diagnostics pentru a deschide browserul web
            Process.Start(url);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A apărut o eroare: {ex.Message}");
        }
    }
}

