using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record CreateProjectImageDto
    {
        [Required(ErrorMessage ="Please enter project id")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage ="Please insert the image")]
        public IFormFile  Image { get; set; }
    }
}
