﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record ProjectCommentReadDto (int commentID, string Comment ,UserChildReadDto clientChild );
}
