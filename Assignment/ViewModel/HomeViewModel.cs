using Assignment.View;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

namespace Assignment.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {

        public Double Progress { get; set; }
        public string TotalMatches { get; set; }
        public HomeViewModel(Page page) : base(page)
        {
           // page.Navigation.SetHasNavigationBar(this, false);

        }

        public void ShowProgress(Double progress)
        {
            bool shouldRepeat = true;
            Double i = 0.0;
            Device.StartTimer(TimeSpan.FromMinutes(0.0001), () => {

                if (i > progress)
                {
                    shouldRepeat = false;
                    return shouldRepeat;
                }

                this.Progress = i;
                OnPropertyChanged(nameof(Progress));
                i += 0.01;

                return shouldRepeat;
            });
        }
        public void ShowTotalMatches(int matches)
        {
            bool shouldRepeat = true;

        int i = 0;
        Device.StartTimer(TimeSpan.FromMinutes(0.0001), () => {

            if(i > matches){
             shouldRepeat = false;
                return shouldRepeat;

            }

            this.TotalMatches = i.ToString() + " Matches";
            OnPropertyChanged(nameof(TotalMatches));
            i++;
                
                return shouldRepeat;
            });
           
        }

        Command playGameCommand;
        public Command PlayGameCommand
        {
            get
            {
                return playGameCommand ??
                    (playGameCommand = new Command(async () => await StartGame()));
            }
        }

        async Task StartGame()
        {
            
            await Page.Navigation.PushAsync(new GamePage());
        }

    }
}
