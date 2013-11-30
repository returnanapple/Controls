using Controls.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class BetTool : UserControl
    {
        public BetTool()
        {
            InitializeComponent();
            BetInfoItemsControl.ItemsSource = OperatingCollection;
        }

        #region 私有变量
        public ObservableCollection<BetInfo> OperatingCollection = new ObservableCollection<BetInfo>();
        #endregion

        #region 依赖属性
        /// <summary>
        /// 所有行标题
        /// </summary>
        public string Row
        {
            get { return (string)GetValue(RowProperty); }
            set { SetValue(RowProperty, value); }
        }
        public static readonly DependencyProperty RowProperty =
            DependencyProperty.Register("Row", typeof(string), typeof(BetTool), new PropertyMetadata("", (d, e) =>
            {
                BetTool td = (BetTool)d;
                string te = (string)e.NewValue;
                List<string> sl = te.Split(new Char[] { ',' }).ToList();
                td.OperatingCollection.Clear();
                for (int i = 0; i < sl.Count; i++)
                {
                    BetInfo bi = new BetInfo(sl[i], new ObservableCollection<SingleSelect>());
                    bi.ReflashResult += td.ReflashResult;
                    td.OperatingCollection.Add(bi);
                }
            }));
        /// <summary>
        /// 第一个数字
        /// </summary>
        public int NumberOfFirst
        {
            get { return (int)GetValue(NumberOfFirstProperty); }
            set { SetValue(NumberOfFirstProperty, value); }
        }
        public static readonly DependencyProperty NumberOfFirstProperty =
            DependencyProperty.Register("NumberOfFirst", typeof(int), typeof(BetTool), new PropertyMetadata(0, (d, e) =>
            {
                BetTool td = (BetTool)d;
                int te = (int)e.NewValue;
                if (te <= td.NumberOfLast)
                {
                    td.OperatingCollection.ToList().ForEach(x =>
                    {
                        x.AllSingleSelect.Clear();
                        for (int i = te; i <= td.NumberOfLast; i++)
                        {
                            SingleSelect ss = new SingleSelect(i.ToString(), false);
                            ss.PropertyChanged += x.OnReflashResult;
                            x.AllSingleSelect.Add(ss);
                        }
                    });
                }
            }));
        /// <summary>
        /// 最后一个数字
        /// </summary>
        public int NumberOfLast
        {
            get { return (int)GetValue(NumberOfLastProperty); }
            set { SetValue(NumberOfLastProperty, value); }
        }
        public static readonly DependencyProperty NumberOfLastProperty =
            DependencyProperty.Register("NumberOfLast", typeof(int), typeof(BetTool), new PropertyMetadata(0, (d, e) =>
            {
                BetTool td = (BetTool)d;
                int te = (int)e.NewValue;
                if (te >= td.NumberOfFirst)
                {
                    td.OperatingCollection.ToList().ForEach(x =>
                    {
                        x.AllSingleSelect.Clear();
                        for (int i = td.NumberOfFirst; i <= te; i++)
                        {
                            SingleSelect ss = new SingleSelect(i.ToString(), false);
                            ss.PropertyChanged += x.OnReflashResult;
                            x.AllSingleSelect.Add(ss);
                        }
                    });

                }
            }));
        /// <summary>
        /// 结果
        /// </summary>
        public List<SelectResult> Result
        {
            get { return (List<SelectResult>)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(List<SelectResult>), typeof(BetTool), new PropertyMetadata(null));
        #endregion

        #region 函数
        public void ReflashResult(object sender, EventArgs e)
        {
            if (Result != null)
            {
                BetInfo bi = (BetInfo)sender;
                if (Result.Any(x => x.Tittle == bi.Tittle))
                {
                    SelectResult sr = Result.First(x => x.Tittle == bi.Tittle);
                    sr.Data.Clear();
                    OperatingCollection.First(x => x.Tittle == bi.Tittle).AllSingleSelect.ToList().Where(x => x.Selected == true).ToList().ForEach(x =>
                    {
                        sr.Data.Add(x.Number);
                    });
                }
                else
                {
                    List<string> sl = new List<string>();
                    OperatingCollection.First(x => x.Tittle == bi.Tittle).AllSingleSelect.ToList().Where(x => x.Selected == true).ToList().ForEach(x =>
                    {
                        sl.Add(x.Number);
                    });
                    Result.Add(new SelectResult(bi.Tittle, sl));
                }
            }
        }
        #endregion
    }
}
