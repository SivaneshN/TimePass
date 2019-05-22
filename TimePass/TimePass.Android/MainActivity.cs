using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Speech;
using Plugin.CurrentActivity;
using Prism;
using Prism.Ioc;
using TimePass.Services;
using Xamarin.Forms;

namespace TimePass.Droid
{
    [Activity(Label = "TimePass", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IMessageSender
    {
        private readonly int VOICE = 10;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Xamarin.Essentials.Platform.Init(this, bundle);

            base.OnCreate(bundle);

            //CreateNotificationChannel();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {

            if (requestCode == VOICE)
            {
                if (resultCode == Result.Ok)
                {
                    var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                    if (matches.Count != 0)
                    {
                        string textInput = matches[0];
                        MessagingCenter.Send<IMessageSender, string>(this, "STT", textInput);
                    }
                    else
                    {
                        MessagingCenter.Send<IMessageSender, string>(this, "STT", "No input");
                    }

                }
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }
    

    //void CreateNotificationChannel()
    //{
    //    if (Build.VERSION.SdkInt < BuildVersionCodes.O)
    //    {
    //        // Notification channels are new in API 26 (and not a part of the
    //        // support library). There is no need to create a notification
    //        // channel on older versions of Android.
    //        return;
    //    }

    //    var channelName = Resources.GetString(Resource.String.channel_name);
    //    var channelDescription = GetString(Resource.String.channel_description);
    //    var channel = new NotificationChannel(CHANNEL_ID, channelName, NotificationImportance.Default)
    //    {
    //        Description = channelDescription
    //    };

    //    var notificationManager = (NotificationManager)GetSystemService(NotificationService);
    //    notificationManager.CreateNotificationChannel(channel);
    //}
}

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

