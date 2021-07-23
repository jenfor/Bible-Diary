using System;
using System.Collections.Generic;
using System.Text;

namespace Bible_Diary.Languages
{
    public class Swedish : Language
    {
        public string LanguageName => "Swedish";

        public string NewBibleDiary => "Ny bibeldagbok";
        public string ShareBibleDiary => "Dela sidan";
        public string BackBibleDiary => "Bläddra bakåt";
        public string ContinueBibleDiary => "Nästa/Ny sida";
        public string CultureString => "sv-SE";

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
            { "”När mitt hjärta är fullt av bekymmer gör din tröst mig glad.  \nPsaltaren‬ ‭94:19‬ ‭B2000‬‬", "https://www.bible.com/154/psa.94.19.b2000" },
            { "Var och en skall ge som han har beslutat i sitt hjärta, inte med olust eller av tvång, ty Gud älskar en glad givare.  \n‭‭Andra Korinthierbrevet‬ ‭9:7‬ ‭B2000‬‬", "https://www.bible.com/154/2co.9.7.b2000" },
            { "Jag är övertygad om att han som har börjat ett gott verk hos er också skall fullborda det till Kristi Jesu dag.  \n‭‭Filipperbrevet‬ ‭1:6‬ ‭B2000‬‬", "https://www.bible.com/154/php.1.6.b2000" },
            { "Lär oss hur få våra dagar är, då vinner vårt hjärta vishet.  \n‭‭Psaltaren‬ ‭90:12‬ ‭B2000‬‬", "https://www.bible.com/154/psa.90.12.b2000" },
            { "Jesus svarade: »Jag är vägen, sanningen och livet. Ingen kommer till Fadern utom genom mig.”  \n‭‭‭‭Johannesevangeliet‬ ‭14:6‬ ‭B2000‬‬", "https://www.bible.com/154/jhn.14.6.b2000" },
            { "Jesus svarade: »Jag är livets bröd. Den som kommer till mig skall aldrig hungra, och den som tror på mig skall aldrig någonsin törsta.”  \nJohannesevangeliet‬ ‭6:35‬ ‭B2000‬‬", "https://www.bible.com/154/jhn.6.35.b2000" },
            { "När ni söker mig skall ni finna mig. Ja, om ni helhjärtat söker efter mig.”  \n‭‭Jeremia‬ ‭29:13‬ ‭B2000‬‬‬‬", "https://www.bible.com/154/jer.29.13.b2000" },

        };
    }
}
