using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public static class Helper
    {

        public static byte[] ConvertFromFileToByteArray(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
