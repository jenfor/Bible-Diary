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

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (_vm.BibleDiary.PresentBibleDiaryPage.ImageSource == null)
            {
                await DisplayAlert(_vm.GetLanguage()?.PickPhoto, String.Empty, "Ok").ConfigureAwait(true);

                var dictionary = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
                var keyValuePair = dictionary.FirstOrDefault();
                var stream = keyValuePair.Value;
                var path = keyValuePair.Key;
                //Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
                if (stream != null)
                {
                    PrivateImage.Source = ImageSource.FromStream(() => stream);
                    //PrivateImage.Source = ImageSource.FromFile(path);
                    //PrivateImage.Source = ImageSource.FromUri(new Uri(path));

                    //_vm.BibleDiary.PresentBibleDiaryPage.ImageSource = path;
                    //_vm.ImageSource = path;
                    var test =DependencyService.Get<IPhotoPickerService>().SavePicture("test Gunnebo 21 august 21", stream);

                    //var test = DependencyService.Get<IPhotoPickerService>().SavePicture(DateTime.Now.ToString(), stream);

                    _vm.BibleDiary.PresentBibleDiaryPage.ImageSource = test;
                    _vm.ImageSource = test;
                }
            }
            else
            {
                PrivateImage.Source = ImageSource.FromFile(_vm.BibleDiary.PresentBibleDiaryPage.ImageSource);
            }
            //_vm.Init();
        }

        private async void BackTapped(object sender, System.EventArgs e)
        {
            var action = await DisplayAlert(_vm.Warning, _vm.Deletion, _vm.Yes, _vm.No);
            if (action)
            {
                _vm.BibleDiary.DeleteBibleDiary();
                try
                {
                    //if (Navigation.NavigationStack.Any(p => p is MainPage))
                    //{
                    //    await Navigation.PopAsync();
                    //}
                    //else
                    {
                        await Navigation.PushAsync(new StartPage { BindingContext = _vm }, true);
                    }
                }
                catch(Exception ex)
                { }
            }
        }

        void OnPreviousPageClicked(object sender, EventArgs e)
        {
            if (_vm?.BibleDiary?.PresentBibleDiaryPage?.ImageSource != null)
            {
                PrivateImage.Source = ImageSource.FromFile(_vm?.BibleDiary?.PresentBibleDiaryPage?.ImageSource);
                //PrivateImage.Source = ImageSource.FromFile("/private/var/mobile/Containers/Data/Application/D0E20729-A7C4-4593-92DB-2556989F9DF7/tmp/370B3FAC-7040-41A3-8329-2B21DB1CD642.jpeg");// _vm.BibleDiary.PresentBibleDiaryPage.ImageSource);
            }                                           //"/private/var/mobile/Containers/Data/Application/7C924167-9C1E-4641-AB86-15C5B4D7F8EA/tmp/0514DB42-8B54-4338-B259-8F3E756EDA06.jpeg"
        }                                               //"/private/var/mobile/Containers/Data/Application/68F5B31F-3DB6-49B6-8284-0E8D5CE63091/tmp/0C9C6E3E-8BBB-4953-A2FC-20AD81C616EC.jpeg"
                                                        //"/private/var/mobile/Containers/Data/Application/BFAE0CD4-D0DF-44C5-B0B8-0308B67504E1/tmp/E210BE35-4688-419D-8ECB-B796423A7732.jpeg"
        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            //if (_vm.ContinueBibleDiary.CanExecute(null))
            //{
            //    _vm.ContinueBibleDiary.Execute(null);
            //}

            if (_vm?.BibleDiary?.PresentBibleDiaryPage?.ImageSource == null)
            {
                await DisplayAlert(_vm.GetLanguage()?.PickPhoto, String.Empty, "Ok").ConfigureAwait(true);

                (sender as Button).IsEnabled = false;

                var dictionary = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
                var keyValuePair = dictionary.FirstOrDefault();
                var stream = keyValuePair.Value;
                var path = keyValuePair.Key;

                //Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
                if (stream != null)
                {
                    //PrivateImage.Source = ImageSource.FromStream(() => stream);
                    PrivateImage.Source = ImageSource.FromFile(path);

                    //_vm.BibleDiary.PresentBibleDiaryPage.ImageSource = path;
                    //_vm.ImageSource = path;

                    var test = DependencyService.Get<IPhotoPickerService>().SavePicture(DateTime.Now.ToString(), stream);

                    _vm.BibleDiary.PresentBibleDiaryPage.ImageSource = test;
                    _vm.ImageSource = test;
                }

                (sender as Button).IsEnabled = true;
            }
            else
            {
                PrivateImage.Source = ImageSource.FromFile(_vm.BibleDiary.PresentBibleDiaryPage.ImageSource);

                //PrivateImage.Source = ImageSource.FromFile("//data//user//0//com.companyname.bible_diary//files//Orders//temp//test Gunnebo 21 august 21");
            }
        }
    }
}