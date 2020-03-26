using Bible_Diary.Languages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bible_Diary.BibleDiary
{
    public class Diary
    {
        public BibleDiaryPage PresentBibleDiaryPage = new BibleDiaryPage();
        private List<BibleDiaryPage> DiaryPageList = new List<BibleDiaryPage>();
        public int PresentDiaryPageNr = -1;

        public Diary(Language language)
        {
            CreateNewBibleDiaryPage(language);
            PresentBibleDiaryPage = DiaryPageList[PresentDiaryPageNr];
        }

        public void CreateNewBibleDiaryPage(Language language)
        {
            var vers = GetBibleVers(language);
            DiaryPageList.Add(new BibleDiaryPage()
            {
                Header = DateTime.Now.ToLongDateString(),
                Image = "Image placeholder",
                Vers = vers.Key,
                Palceholder = language.ExchangeString,
                Comment = string.Empty,
                BibleLink = vers.Value,
            });

            PresentDiaryPageNr++;
        }

        public KeyValuePair<string,string> GetBibleVers(Language language)
        {
            var verses = new List<string>(language.BibleVerses.Keys);
            var vers = GetWords(verses);
            return new KeyValuePair<string, string>(vers, language.BibleVerses[vers]);
        }

        public bool ViewPreviousPage()
        {
            if (PresentDiaryPageNr >= 1)
            {
                PresentDiaryPageNr --;
                PresentBibleDiaryPage = DiaryPageList[PresentDiaryPageNr];
                return true;
            }

            return false;
        }

        public void ViewNextPage(Language language)
        {

            if (PresentDiaryPageNr < DiaryPageList.Count -1)
            {
                PresentDiaryPageNr++;
                PresentBibleDiaryPage = DiaryPageList[PresentDiaryPageNr];
            }
            else
            {
                CreateNewBibleDiaryPage(language);
                PresentBibleDiaryPage = DiaryPageList[PresentDiaryPageNr];
            }
        }

        public string GetStartImage(Language language)
        {
            return "Photo placeholder";
        }

        public string GetPresentBibleDiaryPageAsString(Language language)
        {
            var sb = new StringBuilder();

            sb.Append(PresentBibleDiaryPage.Header + language.NewLine);
            sb.Append(PresentBibleDiaryPage.Image + language.NewLine);
            sb.Append(PresentBibleDiaryPage.Vers + language.NewLine);
            sb.Append(PresentBibleDiaryPage.Comment + language.NewLine);
            sb.Append(PresentBibleDiaryPage.BibleLink + language.NewLine);

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
    }
}
