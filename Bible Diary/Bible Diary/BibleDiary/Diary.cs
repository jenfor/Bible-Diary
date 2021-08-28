using Bible_Diary.Languages;
using Bible_Diary.Storage;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace Bible_Diary.BibleDiary
{
    public class Diary
    {
        public BibleDiaryPage PresentBibleDiaryPage = new BibleDiaryPage();
        private List<BibleDiaryPage> DiaryPageList = new List<BibleDiaryPage>();
        public int PresentDiaryPageNr = -1;

        public int NrOfPages
        {
            get => DiaryPageList.Count();
        }

        public Diary(Language language)
        {
        }

        public void GetDiary(Language language)
        {
            DiaryPageList = BibleDiaryStorage.Read();

            if (DiaryPageList.Count() != 0)
            {
                PresentDiaryPageNr = DiaryPageList.Last().PageNumber;
            }

            CreateNewBibleDiaryPage(language);
            PresentBibleDiaryPage = DiaryPageList[PresentDiaryPageNr];
        }

        public void DeleteBibleDiary()
        {
            BibleDiaryStorage.DeleteBibleDiary();
            DiaryPageList = new List<BibleDiaryPage>();
            PresentDiaryPageNr = -1;
    }

        public void CreateNewBibleDiaryPage(Language language)
        {
            PresentDiaryPageNr++;
            var vers = GetBibleVers(language);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language.CultureString);

            DiaryPageList.Add(new BibleDiaryPage()
            {
                Header = DateTime.Now.ToLongDateString(),
                Image = DefaultImages.GetRandomImage(),
                Vers = vers.Key,
                Palceholder = language.ExchangeString,
                Comment = string.Empty,
                BibleLink = vers.Value,
                PageNumber = PresentDiaryPageNr,
            });

            SaveDiary();
        }

        public KeyValuePair<string, string> GetBibleVers(Language language)
        {
            var verses = new List<string>(language.BibleVerses.Keys);
            var vers = GetWords(verses);
            return new KeyValuePair<string, string>(vers, language.BibleVerses[vers]);
        }

        public bool ViewPreviousPage()
        {
            if (PresentDiaryPageNr >= 1)
            {
                PresentDiaryPageNr--;
                PresentBibleDiaryPage = DiaryPageList[PresentDiaryPageNr]; 
                BibleDiaryStorage.Save(DiaryPageList);
                return true;
            }

            SaveDiary();
            return false;
        }

        public bool ViewNextPage(Language language)
        {
            if (PresentDiaryPageNr < DiaryPageList.Count - 1)
            {
                PresentDiaryPageNr++;
                PresentBibleDiaryPage = DiaryPageList[PresentDiaryPageNr];
                SaveDiary();
                return true;

            }
            else
            {
                CreateNewBibleDiaryPage(language);
                PresentBibleDiaryPage = DiaryPageList[PresentDiaryPageNr];
                SaveDiary();
                return false;

            }

        }

        public void SaveDiary()
        {
            BibleDiaryStorage.Save(DiaryPageList);
        }

        public string GetStartImage()
        {
            return DefaultImages.GetRandomImage();
        }

        public string GetPresentBibleDiaryPageAsString(Language language)
        {
            var sb = new StringBuilder();

            //sb.Append(PresentBibleDiaryPage.Header + language.NewLine);
            //sb.Append(PresentBibleDiaryPage.Image + language.NewLine);
            sb.Append(PresentBibleDiaryPage.Vers + language.NewLine);
            if (!String.IsNullOrEmpty(PresentBibleDiaryPage.Comment))
            {
                sb.Append(PresentBibleDiaryPage.Comment + language.NewLine);
            }
            sb.Append(PresentBibleDiaryPage.BibleLink);

            return sb.ToString();
        }

        public string GetWords(List<string> wordList)
        {
            var random = new Random();
            var word = wordList[random.Next(wordList.Count)];
            return word;
        }
    }

    public class BibleDiaryPage
    {
        public string Header = "Header placeholder";
        public string Image = "Image Placeholder";
        public string Vers = "Vers placeholder";
        public string BibleLink = "BibleLink placeholder";
        public string Palceholder = "Write your comment about the day here";
        public string Comment = string.Empty;
        public int PageNumber = 0;
        public string ImageSource = null;
        public bool UserHasSelectedPhoto = false;
    }
}
