using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using TimePass.Services;
using Xamarin.Forms;

namespace TimePass.ViewModels
{
	public class ShareViewModel : BindableBase
	{
        private readonly ISpeechToText _speechRecongnitionInstance;
        private string _showSpokenText;

        private DelegateCommand _speechButtonCommand;
        public DelegateCommand SpeechButtonCommand =>
       _speechButtonCommand ?? (_speechButtonCommand = new DelegateCommand(SpeechCommandExecute));

        public string ShowSpokenText
        {
            get { return _showSpokenText; }
            set { SetProperty(ref _showSpokenText, value); }
        }
        //public ShareViewModel(ISpeechToText speechRecongnitionInstance)
        //{
        //    ShowSpokenText = "Start";
        //    try
        //    {
        //        _speechRecongnitionInstance = speechRecongnitionInstance;
        //        //_speechRecongnitionInstance = DependencyService.Get<ISpeechToText>();
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowSpokenText = ex.Message;
        //    }


        //    MessagingCenter.Subscribe<ISpeechToText, string>(this, "STT", (sender, args) =>
        //    {
        //        SpeechToTextFinalResultRecieved(args);
        //    });

        //    MessagingCenter.Subscribe<ISpeechToText>(this, "Final", (sender) =>
        //    {
        //        //start.IsEnabled = true;
        //    });

        //    MessagingCenter.Subscribe<IMessageSender, string>(this, "STT", (sender, args) =>
        //    {
        //        SpeechToTextFinalResultRecieved(args);
        //    });
        //}

        public ShareViewModel()
        {

        }


        private void SpeechToTextFinalResultRecieved(string args)
        {
            ShowSpokenText = args;
        }

        public void SpeechCommandExecute()
        {
            try
            {
                _speechRecongnitionInstance.StartSpeechToText();
            }
            catch (Exception ex)
            {
                ShowSpokenText = ex.Message;
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                //start.IsEnabled = false;
            }
        }
    }
}
