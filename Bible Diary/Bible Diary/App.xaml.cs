using System;
using Bible_Diary.Storage;
using Bible_Diary.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bible_Diary
{
    public partial class App : Application
    {
        //private MainPage _mainPage;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            //var mainPageViewModel = _mainPage.BindingContext as MainPageViewModel;

            //if(mainPageViewModel != null)
            //{
            //    mainPageViewModel.SaveDiary();
            //}
        }

        protected override void OnResume()
        {
        }
    }
}
