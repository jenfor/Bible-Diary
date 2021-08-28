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
            MainPage = new SplashPage();
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
