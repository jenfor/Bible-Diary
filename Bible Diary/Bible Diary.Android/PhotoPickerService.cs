using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using Bible_Diary.Droid;
using Bible_Diary.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhotoPickerService))]
namespace Bible_Diary.Droid
{
    //public class PhotoPickerService : IPhotoPickerService
    //{
    //    public Task<Stream> GetImageStreamAsync()
    //    {
    //        // Define the Intent for getting images
    //        Intent intent = new Intent();
    //        intent.SetType("image/*");
    //        intent.SetAction(Intent.ActionGetContent);

    //        // Start the picture-picker activity (resumes in MainActivity.cs)
    //        MainActivity.Instance.StartActivityForResult(
    //            Intent.CreateChooser(intent, "Select Picture"),
    //            MainActivity.PickImageId);

    //        // Save the TaskCompletionSource object as a MainActivity property
    //        MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

    //        // Return Task object
    //        return MainActivity.Instance.PickImageTaskCompletionSource.Task;
    //    }
    //}

    public class PhotoPickerService : IPhotoPickerService
    {
        public Task<Dictionary<string, Stream>> GetImageStreamAsync()
        {
            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            // Start the picture-picker activity (resumes in MainActivity.cs)
            MainActivity.Instance.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Picture"),
                MainActivity.PickImageId);

            // Save the TaskCompletionSource object as a MainActivity property
            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Dictionary<string, Stream>>();

            // Return Task object
            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }

        public string SavePicture(string name, Stream data, string location = "temp")
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            documentsPath = Path.Combine(documentsPath, "Orders", location);
            Directory.CreateDirectory(documentsPath);

            string filePath = Path.Combine(documentsPath, name);

            byte[] bArray = new byte[data.Length];
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (data)
                {
                    data.Read(bArray, 0, (int)data.Length);
                }
                int length = bArray.Length;
                fs.Write(bArray, 0, length);
            }

            return filePath;
        }
    }
}
