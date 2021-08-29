using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Bible_Diary.Languages;
using Bible_Diary.ViewModels;
using Xamarin.Forms;

namespace Bible_Diary
{
    public partial class StartPage : ContentPage
    {
        private MainPageViewModel _vm;
        public StartPage(MainPageViewModel vm)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _vm = vm;
        }

        public StartPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _vm = new MainPageViewModel();
        }

        private async void EnglishBibleDiaryClicked(System.Object sender, System.EventArgs e)
        {
            (sender as Button).IsEnabled = false;
            await NewBibleDiary(new English()).ConfigureAwait(true);
            (sender as Button).IsEnabled = true;
        }

        private async void SwedishBibleDiaryClicked(System.Object sender, System.EventArgs e)
        {
            (sender as Button).IsEnabled = false;
            await NewBibleDiary(new Swedish()).ConfigureAwait(true);
            (sender as Button).IsEnabled = true;
        }

        private async Task NewBibleDiary(Language language)
        {
            _vm.SetLanuguage(language);
            _vm.ShowBibleDiary();
            await Navigation.PushAsync(new MainPage(_vm), true).ConfigureAwait(true);

        }
    }
}
