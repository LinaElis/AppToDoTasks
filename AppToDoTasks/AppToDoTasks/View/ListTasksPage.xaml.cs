using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppToDoTasks.Model;
using Xamarin.Forms;

namespace AppToDoTasks.View
{
    public partial class ListTasksPage : ContentPage
    {
        public ListTasksPage()
        {
            InitializeComponent();
        }

        public void OnSelected(object o, ItemTappedEventArgs e)
        {
            var toDoItem = e.Item as ToDoItem;
            DisplayAlert("Task you have chosen", toDoItem.TaskName + " was selected!", "OK");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ToDoList.ItemsSource = App.Database.GetToDos();
        }
    }
}
