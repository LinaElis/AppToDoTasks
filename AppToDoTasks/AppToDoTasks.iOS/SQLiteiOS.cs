using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AppToDoTasks.Service;
using AppToDoTasks.iOS;
using SQLite;

//[assembly:Xamarin.Forms.Dependency(typeof(SQLiteiOS))]
namespace AppToDoTasks.iOS
{
    //public class SQLiteiOS : ISQLite
    //{
    //    public SQLite.SQLiteConnection GetConnection()
    //    {
    //        //path for iOS here
    //        //var sqliteFilename  = "AppToDoTasks.db"
    //        //string documentsPath = Enviroment.GetFolderPath (
    //        //Enviroment.SpecialFolder.Personal );
    //        //string libraryPath = Path.Combine (
    //        //documentsPath, "..", "Library" );
    //        //var path = Path.Combine (libraryPath, 
    //            //sqliteFilename );
    //        var path = "/users/Lina/Documents/Visual Studio 2015/Projects/Inlamning/AppToDoTasksDBTest";
    //        File.Open(path, FileMode.OpenOrCreate);
    //        var conn = new SQLite.SQLiteConnection(path);
    //        return conn;
    //    }
    //}
}
