using System;

namespace SharePic.API.ViewModels
{
    public class SharePicViewModel
    {
        public Guid From { get; set; }
        public Guid To { get; set; }
        public string Pic { get; set; }
        public int Duration { get; set; }

    }
}
