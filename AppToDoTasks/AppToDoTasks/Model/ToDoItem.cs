using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppToDoTasks.Model
{
    public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string TaskName { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDeleted { get; set; }
    }


}
