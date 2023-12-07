using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Backend.SocialNetworkAPI.Model
{
    public class Photo
    {
        [Key]
        public Guid Id { get; set; }

        public string Url { get; set; }

        /*
         * Type = 0 => img
         * Type = 1 => vid
         */
        public short Type { get; set; }

        public string IdPost { get; set; }

        public string? IdComment { get; set; }

        public short Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}