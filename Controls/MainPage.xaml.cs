using Controls.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
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
            List<string> sl = new List<string> { "1", "2", "3" };
            string xamlString = @"<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                                                xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                                      <StackPanel Orientation=""Horizontal"" >
                                          <TextBlock Text=""{Binding}"" TextAlignment=""Center"" Width=""200""/>
                                      </StackPanel>
                                  </DataTemplate>";
            DataTemplate dt = (DataTemplate)XamlReader.Load(xamlString);
            tt.RowTemplate = dt;
            tt.RowsSource = sl;
        }
    }
}
