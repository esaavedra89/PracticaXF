using System.IO;
using PracticaXF.Droid.Implementaciones;
using PracticaXF.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseDatosAndroid))]
namespace PracticaXF.Droid.Implementaciones
{
    public class BaseDatosAndroid 
    //public class BaseDatosAndroid : BaseDatosI
    {
    //    public BaseDatosAndroid()
    //    {

    //    }
    //    public SQLite.SQLiteConnection GetConnection()
    //    {
    //        var sqliteFileName = "TestBD.db3";
    //        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
    //        var path = Path.Combine(documentsPath, sqliteFileName);
    //        var conn = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex, true);

    //        return conn;
    //    }
    }
}