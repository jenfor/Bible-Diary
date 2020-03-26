using System;
using System.Collections.Generic;
using System.Text;

namespace Bible_Diary.Languages
{
    public class Swedish : Language
    {
        public string NewBibleDiary => "Ny bibeldagbok";
        public string ShareBibleDiary => "Dela den här bibeldagboks sidan";
        public string BackBibleDiary => "Bläddra bakåt";
        public string ContinueBibleDiary => "Nästa/Ny sida";

        public string BackToStartPageWarning => "Är du säker på att du vill gå tillbaka till startsidan? Den här bibeldagboken kommer att raderas.";
        public string Warning => "Varning";
        public string Deletion => "Är du säker på att du vill radera den här bibeldagboken och skapa en ny?";
        public string Yes => "Ja";
        public string No => "Nej";

        public string ExchangeString => "Skriv din kommentar om dagen här.";

        public string Dots => "...";
        public String Dot => ". ";
        public String Space => " ";
        public String Comma => ", ";
        public String NewLine => "\n ";

        public Dictionary<string, string> BibleVerses => new Dictionary<string, string>()
        {
            { "”När mitt hjärta är fullt av bekymmer gör din tröst mig glad. \nPsaltaren‬ ‭94:19‬ ‭B2000‬‬", "https://www.bible.com/154/psa.94.19.b2000" },
            { "Var och en skall ge som han har beslutat i sitt hjärta, inte med olust eller av tvång, ty Gud älskar en glad givare. \n‭‭Andra Korinthierbrevet‬ ‭9:7‬ ‭B2000‬‬", "https://www.bible.com/154/2co.9.7.b2000" },

        };
    }
}
