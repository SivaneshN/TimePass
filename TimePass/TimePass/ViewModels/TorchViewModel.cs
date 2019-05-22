using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace TimePass.ViewModels
{
	public class TorchViewModel : ViewModelBase
	{
        


        #region Commands

        private DelegateCommand<string> _toggleTorch;
        public DelegateCommand<string> ToggleTorch =>
                    _toggleTorch ?? (_toggleTorch = new DelegateCommand<string>(ToggleTorchMethodExecute));

        #endregion

        #region Constructor
        public TorchViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Torch Page";
            TorchStatus = "off";
            ToggleTorchMethodExecute(TorchStatus);
        }
        #endregion

        

    }
}
