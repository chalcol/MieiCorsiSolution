﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MieiCorsi.Models.Services.Infrastructure
{
    public interface IDatabaseAccessor
    {
        DataSet Query(string query);
    }
}
