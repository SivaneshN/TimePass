using Prism;
using Prism.Ioc;
using TimePass.ViewModels;
using TimePass.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using TimePass.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TimePass
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MasterPage/NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            //containerRegistry.Register(typeof(ISpeechToText));

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<Torch, TorchViewModel>();
            containerRegistry.RegisterForNavigation<MasterPage, MasterPageViewModel>();
            containerRegistry.RegisterForNavigation<Notes, NotesViewModel>();
            containerRegistry.RegisterForNavigation<Share, ShareViewModel>();
            containerRegistry.RegisterForNavigation<Barometer, BarometerViewModel>();
            containerRegistry.RegisterForNavigation<Motion, MotionViewModel>();
        }

        protected override void OnStart()
        {
            base.OnStart();
            AppCenter.Start("7af1ace3-c5fd-4f28-acf3-21cc257ca634", typeof(Push));
        }

    }
}
