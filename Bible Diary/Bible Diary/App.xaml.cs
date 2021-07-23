using System;
using Bible_Diary.Languages;
using Bible_Diary.Storage;
using Bible_Diary.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bible_Diary
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var languageString = BibleDiaryStorage.GetLanguage();
            if (languageString.Equals("Swedish"))
            {
                var vm = new MainPageViewModel();
                vm.SetLanuguage(new Swedish());
                vm.ShowBibleDiary();
                MainPage = new MainPage { BindingContext = vm };
            }
            else if (languageString.Equals("English"))
            {
                var vm = new MainPageViewModel();
                vm.SetLanuguage(new English());
                vm.ShowBibleDiary();
                MainPage = new MainPage { BindingContext = vm };
            }
            else
            {
                MainPage = new NavigationPage(new StartPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
