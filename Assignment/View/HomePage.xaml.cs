using Assignment.ViewModel;
using System;
using Xamarin.Forms;

namespace Assignment
{
    public partial class HomePage : ContentPage
    {
        public HomeViewModel vm;

        public HomePage()
        {
            InitializeComponent();
            vm = new HomeViewModel(this);
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = vm;
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //your code here;
            if (int.Parse(Settings.Current.TotalWins) == 0)
            {
                vm.ShowProgress(0);
                vm.ShowTotalMatches(0);
            }
            else {
                vm.ShowTotalMatches(int.Parse(Settings.Current.TotalWins));
                vm.ShowProgress(double.Parse(Settings.Current.TotalWins)/ (double.Parse(Settings.Current.TotalWins) + int.Parse(Settings.Current.TotalLoss)));
            }
           

        }
    }
}