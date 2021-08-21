using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Bible_Diary.Interfaces;
using Bible_Diary.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhotoPickerService))]
namespace Bible_Diary.iOS
{
    //public class PhotoPickerService : IPhotoPickerService
    //{
    //    TaskCompletionSource<Stream> taskCompletionSource;
    //    UIImagePickerController imagePicker;

    //    public Task<Stream> GetImageStreamAsync()
    //    {
    //        // Create and define UIImagePickerController
    //        imagePicker = new UIImagePickerController
    //        {
    //            SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
    //            MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
    //        };

    //        // Set event handlers
    //        imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
    //        imagePicker.Canceled += OnImagePickerCancelled;

    //        // Present UIImagePickerController;
    //        UIWindow window = UIApplication.SharedApplication.KeyWindow;
    //        var viewController = window.RootViewController;
    //        viewController.PresentViewController(imagePicker, true, null);

    //        // Return Task object
    //        taskCompletionSource = new TaskCompletionSource<Stream>();
    //        return taskCompletionSource.Task;
    //    }

    //    void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
    //    {
    //        UIImage image = args.EditedImage ?? args.OriginalImage;

    //        if (image != null)
    //        {
    //            // Convert UIImage to .NET Stream object
    //            NSData data;
    //            if (args.ReferenceUrl.PathExtension.Equals("PNG") || args.ReferenceUrl.PathExtension.Equals("png"))
    //            {
    //                data = image.AsPNG();
    //            }
    //            else
    //            {
    //                data = image.AsJPEG(1);
    //            }
    //            Stream stream = data.AsStream();

    //            UnregisterEventHandlers();

    //            // Set the Stream as the completion of the Task
    //            taskCompletionSource.SetResult(stream);
    //        }
    //        else
    //        {
    //            UnregisterEventHandlers();
    //            taskCompletionSource.SetResult(null);
    //        }
    //        imagePicker.DismissModalViewController(true);
    //    }

    //    void OnImagePickerCancelled(object sender, EventArgs args)
    //    {
    //        UnregisterEventHandlers();
    //        taskCompletionSource.SetResult(null);
    //        imagePicker.DismissModalViewController(true);
    //    }

    //    void UnregisterEventHandlers()
    //    {
    //        imagePicker.FinishedPickingMedia -= OnImagePickerFinishedPickingMedia;
    //        imagePicker.Canceled -= OnImagePickerCancelled;
    //    }
    //}

    public class PhotoPickerService : IPhotoPickerService
    {
        TaskCompletionSource<Dictionary<string, Stream>> taskCompletionSource;
        UIImagePickerController imagePicker;

        Task<Dictionary<string, Stream>> IPhotoPickerService.GetImageStreamAsync()
        {
            // Create and define UIImagePickerController
            imagePicker = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            // Set event handlers
            imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled += OnImagePickerCancelled;

            // Present UIImagePickerController;
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;
            viewController.PresentModalViewController(imagePicker, true);

            // Return Task object
            taskCompletionSource = new TaskCompletionSource<Dictionary<string, Stream>>();
            return taskCompletionSource.Task;
        }



        void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
            UIImage image = args.EditedImage ?? args.OriginalImage;

            if (image != null)
            {
                // Convert UIImage to .NET Stream object
                NSData data;
                if (args.ReferenceUrl.PathExtension.Equals("PNG") || args.ReferenceUrl.PathExtension.Equals("png"))
                {
                    data = image.AsPNG();
                }
                else
                {
                    data = image.AsJPEG(1);
                }
                Stream stream = data.AsStream();

                UnregisterEventHandlers();

                Dictionary<string, Stream> dic = new Dictionary<string, Stream>();
                //dic.Add(args.ImageUrl.ToString(), stream);
                dic.Add(args.ImageUrl.Path, stream);


                // Set the Stream as the completion of the Task
                taskCompletionSource.SetResult(dic);
            }
            else
            {
                UnregisterEventHandlers();
                taskCompletionSource.SetResult(null);
            }
            imagePicker.DismissModalViewController(true);
        }

        void OnImagePickerCancelled(object sender, EventArgs args)
        {
            UnregisterEventHandlers();
            taskCompletionSource.SetResult(null);
            imagePicker.DismissModalViewController(true);
        }

        void UnregisterEventHandlers()
        {
            imagePicker.FinishedPickingMedia -= OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled -= OnImagePickerCancelled;
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
