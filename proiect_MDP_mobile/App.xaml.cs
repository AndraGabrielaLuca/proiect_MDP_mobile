using System;
using proiect_MDP_mobile.Data;
using System.IO;


namespace proiect_MDP_mobile;

public partial class App : Application
{
    static ItinerarDatabase database;
    public static ItinerarDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new ItinerarDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Itinerar.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
