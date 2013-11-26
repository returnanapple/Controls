﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Controls.Classes
{
    public class SelectResult
    {
        public string Tittle { get; set; }
        public List<string> Data { get; set; }

        public SelectResult(string t, List<string> d)
        {
            Tittle = t;
            Data = d;
        }
    }
}
