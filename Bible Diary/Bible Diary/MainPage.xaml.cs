using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bible_Diary.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using static Bible_Diary.Messages.NotificationClasses;

namespace Bible_Diary
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _vm;
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _vm = vm;

            MessagingCenter.Subscribe<NewPhotoMessage>(this, string.Empty, message =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await PickNewPhoto();
                });
            });

            MessagingCenter.Subscribe<SetPhotoMessage>(this, string.Empty, message =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    SetPhoto(message.ImageSource);
                });
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _vm.SaveDiary();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (_vm?.BibleDiary?.PresentBibleDiaryPage?.ImageSource == null && !_vm.UserHasSelectedPhoto)
            {
                await PickNewPhoto();
            }
        }

        private async void BackTapped(object sender, System.EventArgs e)
        {
            var action = await DisplayAlert(_vm.Warning, _vm.Deletion, _vm.Yes, _vm.No);
            if (action)
            {
                _vm.BibleDiary.DeleteBibleDiary();
                try
                {
                    await Navigation.PushAsync(new StartPage(_vm), true);
                }
                catch(Exception ex)
                { }
            }
        }

        private void SetPhoto(string imageSource)
        {
            if (imageSource != null)
            {
                PrivateImage.Source = ImageSource.FromFile(imageSource);
                //PrivateImage.Source = ImageSource.FromFile("/var/mobile/Containers/Data/Application/DEE2BD6D-7E39-4CB6-BB1B-F118BF89D380/Documents/temp/IMG_1630159607221.jpg");
            }
            else
            {
                PrivateImage.Source = null;
            }
        }

        private async Task PickNewPhoto()
        {

            if (_vm?.BibleDiary?.PresentBibleDiaryPage?.ImageSource == null && !_vm.UserHasSelectedPhoto)
            {
                _vm.UserHasSelectedPhoto = true;
                var action = await DisplayAlert(_vm.GetLanguage()?.PickPhoto, String.Empty, _vm.Yes, _vm.No).ConfigureAwait(true);

                if (action)
                {
                    await CrossMedia.Current.Initialize();
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                        return;
                    }
                    var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                    {
                        PhotoSize = PhotoSize.Full,
                        SaveMetaData = true
                    });

                    if (file?.Path != null && _vm?.BibleDiary?.PresentBibleDiaryPage != null)
                    {
                        _vm.BibleDiary.PresentBibleDiaryPage.ImageSource = file.Path;
                        _vm.ImageSource = file.Path;
                        PrivateImage.Source = ImageSource.FromFile(file.Path);
                        return;
                    }
                }

                PrivateImage.Source = null;
            }
            else
            {
                PrivateImage.Source = _vm?.BibleDiary?.PresentBibleDiaryPage?.ImageSource;
            }
        }
    }
}