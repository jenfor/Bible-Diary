using System;
using System.Collections.Generic;
using System.Text;

namespace Bible_Diary.Languages
{
    public interface Language
    {
        string NewBibleDiary { get; }
        string ShareBibleDiary { get; }
        string BackBibleDiary { get; }
        string ContinueBibleDiary { get; }

        string BackToStartPageWarning { get; }
        string Warning { get; }
        string Deletion { get; }
        string Yes { get; }
        string No { get; }

        string ExchangeString { get; }

        string Dot { get; }
        string Space { get; }
        string Comma { get; }
        string NewLine { get; }

        Dictionary<string, string> BibleVerses { get; }

    }
}
