using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bible_Diary.Languages;
using Bible_Diary.Storage;
using Bible_Diary.ViewModels;
using Xamarin.Forms;

namespace Bible_Diary
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            base.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                var languageString = BibleDiaryStorage.GetLanguage();
                if (languageString.Equals("Swedish"))
                {
                    var vm = new MainPageViewModel();
                    vm.SetLanuguage(new Swedish());
                    vm.ShowBibleDiary();
                    App.Current.MainPage = new NavigationPage(new MainPage(vm));
                }
                else if (languageString.Equals("English"))
                {
                    var vm = new MainPageViewModel();
                    vm.SetLanuguage(new English());
                    vm.ShowBibleDiary();
                    App.Current.MainPage = new NavigationPage(new MainPage(vm));
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new StartPage());
                }
            });
        }
    }
}
