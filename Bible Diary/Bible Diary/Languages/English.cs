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
        public string ContinueBibleDiary => "Next/New Page";
        public string CultureString => "en-US";

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
            { "Love is patient, love is kind. It does not envy, it does not boast, it is not proud. ‭‭\n‭‭‭‭‭‭‭1 Corinthians‬ ‭13:4‬ ‭NIV‬‬ ", "https://www.bible.com/111/1co.13.4.niv" },
            { "For where your treasure is, there your heart will be also. ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭6:21‬ ‭NIV‬‬ ", "https://www.bible.com/111/mat.6.21.niv" },
            { "You also must be ready, because the Son of Man will come at an hour when you do not expect him.” ‭‭\n‭‭‭‭‭‭‭Luke‬ ‭12:40‬ ‭NIV‬‬ ", "https://www.bible.com/111/luk.12.40.niv" },
            { "Rejoice in the Lord always. I will say it again: Rejoice! ‭‭\n‭‭‭‭‭‭‭Philippians‬ ‭4:4‬ ‭NIV‬‬ ", "https://www.bible.com/111/php.4.4.niv" },
            { "Rejoice always, pray continually, give thanks in all circumstances; for this is God’s will for you in Christ Jesus. ‭‭\n‭‭‭‭‭‭‭1 Thessalonians‬ ‭5:16-18‬ ‭NIV ", "https://www.bible.com/111/1th.5.16-18.niv" },
            { "Is anyone among you in trouble? Let them pray. Is anyone happy? Let them sing songs of praise.” ‭‭\n‭‭‭‭‭‭‭‭‭James‬ ‭5:13‬ ‭NIV ", "https://www.bible.com/111/jas.5.13.niv" },
            { "For where two or three gather in my name, there am I with them. ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭18:20‬ ‭NIV‬‬ ", "https://www.bible.com/111/mat.18.20.niv" },
            { "If anyone acknowledges that Jesus is the Son of God, God lives in them and they in God. ‭‭\n‭‭‭‭‭‭‭1 John‬ ‭4:15‬ ‭NIV‬‬ ", "https://www.bible.com/111/1jn.4.15.niv" },
            { "Jesus Christ is the same yesterday and today and forever. ‭‭\n‭‭‭‭‭‭‭Hebrews‬ ‭13:8‬ ‭NIV‬‬ ", "https://www.bible.com/111/heb.13.8.niv" },
            { "But seek first his kingdom and his righteousness, and all these things will be given to you as well. ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭6:33‬ ‭NIV‬‬ ", "https://www.bible.com/111/mat.6.33.niv" },
            { "You are my refuge and my shield; I have put my hope in your word.” ‭‭\n‭‭‭‭‭‭‭Psalms‬ ‭119:114‬ ‭NIV ", "https://www.bible.com/111/psa.119.114.niv" },
            { "And when you pray, do not keep on babbling like pagans, for they think they will be heard because of their many words. Do not be like them, for your Father knows what you need before you ask him. ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭6:7-8‬ ‭NIV ", "https://www.bible.com/111/mat.6.7-8.niv" },
            { "If you then, though you are evil, know how to give good gifts to your children, how much more will your Father in heaven give the Holy Spirit to those who ask him! ‭‭\n‭‭‭‭‭‭‭Luke‬ ‭11:13‬ ‭NIV‬‬ ", "https://www.bible.com/111/luk.11.13.niv" },
            { "Trust in the Lord forever, for the Lord, the Lord himself, is the Rock eternal. ‭‭\n‭‭‭‭‭‭‭Isaiah‬ ‭26:4‬ ‭NIV‬‬ ", "https://www.bible.com/111/isa.26.4.niv" },
            { "When anxiety was great within me, your consolation brought me joy. ‭‭\n‭‭‭‭‭‭‭Psalms‬ ‭94:19‬ ‭NIV‬‬ ", "https://www.bible.com/111/psa.94.19.niv" },
            { "My command is this: Love each other as I have loved you. ‭‭\n‭‭‭‭‭‭‭‭‭John‬ ‭15:12‬ ‭NIV‬‬ ", "https://www.bible.com/111/jhn.15.12.niv" },
            { "But if we walk in the light, as he is in the light, we have fellowship with one another, and the blood of Jesus, his Son, purifies us from all sin. ‭‭\n‭‭‭‭‭‭‭1 John‬ ‭1:7‬ ‭NIV‬‬ ", "https://www.bible.com/111/1jn.1.7.niv" },
            { "Blessed are those who mourn, for they will be comforted. ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭5:4‬ ‭NIV‬‬ ", "https://www.bible.com/111/mat.5.4.niv" },
            { "Unless the Lord builds the house, the builders labor in vain. Unless the Lord watches over the city, the guards stand watch in vain. ‭‭\n‭‭‭‭‭‭‭Psalms‬ ‭127:1‬ ‭NIV‬‬ ", "https://www.bible.com/111/psa.127.1.niv" },
            { "Do not be overcome by evil, but overcome evil with good. ‭‭\n‭‭‭‭‭‭‭Romans‬ ‭12:21‬ ‭NIV‬‬ ", "https://www.bible.com/111/rom.12.21.niv" },
            { "For our struggle is not against flesh and blood, but against the rulers, against the authorities, against the powers of this dark world and against the spiritual forces of evil in the heavenly realms. ‭‭\n‭‭‭‭‭‭‭Ephesians‬ ‭6:12‬ ‭NIV‬‬ ", "https://www.bible.com/111/eph.6.12.niv" },
            { "But thanks be to God! He gives us the victory through our Lord Jesus Christ. ‭‭\n‭‭‭‭‭‭‭1 Corinthians‬ ‭15:57‬ ‭NIV ", "https://www.bible.com/111/1co.15.57.niv" },
            { "For everyone who asks receives; the one who seeks finds; and to the one who knocks, the door will be opened. ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭7:8‬ ‭NIV ", "https://www.bible.com/111/mat.7.8.niv" },
            { "For I am not ashamed of the gospel, because it is the power of God that brings salvation to everyone who believes: first to the Jew, then to the Gentile. ‭‭\n‭‭‭‭‭‭‭Romans‬ ‭1:16‬ ‭NIV‬‬ ", "https://www.bible.com/111/rom.1.16.niv" },
            { "When I am afraid, I put my trust in you. ‭‭\n‭‭‭‭‭‭‭Psalms‬ ‭56:3‬ ‭NIV‬‬ ", "https://www.bible.com/111/psa.56.3.niv" },
            { "For the Lord is good and his love endures forever; his faithfulness continues through all generations. ‭‭\n‭‭‭‭‭‭‭Psalms‬ ‭100:5‬ ‭NIV‬‬ ", "https://www.bible.com/111/psa.100.5.niv" },
            { "Look to the Lord and his strength; seek his face always. ‭‭\n‭‭‭‭‭‭‭1 Chronicles‬ ‭16:11‬ ‭NIV‬‬ ", "https://www.bible.com/111/1ch.16.11.niv" },
            { "But I tell you, love your enemies and pray for those who persecute you, ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭5:44‬ ‭NIV‬‬ ", "https://www.bible.com/111/mat.5.44.niv" },
            { "Jesus replied: “ ‘Love the Lord your God with all your heart and with all your soul and with all your mind.’ This is the first and greatest commandment. And the second is like it: ‘Love your neighbor as yourself.’ ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭22:37-39‬ ‭NIV ", "https://www.bible.com/111/mat.22.37-39.niv" },
            { "He will wipe every tear from their eyes. There will be no more death’ or mourning or crying or pain, for the old order of things has passed away.” ‭‭\n‭‭‭‭‭‭‭‭‭Revelation‬ ‭21:4‬ ‭NIV‬‬ ", "https://www.bible.com/111/rev.21.4.niv" },
            { "For the entire law is fulfilled in keeping this one command: “Love your neighbor as yourself.” ‭‭\n‭‭‭‭‭‭‭Galatians‬ ‭5:14‬ ‭NIV‬‬ ", "https://www.bible.com/111/gal.5.14.niv" },
            { "Do not let your hearts be troubled. You believe in God; believe also in me. ‭‭\n‭‭‭‭‭‭‭John‬ ‭14:1‬ ‭NIV‬‬ ", "https://www.bible.com/111/jhn.14.1.niv" },
            { "Those who sow with tears will reap with songs of joy. ‭\n‭‭‭‭‭‭‭Psalms‬ ‭126:5‬ ‭NIV‬‬ ", "https://www.bible.com/111/psa.126.5.niv" },
            { "Here I am! I stand at the door and knock. If anyone hears my voice and opens the door, I will come in and eat with that person, and they with me.” ‭‭\n‭‭‭‭‭‭‭Revelation‬ ‭3:20‬ ‭NIV‬‬ ", "https://www.bible.com/111/rev.3.20.niv" },
            { "Give thanks to the Lord, for he is good; his love endures forever. ‭‭\n‭‭‭‭‭‭‭Psalms‬ ‭107:1‬ ‭NIV ", "https://www.bible.com/111/psa.107.1.niv" },
            { "Just as the Son of Man did not come to be served, but to serve, and to give his life as a ransom for many. ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭20:28‬ ‭NIV ", "https://www.bible.com/111/mat.20.28.niv" },
            { "Love does no harm to a neighbor. Therefore love is the fulfillment of the law.” ‭‭\n‭‭‭‭‭‭‭Romans‬ ‭13:10‬ ‭NIV ", "https://www.bible.com/111/rom.13.10.niv" },
            { "He says, “Be still, and know that I am God; I will be exalted among the nations, I will be exalted in the earth. ‭‭\n‭‭‭‭‭‭‭Psalms‬ ‭46:10‬ ‭NIV‬‬ ", "https://www.bible.com/111/psa.46.10.niv" },
            { "And now these three remain: faith, hope and love. But the greatest of these is love. ‭‭\n‭‭‭‭‭‭‭1 Corinthians‬ ‭13:13‬ ‭NIV‬‬ ", "https://www.bible.com/111/1co.13.13.niv" },
            { "He is not here; he has risen, just as he said. Come and see the place where he lay. ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭28:6‬ ‭NIV‬‬ ", "https://www.bible.com/111/mat.28.6.niv" },
            { "But God demonstrates his own love for us in this: While we were still sinners, Christ died for us. ‭‭\n‭‭‭‭‭‭‭Romans‬ ‭5:8‬ ‭NIV ", "https://www.bible.com/111/rom.5.8.nivs" },
            { "The next day John saw Jesus coming toward him and said, “Look, the Lamb of God, who takes away the sin of the world! ‭‭\n‭‭‭‭‭‭‭‭‭John‬ ‭1:29‬ ‭NIV‬‬ ", "https://www.bible.com/111/jhn.1.29.niv" },
            { "But blessed is the one who trusts in the Lord, whose confidence is in him. ‭‭\n‭‭‭‭‭‭‭Jeremiah‬ ‭17:7‬ ‭NIV ", "https://www.bible.com/111/jer.17.7.niv" },
            { "pray continually, ‭‭\n‭‭‭‭‭‭‭1 Thessalonians‬ ‭5:17‬ ‭NIV ", "https://www.bible.com/111/1th.5.17.niv" },
            { "He said to them, “Go into all the world and preach the gospel to all creation. ‭‭\n‭‭‭‭‭‭‭Mark‬ ‭16:15‬ ‭NIV ", "https://www.bible.com/111/mrk.16.15.niv" },
            { "As a mother comforts her child, so will I comfort you; and you will be comforted over Jerusalem.” ‭‭\n‭‭‭‭‭‭‭Isaiah‬ ‭66:13‬ ‭NIV ", "https://www.bible.com/111/isa.66.13.niv" },
            { "Your word is a lamp for my feet, a light on my path. ‭‭\n‭‭‭‭‭‭‭Psalms‬ ‭119:105‬ ‭NIV ", "https://www.bible.com/111/psa.119.105.niv" },
            { "Above all, love each other deeply, because love covers over a multitude of sins. ‭‭\n‭‭‭‭‭‭‭1 Peter‬ ‭4:8‬ ‭NIV‬‬ ", "https://www.bible.com/111/1pe.4.8.niv" },
            { "Very truly I tell you, whoever hears my word and believes him who sent me has eternal life and will not be judged but has crossed over from death to life.” ‭‭\n‭‭‭‭‭‭‭‭‭John‬ ‭5:24‬ ‭NIV ", "https://www.bible.com/111/jhn.5.24.niv" },
            { "To do what is right and just is more acceptable to the Lord than sacrifice.” ‭‭\n‭‭‭‭‭‭‭Proverbs‬ ‭21:3‬ ‭NIV ", "https://www.bible.com/111/pro.21.3.niv" },
            { "See, I am doing a new thing! Now it springs up; do you not perceive it? I am making a way in the wilderness and streams in the wasteland. ‭‭\n‭‭‭‭‭‭‭Isaiah‬ ‭43:19‬ ‭NIV ", "https://www.bible.com/111/isa.43.19.niv" },
            { "Blessed are those who hunger and thirst for righteousness, for they will be filled. ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭5:6‬ ‭NIV‬‬ ", "https://www.bible.com/111/mat.5.6.niv" },
            { "Be completely humble and gentle; be patient, bearing with one another in love.” ‭‭\n‭‭‭‭‭‭‭Ephesians‬ ‭4:2‬ ‭NIV‬‬ ", "https://www.bible.com/111/eph.4.2.niv" },
            { "I waited patiently for the Lord; he turned to me and heard my cry. He lifted me out of the slimy pit, out of the mud and mire; he set my feet on a rock and gave me a firm place to stand. ‭‭\n‭‭‭‭‭‭‭Psalms‬ ‭40:1-2‬ ‭NIV‬‬ ", "https://www.bible.com/111/psa.40.1-2.niv" },
            { "In your relationships with one another, have the same mindset as Christ Jesus ‭‭\n‭‭‭‭‭‭‭Philippians‬ ‭2:5‬ ‭NIV‬‬ ", "https://www.bible.com/111/php.2.5.niv" },
            { "but those who hope in the Lord will renew their strength. They will soar on wings like eagles; they will run and not grow weary, they will walk and not be faint. ‭‭\n‭‭‭‭‭‭‭‭‭Isaiah‬ ‭40:31‬ ‭NIV‬‬ ", "https://www.bible.com/111/isa.40.31.niv" },
            { "Commit to the Lord whatever you do, and he will establish your plans. ‭‭\n‭‭‭‭‭‭‭Proverbs‬ ‭16:3‬ ‭NIV‬‬ ", "https://www.bible.com/111/pro.16.3.niv" },
            { "Blessed are the merciful, for they will be shown mercy. ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭5:7‬ ‭NIV ", "https://www.bible.com/111/mat.5.7.niv" },
            { "Dear children, let us not love with words or speech but with actions and in truth. ‭‭\n‭‭‭‭‭‭‭1 John‬ ‭3:18‬ ‭NIV ", "https://www.bible.com/111/1jn.3.18.niv" },
            { "Let us not become weary in doing good, for at the proper time we will reap a harvest if we do not give up. ‭‭\n‭‭‭‭‭‭‭Galatians‬ ‭6:9‬ ‭NIV‬‬ ", "https://www.bible.com/111/gal.6.9.niv" },
            { "Blessed are the peacemakers, for they will be called children of God. ‭‭\n‭‭‭‭‭‭‭Matthew‬ ‭5:9‬ ‭NIV ", "https://www.bible.com/111/mat.5.9.niv" },
            { "You will seek me and find me when you seek me with all your heart. ‭‭\n‭‭‭‭‭‭‭Jeremiah‬ ‭29:13‬ ‭NIV‬‬ ", "https://www.bible.com/111/jer.29.13.niv" },
            { "f any of you lacks wisdom, you should ask God, who gives generously to all without finding fault, and it will be given to you. ‭‭\n‭‭‭‭‭‭‭‭‭James‬ ‭1:5‬ ‭NIV‬‬ ", "https://www.bible.com/111/jas.1.5.niv" },
        };
    }
}
