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
    public partial class HistoryResultIcon : UserControl
    {
        public HistoryResultIcon()
        {
            InitializeComponent();
        }
        #region 依赖属性
        /// <summary>
        /// 数字
        /// </summary>
        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(int), typeof(HistoryResultIcon), new PropertyMetadata(0));
        #endregion
    }
}
