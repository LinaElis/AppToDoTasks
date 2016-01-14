using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppToDoTasks.Service;
using AppToDoTasks.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace AppToDoTasks.Droid
{
    class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {}
            public SQLite.SQLiteConnection GetConnection()
            {

                var sqliteFilename = "AppToDoTasks.db";

                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);  

                var libraryPath = Path.Combine (documentsPath, sqliteFilename);
         
                var conn = new SQLite.SQLiteConnection(libraryPath);

                return conn;
            }
        }
    }

