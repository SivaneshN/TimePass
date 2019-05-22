using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace TimePass.ViewModels
{
	public class NotesViewModel : ViewModelBase
	{

        #region Commands

        private DelegateCommand _sendNotification;
        public DelegateCommand SendNotification =>
                    _sendNotification ?? (_sendNotification = new DelegateCommand(SendNotificationMethodExecute));

        #endregion

        #region Constructor

        public NotesViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }

        #endregion

        public void SendNotificationMethodExecute()
        {
            
        }

    }
}
