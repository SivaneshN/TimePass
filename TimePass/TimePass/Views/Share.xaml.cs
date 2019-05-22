using System;
using TimePass.Services;
using Xamarin.Forms;

namespace TimePass.Views
{
    public partial class Share : ContentPage
    {
        private ISpeechToText _speechRecongnitionInstance;
        public Share()
        {
            InitializeComponent();
            try
            {
                _speechRecongnitionInstance = DependencyService.Get<ISpeechToText>();
            }
            catch (Exception ex)
            {
                recon.Text = ex.Message;
            }


            MessagingCenter.Subscribe<ISpeechToText, string>(this, "STT", (sender, args) =>
            {
                SpeechToTextFinalResultRecieved(args);
            });

            MessagingCenter.Subscribe<ISpeechToText>(this, "Final", (sender) =>
            {
                start.IsEnabled = true;
            });

            MessagingCenter.Subscribe<IMessageSender, string>(this, "STT", (sender, args) =>
            {
                SpeechToTextFinalResultRecieved(args);
            });
        }

        private void SpeechToTextFinalResultRecieved(string args)
        {
            recon.Text = args;
        }

        private void Start_Clicked(object sender, EventArgs e)
        {
            try
            {
                _speechRecongnitionInstance.StartSpeechToText();
            }
            catch (Exception ex)
            {
                recon.Text = ex.Message;
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                start.IsEnabled = false;
            }



        }
    }
}
