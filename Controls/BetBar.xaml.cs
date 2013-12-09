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
            MultiSelectNumberButtons.Children.ToList().ForEach(x => 
            {
                (x as MultiSelectNumberButton).Click += MultiSelect;
            });
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
                td.ImageOfTittle.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", te), UriKind.RelativeOrAbsolute));
            }));
        /// <summary>
        /// 单选列表
        /// </summary>
        public IEnumerable<SingleSelect> SingleSelectList
        {
            get { return (IEnumerable<SingleSelect>)GetValue(SingleSelectListProperty); }
            set { SetValue(SingleSelectListProperty, value); }
        }
        public static readonly DependencyProperty SingleSelectListProperty =
            DependencyProperty.Register("SingleSelectList", typeof(IEnumerable<SingleSelect>), typeof(BetBar), new PropertyMetadata(null, (d, e) =>
            {
                BetBar td = (BetBar)d;
                IEnumerable<SingleSelect> te = (IEnumerable<SingleSelect>)e.NewValue;
                td.Selections.Items.Clear();
                td.Selections.ItemsSource = te;
            }));
        #endregion

        #region 函数
        private void MultiSelect(object sender, RoutedEventArgs e)
        {
            if (SingleSelectList == null)
            {
                return;
            }
            MultiSelectNumberButton s = (MultiSelectNumberButton)sender;
            switch (s.Text)
            {
                case "全":
                    SingleSelectList.ToList().ForEach(x =>
                    {
                        x.Selected = true;
                    });
                    break;
                case "清":
                    SingleSelectList.ToList().ForEach(x =>
                    {
                        x.Selected = false;
                    });
                    break;
                case "大":
                    List<SingleSelect> ssl = SingleSelectList.ToList();
                    for (int i = ssl.Count / 2; i < ssl.Count; i++)
                    {
                        ssl[i].Selected = true;
                    }
                    break;
                case "小":
                    List<SingleSelect> ssl2 = SingleSelectList.ToList();
                    for (int i = 0; i < ssl2.Count / 2; i++)
                    {
                        ssl2[i].Selected = true;
                    }
                    break;
                case "单":
                    SingleSelectList.ToList().ForEach(x =>
                    {
                        if (x.Number % 2 != 0)
                        {
                            x.Selected = true;
                        }
                    });
                    break;
                case "双":
                    SingleSelectList.ToList().ForEach(x =>
                    {
                        if (x.Number % 2 == 0)
                        {
                            x.Selected = true;
                        }
                    });
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
