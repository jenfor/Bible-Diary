using System;
using System.Collections.Generic;
using System.Text;

namespace Bible_Diary.Languages
{
    public class English : Language
    {
        public string NewBibleDiary => "New Bible Diary";
        public string ShareBibleDiary => "Share this Bible Diary page";
        public string BackBibleDiary => "Back";
        public string ContinueBibleDiary => "Continue";

        public string BackToStartPageWarning => "Are you sure you want to go back to start? This Bible Diary will be deleted!";

        public string Warning => "Warning";
        public string Deletion => "Are you sure you want to delete this Bible Diary and create a new one?";
        public string Yes => "Yes";
        public string No => "No";

        public string ExchangeString => "Write your comment about the day here.";

        public string Dots => "...";
        public String Dot => ". ";
        public String Space => " ";
        public String Comma => ", ";
        public String NewLine => "\n";

        public Dictionary<string, string> BibleVerses => new Dictionary<string, string>()
        {
            { "When anxiety was great within me, your consolation brought me joy. \n‭‭Psalms‬ ‭94:19‬ ‭NIV‬‬", "https://www.bible.com/111/psa.94.19.niv" },
            { "Each of you should give what you have decided in your heart to give, not reluctantly or under compulsion, for God loves a cheerful giver. \n‭‭2 Corinthians‬ ‭9:7‬ ‭NIV‬‬", "https://www.bible.com/111/2co.9.7.niv" },
        };
    }
}
