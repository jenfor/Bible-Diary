using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Bible_Diary.BibleDiary;
using Bible_Diary.Languages;
using Bible_Diary.Storage;
using System.IO;
using static Bible_Diary.Messages.NotificationClasses;
using Bible_Diary.Interfaces;

namespace Bible_Diary.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public static Language Language { get; set; } = new English();
        public Diary BibleDiary = new Diary(Language);
        public bool NewPage { get; set; }
        public bool UserHasSelectedPhoto { get; set; }

        public MainPageViewModel() 
        {
            ContinueBibleDiary = new Command(() =>
            {
                BibleDiary.PresentBibleDiaryPage.Header = Header;
                BibleDiary.PresentBibleDiaryPage.Image = Image;
                BibleDiary.PresentBibleDiaryPage.ImageSource = ImageSource;
                BibleDiary.PresentBibleDiaryPage.Vers = Vers;
                BibleDiary.PresentBibleDiaryPage.Comment = Comment;
                BibleDiary.PresentBibleDiaryPage.BibleLink = Link;
                BibleDiary.PresentBibleDiaryPage.UserHasSelectedPhoto = UserHasSelectedPhoto;

                NewPage = BibleDiary.ViewNextPage(Language);

                Header = BibleDiary.PresentBibleDiaryPage.Header;
                Image = BibleDiary.PresentBibleDiaryPage.Image;
                ImageSource = BibleDiary.PresentBibleDiaryPage.ImageSource;
                Vers = BibleDiary.PresentBibleDiaryPage.Vers;
                Placeholder = BibleDiary.PresentBibleDiaryPage.Palceholder;
                Comment = BibleDiary.PresentBibleDiaryPage.Comment;
                Link = BibleDiary.PresentBibleDiaryPage.BibleLink;
                UserHasSelectedPhoto = BibleDiary.PresentBibleDiaryPage.UserHasSelectedPhoto;
                BackButtonVisibility = true;

                MessagingCenter.Send(new NewPhotoMessage
                {
                    Title = "New photo",
                    ImageSource = BibleDiary.PresentBibleDiaryPage.ImageSource
                }, string.Empty) ;

            });

            ShareBibleDiary = new Command(() =>
            {
                ShareFuction();
            });

            Back = new Command(() =>
            {
                BibleDiary.PresentBibleDiaryPage.Header = Header;
                BibleDiary.PresentBibleDiaryPage.Image = Image;
                BibleDiary.PresentBibleDiaryPage.ImageSource = ImageSource;
                BibleDiary.PresentBibleDiaryPage.Vers = Vers;
                BibleDiary.PresentBibleDiaryPage.Comment = Comment;
                BibleDiary.PresentBibleDiaryPage.BibleLink = Link;
                BibleDiary.PresentBibleDiaryPage.UserHasSelectedPhoto = UserHasSelectedPhoto;


                if (BibleDiary.ViewPreviousPage())
                {
                    Header = BibleDiary.PresentBibleDiaryPage.Header;
                    Image = BibleDiary.PresentBibleDiaryPage.Image;
                    ImageSource = BibleDiary.PresentBibleDiaryPage.ImageSource;
                    Vers = BibleDiary.PresentBibleDiaryPage.Vers;
                    Placeholder = BibleDiary.PresentBibleDiaryPage.Palceholder;
                    Comment = BibleDiary.PresentBibleDiaryPage.Comment;
                    Link = BibleDiary.PresentBibleDiaryPage.BibleLink;
                    UserHasSelectedPhoto = BibleDiary.PresentBibleDiaryPage.UserHasSelectedPhoto;

                    BackButtonVisibility = true;

                    MessagingCenter.Send(new SetPhotoMessage
                    {
                        Title = "Set photo",
                        ImageSource = BibleDiary.PresentBibleDiaryPage.ImageSource
                    }, string.Empty);

                }
                else
                {
                    BackButtonVisibility = false;
                }
            });

            LinkClickCommand = new Command<string>((url) =>
            {
                Launcher.TryOpenAsync(new Uri(url));
            });
        }

        public Language GetLanguage() => Language;

        public void SetLanuguage(Language language)
        {
            Language = language;
            BibleDiaryStorage.SaveLanguage(language.LanguageName);
        }

        public void SaveDiary()
        {
            BibleDiary.SaveDiary();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Warning
        {
            get => Language.Warning;
        }

        public string Deletion
        {
            get => Language.Deletion;
        }

        public string Yes
        {
            get => Language.Yes;
        }

        public string No
        {
            get => Language.No;
        }

        private string _header = String.Empty;
        public string Header
        {
            get => _header;
            set
            {
                _header = value;

                var args = new PropertyChangedEventArgs(nameof(Header));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private string _vers = "Just as Moses lifted up the snake in the wilderness, so the Son of Man must be lifted up, that everyone who believes may have eternal life in him. For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life. 17For God did not send his Son into the world to condemn the world, but to save the world through him.";
        public string Vers
        {
            get => _vers;
            set
            {
                _vers = value;

                var args = new PropertyChangedEventArgs(nameof(Vers));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private string _image = "b2015.jpg";
        public string Image
        {
            get => _image;
            set
            {
                _image = value;

                var args = new PropertyChangedEventArgs(nameof(Image));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private string _imageSource;
        public string ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;

                var args = new PropertyChangedEventArgs(nameof(ImageSource));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private string _link = "https://www.bible.com/bible/111/JHN.3.NIV";
        public string Link
        {
            get => _link;
            set
            {
                _link = value;

                var args = new PropertyChangedEventArgs(nameof(Link));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private string _placeholder = String.Empty;
        public string Placeholder
        {
            get => _placeholder;
            set
            {
                _placeholder = value;

                var args = new PropertyChangedEventArgs(nameof(Placeholder));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public bool ShowImageRotated
        {
            get
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    return false;
                }
                else
                {
                     //return true;
                    return false;
                }
            }
        }

        private string _comment = String.Empty;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                var args = new PropertyChangedEventArgs(nameof(Comment));
                PropertyChanged?.Invoke(this, args);
                if(!String.IsNullOrEmpty(_comment) && BibleDiary != null && BibleDiary.PresentBibleDiaryPage != null)
                {
                    BibleDiary.PresentBibleDiaryPage.Comment = Comment;
                    SaveDiary();
                }
            }
        }

        private string _newBiblediary = Language.NewBibleDiary;
        public string NewBiblediary
        {
            get => _newBiblediary;
            set
            {
                _newBiblediary = value;

                var args = new PropertyChangedEventArgs(nameof(NewBiblediary));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private string _shareBiblediary = Language.ShareBibleDiary;
        public string ShareBiblediary
        {
            get => _shareBiblediary;
            set
            {
                _shareBiblediary = value;

                var args = new PropertyChangedEventArgs(nameof(ShareBiblediary));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private string _backBiblediary = Language.BackBibleDiary;
        public string BackBiblediary
        {
            get => _backBiblediary;
            set
            {
                _backBiblediary = value;

                var args = new PropertyChangedEventArgs(nameof(BackBiblediary));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private string _continueBiblediary = Language.ContinueBibleDiary;
        public string ContinueBiblediary
        {
            get => _continueBiblediary;
            set
            {
                _continueBiblediary = value;

                var args = new PropertyChangedEventArgs(nameof(ContinueBiblediary));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string StartImage
        {
            get
            {
                return BibleDiary.GetStartImage();
            }
        }

        private bool _backButtonVisibility = false;
        public bool BackButtonVisibility
        {
            get => _backButtonVisibility;
            set
            {
                _backButtonVisibility = value;

                var args = new PropertyChangedEventArgs(nameof(BackButtonVisibility));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command ContinueBibleDiary { get; }
        public Command Back { get; }
        public Command ShareBibleDiary { get; }
        public Command LinkClickCommand { get; }

        public void ShowBibleDiary()
        {
            BibleDiary = new Diary(Language);
            BibleDiary.GetDiary(Language);

            Header = BibleDiary.PresentBibleDiaryPage.Header;
            Vers = BibleDiary.PresentBibleDiaryPage.Vers;
            Image = BibleDiary.PresentBibleDiaryPage.Image;
            ImageSource = BibleDiary.PresentBibleDiaryPage.ImageSource;
            Placeholder = BibleDiary.PresentBibleDiaryPage.Palceholder;
            Comment = BibleDiary.PresentBibleDiaryPage.Comment;
            Link = BibleDiary.PresentBibleDiaryPage.BibleLink;
            UserHasSelectedPhoto = BibleDiary.PresentBibleDiaryPage.UserHasSelectedPhoto;

            if (BibleDiary.NrOfPages > 1)
            {
                BackButtonVisibility = true;
            }
        }

        private async void ShareFuction()
        {
            BibleDiary.PresentBibleDiaryPage.Header = Header;
            BibleDiary.PresentBibleDiaryPage.Image = Image;
            BibleDiary.PresentBibleDiaryPage.ImageSource = ImageSource;
            BibleDiary.PresentBibleDiaryPage.Vers = Vers;
            BibleDiary.PresentBibleDiaryPage.Comment = Comment;
            BibleDiary.PresentBibleDiaryPage.BibleLink = Link;
            BibleDiary.PresentBibleDiaryPage.UserHasSelectedPhoto = UserHasSelectedPhoto;
            if (BibleDiary.PresentBibleDiaryPage.ImageSource != null)
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    DependencyService.Get<IShare>().Share(" ", BibleDiary.GetPresentBibleDiaryPageAsString(Language), /*Xamarin.Forms.ImageSource.FromFile(*/BibleDiary.PresentBibleDiaryPage.ImageSource/*)*/);
                }
                else
                {
                    await ShareFile(BibleDiary.PresentBibleDiaryPage.ImageSource);
                    await ShareText(BibleDiary.GetPresentBibleDiaryPageAsString(Language));
                }
            }
            else
            {
                await ShareText(BibleDiary.GetPresentBibleDiaryPageAsString(Language));
            }
        }

        private async Task ShareText(string text)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "My Bible Diary"
            });
        }

        private async Task ShareFile(string filePath)
        {
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "My Bible Diary",
                File = new ShareFile(filePath)
            });
        }
    }
}
