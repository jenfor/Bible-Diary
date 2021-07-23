using System;
using System.Collections.Generic;
using Bible_Diary.Languages;
using Bible_Diary.ViewModels;
using Xamarin.Forms;

namespace Bible_Diary
{
    public partial class StartPage : ContentPage
    {
        private MainPageViewModel _vm;
        public StartPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _vm = new MainPageViewModel();
        }

        private async void EnglishBibleDiaryClicked(System.Object sender, System.EventArgs e)
        {
            _vm.SetLanuguage(new English());
            _vm.ShowBibleDiary();
            await Navigation.PushAsync(new NavigationPage(new MainPage { BindingContext = _vm}), true);
        }

        private async void SwedishBibleDiaryClicked(System.Object sender, System.EventArgs e)
        {
            _vm.SetLanuguage(new Swedish());
            _vm.ShowBibleDiary();
            await Navigation.PushAsync(new NavigationPage(new MainPage { BindingContext = _vm }), true);
        }
    }
}
