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
    public partial class SubPlayTagButton : RadioButton
    {
        public SubPlayTagButton()
        {
            InitializeComponent();
            this.Style = (Style)this.Resources["NewRadioButtonStyleOfFontContent"];
        }
        #region 重写OnApplyTemplate函数
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            commonStatesText = (TextBlock)GetTemplateChild("TextOfCommonStates");
            checkStatesText = (TextBlock)GetTemplateChild("TextOfCheckStates");
            commonStatesText.Text = Text;
            checkStatesText.Text = Text;
        }
        #endregion

        #region 私有变量
        TextBlock commonStatesText;
        TextBlock checkStatesText;
        #endregion

        #region 依赖属性
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SubPlayTagButton), new PropertyMetadata("", (d, e) =>
            {
                SubPlayTagButton td = (SubPlayTagButton)d;
                if (td.commonStatesText != null && td.checkStatesText != null)
                {
                    td.commonStatesText.Text = (string)e.NewValue;
                    td.checkStatesText.Text = (string)e.NewValue;
                }
            }));
        #endregion
    }
}
