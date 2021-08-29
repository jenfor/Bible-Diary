using System;
using Bible_Diary.Interfaces;
using Bible_Diary.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(IShareService))]
namespace Bible_Diary.iOS
{
    public class IShareService : IShare
    {
        public void Share(string subject, string message, string image)
        {
            var uiImage = UIImage.FromFile(image);

            var img = NSObject.FromObject(uiImage);
            var mess = NSObject.FromObject(message);

            var activityItems = new[] { mess, img };
            var activityController = new UIActivityViewController(activityItems, null);

            var topController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            while (topController.PresentedViewController != null)
            {
                topController = topController.PresentedViewController;
            }

            topController.PresentViewController(activityController, true, () => { });
        }
    }
}
