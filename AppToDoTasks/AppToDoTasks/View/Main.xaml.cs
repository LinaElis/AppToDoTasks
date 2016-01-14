using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppToDoTasks.Model;
using AppToDoTasks.Service;
using AppToDoTasks.View;
using AppToDoTasks.ViewModel;
using Xamarin;
using Xamarin.Forms;

namespace AppToDoTasks.View
{

    public partial class Main : ContentPage
    {
        private CreatePageViewModel vm;
        private int updateID = 0;

        private WebAPI wa = new WebAPI();
        private string sentence = string.Empty;
        private string translation = string.Empty;

        public Main(int id)
        {
            vm = new CreatePageViewModel();
            BindingContext = vm;
            InitializeComponent();
            ToDoItem toDoItem = App.Database.GetToDo(id);
            ToDoEntry.Text = toDoItem.TaskName;
            Priority.Text = toDoItem.Priority;
            Date.Date = toDoItem.DueDate;
            Time.Time = toDoItem.DueDate.TimeOfDay;
            updateID = id;
        }

        public Main()
        {
            vm = new CreatePageViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        public void OnSave(object o, EventArgs e)
        {
            try
            {
              var handle = Insights.TrackTime("Time to save new task");
             
              handle.Start();

              vm.AddTask(
              ToDoEntry.Text,
              Priority.Text,
              Date.Date,
              Time.Time.Hours,
              Time.Time.Minutes,
              Time.Time.Seconds,
              updateID,
              false);

              handle.Stop();

                string savedString = "Your saved task was: " + ToDoEntry.Text;

                Insights.Track("Saved string", new Dictionary<string, string>
                {
                    { "The saved string", savedString }
                });

            }

            catch (Exception ex)
            {
                Insights.Report(ex, new Dictionary<string, string>
                {
                    { "Method name: ", "OnSave()" },
                    { "Where: ", "Main.xaml.cs" }
                });
            }

        }

        private void Clear()
        {
            ToDoEntry.Text = Priority.Text = string.Empty;
            Date.Date = DateTime.Now;
            Time.Time = new TimeSpan(
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second);
        }

        public void OnCancel(object o, EventArgs e)
        {   
            Clear();
        }

        public void OnSeeMyTasks(object o, EventArgs e)
        {
            Clear();
            Navigation.PushAsync(new ListTasksPage());
        }

        public void OnYodaSpeak(object o, EventArgs e)
        {
            sentence = ToDoEntry.Text;
            translation = wa.CreateTranslation(sentence);

            lblYoda.Text = translation;
        }
    }
}
