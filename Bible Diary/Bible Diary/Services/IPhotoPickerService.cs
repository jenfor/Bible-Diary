using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Bible_Diary.Interfaces
{
    public interface IPhotoPickerService
    {
        //Task<Stream> GetImageStreamAsync();
        Task<Dictionary<string, Stream>> GetImageStreamAsync();

        string SavePicture(string name, Stream data, string location = "Bible_Diary_photos");


    }
}
