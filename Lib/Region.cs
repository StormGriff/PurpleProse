﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGit.Lib
{
    public class Region : Location
    {
        public Region(string name, string desc, string hist, List<string> images) : base(name, desc, hist, images)
        { }

        private string terrain { get; set; }
    }
}