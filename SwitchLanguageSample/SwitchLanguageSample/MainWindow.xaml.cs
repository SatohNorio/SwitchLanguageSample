using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SwitchLanguageSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<object, string> FCultureDictionary = new Dictionary<object, string>();

        public MainWindow()
        {
            InitializeComponent();
            //FLabel.Content = Properties.Resources.Hello;
            FCultureDictionary.Add(miJp, "ja-jp");
            FCultureDictionary.Add(miEn, "en-US");
            FCultureDictionary.Add(miCn, "zh-CN");
            FCultureDictionary.Add(miKo, "ko-KR");
            SetLanguage("ja-jp");
        }

        private void SetLanguage(string cultureCode)
        {
            var dic = new ResourceDictionary();
            dic.Source = new Uri(@"Resources/Dictionary1." + cultureCode + @".xaml", UriKind.Relative);
            var grid = this.FGrid;
            grid.Resources.Clear();
            grid.Resources.MergedDictionaries.Add(dic);
        }

        private void MenuItem_Setting_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetLanguage(FCultureDictionary[sender]);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
