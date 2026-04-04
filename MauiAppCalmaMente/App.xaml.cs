using MauiAppCalmaMente.Services;
using Microsoft.Maui.Controls;

namespace MauiAppCalmaMente;

public partial class App : Application
{
    public static DatabaseService Database { get; private set; }

    public App()
    {
        InitializeComponent();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "calmamente.db");
        Database = new DatabaseService(dbPath);

        MainPage = new AppShell();
    }
}