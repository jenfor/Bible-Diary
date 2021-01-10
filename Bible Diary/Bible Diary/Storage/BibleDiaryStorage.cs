using System;
using System.Collections.Generic;
using Bible_Diary.BibleDiary;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Bible_Diary.Storage
{
    public static class BibleDiaryStorage
    {
        public static void Save(List<BibleDiaryPage> BibleDiaryPageList)
        {
            var json = SerializeObject(BibleDiaryPageList);
            Preferences.Set("my_bible_diary", json);
        }

        public static List<BibleDiaryPage> Read()
        {
            var content = Preferences.Get("my_bible_diary", String.Empty);
            var BibleDiaryPageList = DeserializeObject(content) as List<BibleDiaryPage>;

            return BibleDiaryPageList == null ? new List<BibleDiaryPage>() : BibleDiaryPageList;
        }

        public static void DeleteBibleDiary()
        {
            Preferences.Set("my_bible_diary", String.Empty);
        }

        public static void SaveLanguage(string language)
        {
            Preferences.Set("language", language);
        }

        public static string GetLanguage()
        {
            var language = Preferences.Get("language", String.Empty);

            return language == null ? String.Empty : language;
        }

        private static String SerializeObject(List<BibleDiaryPage> BibleDiaryPageList)
        {
            string returnObject; 
            try
            {
                returnObject = JsonConvert.SerializeObject(BibleDiaryPageList);
            }
            catch
            {
                returnObject = String.Empty;
            }

            return returnObject;
        }

        private static List<BibleDiaryPage> DeserializeObject(string json)
        {
            List<BibleDiaryPage> returnObject;
            try
            {
                returnObject = JsonConvert.DeserializeObject<List<BibleDiaryPage>>(json);
            }
            catch
            {
                returnObject = new List<BibleDiaryPage>();
            }

            return returnObject;
        }
    }
}
