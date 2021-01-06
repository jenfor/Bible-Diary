using System;
using System.Collections.Generic;
using System.Text;

namespace Bible_Diary.Languages
{
    public class English : Language
    {
        public string NewBibleDiary => "New Bible Diary";
        public string ShareBibleDiary => "Share page";
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
            { "When anxiety was great within me, your consolation brought me joy.  ‭‭\n‭‭Psalms‬ ‭94:19‬ ‭NIV‬‬", "https://www.bible.com/111/psa.94.19.niv" },
            { "Each of you should give what you have decided in your heart to give, not reluctantly or under compulsion, for God loves a cheerful giver.  \n‭‭2 Corinthians‬ ‭9:7‬ ‭NIV‬‬", "https://www.bible.com/111/2co.9.7.niv" },
            { "You will seek me and find me when you seek me with all your heart.  \n‭‭Jeremiah‬ ‭29:13‬ ‭NIV‬‬", "https://www.bible.com/111/jer.29.13.niv" },
            { "And do not forget to do good and to share with others, for with such sacrifices God is pleased.  ‭‭\n‭‭‭‭Hebrews‬ ‭13:16‬ ‭NIV‬‬", "https://www.bible.com/111/heb.13.16.niv" },
            { "He who began a good work in you will carry it on to completion until the day of Christ Jesus.  ‭‭\n‭‭Philippians‬ ‭1:6‬ ‭NIV‬‬", "https://www.bible.com/111/php.1.6.niv" },
            { "Teach us to number our days, that we may gain a heart of wisdom.  \n‭‭Psalms‬ ‭90:12‬ ‭NIV‬‬‬‬", "https://www.bible.com/111/psa.90.12.niv" },
            { "Then Jesus declared, “I am the bread of life. Whoever comes to me will never go hungry, and whoever believes in me will never be thirsty.  ‭‭\n‭‭‭‭‭‭John‬ ‭6:35‬ ‭NIV‬‬", "https://www.bible.com/111/jhn.6.35.niv" },
            { "Jesus answered, “I am the way and the truth and the life. No one comes to the Father except through me.”  ‭‭\n‭‭‭‭‭‭‭‭John‬ ‭14:6‬ ‭NIV‬‬", "https://www.bible.com/111/jhn.14.6.niv" },

        };
    }
}
