using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppToDoTasks.Model;
using SQLite;
using Xamarin.Forms;

namespace AppToDoTasks.Service
{
    public class ToDoDatabase
    {
        private SQLiteConnection database;
        static object locker = new object();

        public ToDoDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<ToDoItem>();
        }

        public ToDoItem GetToDo(int id)
        {
            lock (locker)
            {
                return database.Table<ToDoItem>().FirstOrDefault(c => c.ID == id);
            }
        }

        public IEnumerable<ToDoItem> GetToDos()
        {
            lock (locker)
            {
                return (from c in database.Table<ToDoItem>() select c).ToList();
            }
        }

        public int SaveToDo(ToDoItem toDoItem)
        {
            lock (locker)
            {
                if (toDoItem.ID != 0)
                {
                    database.Update(toDoItem);
                    return toDoItem.ID;
                }
                else
                {
                    return database.Insert(toDoItem);
                }
            }
        }
    }
}
