using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Dtos
{
    public class UpdatedSocialMediaDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
    }
}
