using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.SocialNetworkAPI.Dto.PhotoDto
{
    public class CreatePhotoDto
    {
        public Guid IdPost { get; set; }
        public Guid? IdComment { get; set; }
        public List<InputPhoto>? InputPhotos { get; set; }
    }

    public class InputPhoto
    {
        public string Url { get; set; }
        public short Type { get; set; }
    }
}