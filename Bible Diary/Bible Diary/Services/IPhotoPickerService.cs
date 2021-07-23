using System;
using System.IO;
using System.Threading.Tasks;

namespace Bible_Diary.Interfaces
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
