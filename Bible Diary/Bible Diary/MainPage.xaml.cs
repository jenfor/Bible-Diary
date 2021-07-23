using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bible_Diary.Interfaces;
using Bible_Diary.ViewModels;
using Xamarin.Forms;

namespace Bible_Diary
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _vm;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (BindingContext != null && BindingContext is MainPageViewModel)
            {
                _vm = BindingContext as MainPageViewModel;
            }
            else
            {
                BindingContext = _vm = new MainPageViewModel();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _vm.SaveDiary();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    //_vm.Init();
        //}

        private async void BackTapped(object sender, System.EventArgs e)
        {
            var action = await DisplayAlert(_vm.Warning, _vm.Deletion, _vm.Yes, _vm.No);
            if (action)
            {
                _vm.BibleDiary.DeleteBibleDiary();
                try
                {
                    // ToDo: Check if StartPage already exits
                    await Navigation.PushAsync(new StartPage { BindingContext = _vm }, true);
                }
                catch(Exception ex)
                { }
            }
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            //ToDo:  Fix somthing better than this: if (_vm.NewPage)
            {
                // ToDo: Message to user about why to pick an image/ if the user whants to pick a picture

                (sender as Button).IsEnabled = false;

                Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
                if (stream != null)
                {
                    Image.Source = ImageSource.FromStream(() => stream);
                }

                (sender as Button).IsEnabled = true;
            }

        }
    }
}