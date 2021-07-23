using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Bible_Diary.BibleDiary;
using Bible_Diary.Languages;
using Bible_Diary.Storage;

namespace Bible_Diary.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public static Language Language { get; set; } = new English();
        public Diary BibleDiary = new Diary(Language);

        public MainPageViewModel() 
        {
            //SwedishBibleDiary = new Command(() =>
            //{
            //    Language = new Swedish();
            //    BibleDiaryStorage.SaveLanguage("Swedish");
            //    ShowBibleDiary();
            //    //SetButtonVisibilitys();
            //});

            //EnglishBibleDiary = new Command(() =>
            //{
            //    Language = new English();
            //    BibleDiaryStorage.SaveLanguage("English");
            //    ShowBibleDiary();
            //    //SetButtonVisibilitys();
            //});

            //NewBibleDiary = new Command(/*async*/ () =>
            //{
            //    //await CreateNewBibleDiary(Language);
            //});

            ContinueBibleDiary = new Command(() =>
            {
                BibleDiary.PresentBibleDiaryPage.Header = Header;
                BibleDiary.PresentBibleDiaryPage.Image = Image;
                BibleDiary.PresentBibleDiaryPage.Vers = Vers;
                BibleDiary.PresentBibleDiaryPage.Comment = Comment;
                BibleDiary.PresentBibleDiaryPage.BibleLink = Link;

                BibleDiary.ViewNextPage(Language);

                Header = BibleDiary.PresentBibleDiaryPage.Header;
                Image = BibleDiary.PresentBibleDiaryPage.Image;
                Vers = BibleDiary.PresentBibleDiaryPage.Vers;
                Placeholder = BibleDiary.PresentBibleDiaryPage.Palceholder;
                Comment = BibleDiary.PresentBibleDiaryPage.Comment;
                Link = BibleDiary.PresentBibleDiaryPage.BibleLink;

                BackButtonVisibility = true;

                //SetButtonVisibilitys();
            });

            ShareBibleDiary = new Command(() =>
            {
                ShareFuction();
            });

            Back = new Command(() =>
            {
                BibleDiary.PresentBibleDiaryPage.Header = Header;
                BibleDiary.PresentBibleDiaryPage.Image = Image;
                BibleDiary.PresentBibleDiaryPage.Vers = Vers;
                BibleDiary.PresentBibleDiaryPage.Comment = Comment;
                BibleDiary.PresentBibleDiaryPage.BibleLink = Link;
                
                if (BibleDiary.ViewPreviousPage())
                {
                    Header = BibleDiary.PresentBibleDiaryPage.Header;
                    Image = BibleDiary.PresentBibleDiaryPage.Image;
                    Vers = BibleDiary.PresentBibleDiaryPage.Vers;
                    Placeholder = BibleDiary.PresentBibleDiaryPage.Palceholder;
                    Comment = BibleDiary.PresentBibleDiaryPage.Comment;
                    Link = BibleDiary.PresentBibleDiaryPage.BibleLink;

                    BackButtonVisibility = true;


                    //SetButtonVisibilitys();
                }
                else
                {
                    BackButtonVisibility = false;
                    //BackToStartPage(Language);
                }
            });

            LinkClickCommand = new Command<string>((url) =>
            {
                Launcher.TryOpenAsync(new Uri(url));
            });
        }

        public void SetLanuguage(Language language)
        {
            Language = language;
        }

        public void Init()
        {
            //var languageString = BibleDiaryStorage.GetLanguage();
            //if(languageString.Equals("Swedish"))
            //{
            //    language = new Swedish();
            //    ShowBibleDiary(language);
            //    SetButtonVisibilitys();
            //}
            //else if(languageString.Equals("English"))
            //{
            //    language = new English();
            //    ShowBibleDiary(language);
            //    SetButtonVisibilitys();
            //}

        }

        public void SaveDiary()
        {
            BibleDiary.SaveDiary();
        }

        //public void BackToStartPage(Language language)
        //{
        //    StartColumnWidth = new GridLength(1, GridUnitType.Star);
        //    BibleDiaryColumnWidth1 = new GridLength(0);
        //    BibleDiaryColumnWidth2 = new GridLength(0);

        //    StartButtonVisibility = true;
        //}

        //public async Task CreateNewBibleDiary(Language language)
        //{
        //    //var action = await App.Current.MainPage.DisplayAlert(language.Warning, language.Deletion, language.Yes, language.No);
        //    //if (action)
        //    //{
        //    //    //ShowStartPage();
                
        //    //    bibleDiary.DeleteBibleDiary();
        //    //}
        //}

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

        //private bool _startButtonVisibility = true;
        //public bool StartButtonVisibility
        //{
        //    get => _startButtonVisibility;
        //    set
        //    {
        //        _startButtonVisibility = value;

        //        var args = new PropertyChangedEventArgs(nameof(StartButtonVisibility));
        //        PropertyChanged?.Invoke(this, args);
        //    }
        //}

        //private GridLength _startColumnWidth = new GridLength(1, GridUnitType.Star);
        //public GridLength StartColumnWidth
        //{
        //    get => _startColumnWidth;
        //    set
        //    {
        //        _startColumnWidth = value;

        //        var args = new PropertyChangedEventArgs(nameof(StartColumnWidth));
        //        PropertyChanged?.Invoke(this, args);
        //    }
        //}

        //private GridLength _bibleDiaryColumnWidth1 = new GridLength(0);
        //public GridLength BibleDiaryColumnWidth1
        //{
        //    get => _bibleDiaryColumnWidth1;
        //    set
        //    {
        //        _bibleDiaryColumnWidth1 = value;

        //        var args = new PropertyChangedEventArgs(nameof(BibleDiaryColumnWidth1));
        //        PropertyChanged?.Invoke(this, args);
        //    }
        //}

        //private GridLength _bibleDiaryColumnWidth2 = new GridLength(0);
        //public GridLength BibleDiaryColumnWidth2
        //{
        //    get => _bibleDiaryColumnWidth2;
        //    set
        //    {
        //        _bibleDiaryColumnWidth2 = value;

        //        var args = new PropertyChangedEventArgs(nameof(BibleDiaryColumnWidth2));
        //        PropertyChanged?.Invoke(this, args);
        //    }
        //}

        //public Command SwedishBibleDiary { get; }
        //public Command EnglishBibleDiary { get; }
        //public Command NewBibleDiary { get; }
        public Command ContinueBibleDiary { get; }
        public Command Back { get; }
        public Command ShareBibleDiary { get; }
        public Command LinkClickCommand { get; }

        public void ShowBibleDiary(/*Language language*/)
        {
            BibleDiary = new Diary(Language);
            BibleDiary.GetDiary(Language);

            //StartColumnWidth = new GridLength(0);
            //BibleDiaryColumnWidth1 = new GridLength(1, GridUnitType.Star);
            //BibleDiaryColumnWidth2 = new GridLength(1, GridUnitType.Star);

            //SetButtonVisibilitys();

            Header = BibleDiary.PresentBibleDiaryPage.Header;
            Vers = BibleDiary.PresentBibleDiaryPage.Vers;
            Image = BibleDiary.PresentBibleDiaryPage.Image;
            Placeholder = BibleDiary.PresentBibleDiaryPage.Palceholder;
            Comment = BibleDiary.PresentBibleDiaryPage.Comment;
            Link = BibleDiary.PresentBibleDiaryPage.BibleLink;

            if(BibleDiary.NrOfPages > 1)
            {
                BackButtonVisibility = true;
            }
        }

        //private void ShowStartPage()
        //{
        //    StartColumnWidth = new GridLength(1, GridUnitType.Star);
        //    BibleDiaryColumnWidth1 = new GridLength(0);
        //    BibleDiaryColumnWidth2 = new GridLength(0);

        //    StartButtonVisibility = true;
        //    BackButtonVisibility = false;
        //}

        //private void SetButtonVisibilitys()
        //{
        //    NewBiblediary = Language.NewBibleDiary;
        //    ShareBiblediary = Language.ShareBibleDiary;
        //    BackBiblediary = Language.BackBibleDiary;
        //    ContinueBiblediary = Language.ContinueBibleDiary;

        //    StartButtonVisibility = false;
        //    BackButtonVisibility = true;
        //}

        private async void ShareFuction()
        {
            BibleDiary.PresentBibleDiaryPage.Header = Header;
            BibleDiary.PresentBibleDiaryPage.Image = Image;
            BibleDiary.PresentBibleDiaryPage.Vers = Vers;
            BibleDiary.PresentBibleDiaryPage.Comment = Comment;
            BibleDiary.PresentBibleDiaryPage.BibleLink = Link;

            //await ShareFile(filePath);
            await ShareText(BibleDiary.GetPresentBibleDiaryPageAsString(Language));
        }

        private async Task ShareText(string text)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Bible Diary"
            });
        }

        private async Task ShareFile(string filePath)
        {
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "My comment:",
                File = new ShareFile(filePath)
            });
        }
    }
}
