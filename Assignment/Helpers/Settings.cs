using Assignment.ViewModel;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

namespace Assignment
{
   
    public class Settings : BaseViewModel
    {
        public Settings(Page page = null) : base(null)
        {

        }

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        static Settings settings;
        public static Settings Current
        {
            get { return settings ?? (settings = new Settings()); }
        }

        #region Setting Constants

        private const string TotalWinKey = "totalwin_key";
        private static readonly string TotalWinDefault = "0";

        private const string TotalLossKey = "totalloss_key";
        private static readonly string TotalLossDefault = "0";

        #endregion

        public string TotalWins
        {
            get { return AppSettings.GetValueOrDefault<string>(TotalWinKey, TotalWinDefault); }
            set
            {
                if (AppSettings.AddOrUpdateValue<string>(TotalWinKey, value))
                    OnPropertyChanged(nameof(TotalWins));
            }
        }

        public string TotalLoss
        {
            get { return AppSettings.GetValueOrDefault<string>(TotalLossKey, TotalLossDefault); }
            set
            {
                if (AppSettings.AddOrUpdateValue<string>(TotalLossKey, value))
                    OnPropertyChanged(nameof(TotalLoss));
            }
        }
        
    }
}