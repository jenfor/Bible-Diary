using System;
namespace Bible_Diary.Messages
{
    public class NotificationClasses
    {
        public class NotificationMessage
        {
            public string Title { get; set; }
            public string Text { get; set; }
        }

        public class NewPhotoMessage : NotificationMessage
        {
            public string ImageSource { get; set; }
        }

        public class SetPhotoMessage : NotificationMessage
        {
            public string ImageSource { get; set; }
        }
    }
}
