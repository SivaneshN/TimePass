using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TimePass.ViewModels
{
	public class MasterPageViewModel : ViewModelBase
    {

        #region Commands

        private DelegateCommand<string> _menuItemTapped;
        public DelegateCommand<string> MenuItemTapped =>
                    _menuItemTapped ?? (_menuItemTapped = new DelegateCommand<string>(MenuItemLinkTappedMethodExecute)); 

        #endregion

        #region Constructor
        public MasterPageViewModel(INavigationService navigationService) : base (navigationService)
        {

        }
        #endregion

        public async void MenuItemLinkTappedMethodExecute(string pageName)
        {
            await NavigationService.NavigateAsync("NavigationPage/" + pageName);
        }
    }
}
