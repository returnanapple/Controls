using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class BetInfo
    {
        public string Tittle { get; set; }
        public ObservableCollection<SingleSelect> AllSingleSelect { get; set; }

        public BetInfo(string tittle, ObservableCollection<SingleSelect> allSingleSelect)
        {
            Tittle = tittle;
            AllSingleSelect = allSingleSelect;
        }

        public event EventHandler ReflashResult;
        public void OnReflashResult(object sender, PropertyChangedEventArgs e)
        {
            if (ReflashResult != null && e.PropertyName == "Selected")
            {
                ReflashResult(this, new EventArgs());
            }
        }
    }
}
