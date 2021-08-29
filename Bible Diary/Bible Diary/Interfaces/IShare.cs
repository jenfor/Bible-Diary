using System;
using Xamarin.Forms;

namespace Bible_Diary.Interfaces
{
    public interface IShare
    {
        void Share(string subject, string message, string image);
    }
}
