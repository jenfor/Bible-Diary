using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.IO;
using Android.Content;
using System.Collections.Generic;

namespace Bible_Diary.Droid
{
    [Activity(Label = "Bible Diary", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Instance = this;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public static readonly int PickImageId = 1000;

        //public TaskCompletionSource<Stream> PickImageTaskCompletionSource { set; get; }
        public TaskCompletionSource<Dictionary<string, Stream>> PickImageTaskCompletionSource { set; get; }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        //protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        //{
        //    base.OnActivityResult(requestCode, resultCode, intent);

        //    if (requestCode == PickImageId)
        //    {
        //        if ((resultCode == Result.Ok) && (intent != null))
        //        {
        //            Android.Net.Uri uri = intent.Data;
        //            Stream stream = ContentResolver.OpenInputStream(uri);

        //            // Set the Stream as the completion of the Task
        //            PickImageTaskCompletionSource.SetResult(stream);
        //        }
        //        else
        //        {
        //            PickImageTaskCompletionSource.SetResult(null);
        //        }
        //    }
        //}

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);

            if (requestCode == PickImageId)
            {
                if ((resultCode == Result.Ok) && (intent != null))
                {
                    Android.Net.Uri uri = intent.Data;
                    Stream stream = ContentResolver.OpenInputStream(uri);

                    Dictionary<string, Stream> dic = new Dictionary<string, Stream>();
                    //dic.Add(uri.ToString(), stream);
                    dic.Add(uri.Path, stream);

                    // Set the Stream as the completion of the Task
                    PickImageTaskCompletionSource.SetResult(dic);
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);
                }
            }
        }
    }
}