﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos
{
    public record ProjectImgDto
    {
        public byte[] Image { get; init; }
    }
}
