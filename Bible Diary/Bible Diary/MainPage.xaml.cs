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
                try
                { 
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

                }
                catch (Exception e)
                { }

                PrivateImage.Source = null;
            }
            else
            {
                PrivateImage.Source = ImageSource.FromFile(_vm?.BibleDiary?.PresentBibleDiaryPage?.ImageSource);
            }

        }

        void EditorFocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                scrollView.SetValue(Grid.RowProperty, 0);

                scrollView.SetValue(Grid.RowSpanProperty, 3);

                scrollView.ScrollToAsync(editor.AnchorX, editor.AnchorY, true);
                btnNewBiblediary.IsVisible = false;
                btnShare.IsVisible = false;
                header.IsVisible = false;
            }
        }

        void EditorUnfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            scrollView.SetValue(Grid.RowProperty, 4);
            scrollView.SetValue(Grid.RowSpanProperty, 1);
            btnNewBiblediary.IsVisible = true;
            btnShare.IsVisible = true;
            header.IsVisible = true;
        }
    }
}