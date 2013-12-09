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
    public partial class ConfirmButton : Button
    {
        public ConfirmButton()
        {
            InitializeComponent();
            this.Style = (Style)this.Resources["NewButtonStyle"];
        }

        #region 重写OnApplyTemplate函数
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            normalImage = (Image)GetTemplateChild("ImageOfNormal");
            pressedImage = (Image)GetTemplateChild("ImageOfPressed");
            normalImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Normal.png", buttonName), UriKind.RelativeOrAbsolute));
            pressedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Pressed.png", buttonName), UriKind.RelativeOrAbsolute));
        }
        #endregion

        #region 私有变量
        Image normalImage;
        Image pressedImage;
        string buttonName = "ConfirmButton";
        #endregion
    }
}
