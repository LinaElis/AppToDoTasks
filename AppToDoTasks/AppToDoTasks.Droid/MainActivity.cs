using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin;

namespace AppToDoTasks.Droid
{
    [Activity(Label = "AppToDoTasks", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Insights.HasPendingCrashReport += (sender, isStartUpCrash) =>
            {
                if (isStartUpCrash)
                {
                    Insights.PurgePendingCrashReports().Wait();
                }
            };

            Insights.Initialize("d8cab994e1e4126f4c950fb592392ac59fc74ac0", ApplicationContext);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

