﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInventoryManagement.Application.Common.ViewModels
{
    public class Authenticationvm
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
