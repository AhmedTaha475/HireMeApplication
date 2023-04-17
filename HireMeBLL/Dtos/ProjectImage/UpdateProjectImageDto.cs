using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.ProectImage
{
    public record UpdateProjectImageDto
    {
        [Required(ErrorMessage = "Please enter project image id")]
        public int PI_id { get; set; }

        [Required(ErrorMessage = "please enter your image")]

        public IFormFile image { get; set; }

    }
}
