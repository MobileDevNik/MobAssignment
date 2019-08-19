using Assignment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment.View
{
    
    public partial class GamePage : ContentPage
    {
        public GameViewModel vm;
        public GamePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            vm = new GameViewModel(this);
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //your code here;
            vm.ShowResult(false);
            Device.StartTimer(TimeSpan.FromMinutes(0.1), () =>
            {
                if (vm.Moves == 0)
                {
                    vm.InitiateAIPlayer();
                }
                return false;
            });

        }
    }
}