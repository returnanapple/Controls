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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Controls
{
    public partial class BetBar : UserControl
    {
        public BetBar()
        {
            InitializeComponent();
        }

        #region 依赖属性
        /// <summary>
        /// 位
        /// </summary>
        public string Tittle
        {
            get { return (string)GetValue(TittleProperty); }
            set { SetValue(TittleProperty, value); }
        }
        public static readonly DependencyProperty TittleProperty =
            DependencyProperty.Register("Tittle", typeof(string), typeof(BetBar), new PropertyMetadata("", (d, e) =>
            {
                BetBar td = (BetBar)d;
                string te = (string)e.NewValue;
                td.TittleImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", te), UriKind.RelativeOrAbsolute));
            }));


        public IEnumerable<SingleSelect> AllSingleSelect
        {
            get { return (IEnumerable<SingleSelect>)GetValue(AllSingleSelectProperty); }
            set { SetValue(AllSingleSelectProperty, value); }
        }
        public static readonly DependencyProperty AllSingleSelectProperty =
            DependencyProperty.Register("AllSingleSelect", typeof(IEnumerable<SingleSelect>), typeof(BetBar), new PropertyMetadata(null, (d, e) => 
            {
                BetBar td = (BetBar)d;
                td.SingleSelectItemsControl.Items.Clear();
                td.SingleSelectItemsControl.ItemsSource = (IEnumerable<SingleSelect>)e.NewValue;
            }));




        #endregion
    }
}
