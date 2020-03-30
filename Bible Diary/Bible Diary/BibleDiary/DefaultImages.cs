using System;
using System.Collections.Generic;
using System.Text;

namespace Bible_Diary.BibleDiary
{
    public static class DefaultImages
    {
        public static List<string> Images = new List<string>()
        {
            "b1913.jpg",
            "b1917.jpg",
            "b1918.jpg",
            "b1920.jpg",
            "b1925.jpg",
            "b1940.jpg",
            "b1945.jpg",
            "b1963.jpg",
            "b1964.jpg",
            "b1965.jpg",
            "b1970.jpg",
            "b1988.jpg",
            "b2015.jpg"
        };

        public static string GetRandomImage()
        {
            var random = new Random();
            var image = Images[random.Next(Images.Count)];
            return image;
        }

    }
}
