using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace TimePass.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _torchStatus;
        public string TorchStatus
        {
            get { return _torchStatus; }
            set { SetProperty(ref _torchStatus, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public async void ToggleTorchMethodExecute(string currentTorchStatus)
        {
            try
            {
                if (currentTorchStatus == "off")
                {
                    TorchStatus = "on";
                    await Flashlight.TurnOnAsync();
                }
                else
                {
                    TorchStatus = "off";
                    await Flashlight.TurnOffAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
