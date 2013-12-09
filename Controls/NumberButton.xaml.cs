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
    public partial class NumberButton : CheckBox
    {
        public NumberButton()
        {
            InitializeComponent();
            this.Style = (Style)this.Resources["NewCheckBoxStyle"];
        }

        #region 重写OnApplyTemplate函数
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            commonStatesTextImage = (Image)GetTemplateChild("ImageOfCommonStatesText");
            checkStatesTextImage = (Image)GetTemplateChild("ImageOfCheckStatesText");
            commonStatesTextImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", Text), UriKind.RelativeOrAbsolute));
            checkStatesTextImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", Text), UriKind.RelativeOrAbsolute));
        }
        #endregion

        #region 私有变量
        Image commonStatesTextImage;
        Image checkStatesTextImage;
        #endregion

        #region 依赖属性
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NumberButton), new PropertyMetadata("", (d, e) =>
            {
                NumberButton td = (NumberButton)d;
                string te = (string)e.NewValue;
                if (td.commonStatesTextImage != null && td.checkStatesTextImage != null)
                {
                    td.commonStatesTextImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", te), UriKind.RelativeOrAbsolute));
                    td.checkStatesTextImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", te), UriKind.RelativeOrAbsolute));
                }
            }));
        #endregion
    }
}
