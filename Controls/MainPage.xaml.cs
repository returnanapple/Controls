using Controls.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Controls
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            rtarc.EndTime = new DateTime(2013,12,9,20,50,1);
        }
    }
}
