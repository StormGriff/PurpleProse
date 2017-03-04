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
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using MahApps.Metro;

namespace PPGit.GUI
{
    /// <summary>
    /// Interaction logic for AppThemeChanger.xaml
    /// </summary>
    public partial class AppThemeChanger : MetroWindow
    {

        public static readonly DependencyProperty ColorsProperty = DependencyProperty.Register("Colors", typeof(List<KeyValuePair<string, Color>>), typeof(AppThemeChanger), new PropertyMetadata(default(List<KeyValuePair<string, Color>>)));

        public List<KeyValuePair<string, Color>> Colors
        {
            get { return (List<KeyValuePair<string, Color>>)GetValue(ColorsProperty); }
            set { SetValue(ColorsProperty, value); }
        }
              
        public AppThemeChanger()
        {
            InitializeComponent();

            this.DataContext = this;

            this.Colors = typeof(Colors)
                .GetProperties()
                .Where(prop => typeof(Color).IsAssignableFrom(prop.PropertyType))
                .Select(prop => new KeyValuePair<String, Color>(prop.Name, (Color)prop.GetValue(null)))
                .ToList();

            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(this, theme.Item2, theme.Item1);

        }

        private void moreColorExpander_Expanded(object sender, RoutedEventArgs e)
        {
            this.Height += 33;
        }

        private void moreColorExpander_Collapsed(object sender, RoutedEventArgs e)
        {
            this.Height -= 33;
        }

        private void everyColorExpander_Expanded(object sender, RoutedEventArgs e)
        {
            this.Height += 33;
        }

        private void everyColorExpander_Collapsed(object sender, RoutedEventArgs e)
        {
            this.Height -= 33;
        }

        private void moreColorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedAccent = moreColorBox.SelectedItem as Accent;

            if(SelectedAccent != null)
            {
                var Theme = ThemeManager.DetectAppStyle(Application.Current);
                ThemeManager.ChangeAppStyle(Application.Current, SelectedAccent, Theme.Item1);
                Application.Current.MainWindow.Activate();
            }
        }

        private void everyColorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedColor = this.everyColorBox.SelectedItem as KeyValuePair<string, Color>?;
            if(SelectedColor.HasValue)
            {
                var theme = ThemeManager.DetectAppStyle(Application.Current);
                ThemeManagerHelper.CreateAppStyleBy(SelectedColor.Value.Value, true);
                Application.Current.MainWindow.Activate();
            }
        }

        private void btnBaseDark_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("BaseDark"));
        }

        private void btnBaseLight_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("BaseLight"));
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Red"), theme.Item1);
        }

        private void btnGreen_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Green"), theme.Item1);
        }

        private void btnBlue_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Blue"), theme.Item1);
        }

        private void btnPurple_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Purple"), theme.Item1);
        }

        private void btnOrange_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Orange"), theme.Item1);
        }

        private void btnPink_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Pink"), theme.Item1);
        }

        private void btnYellow_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Yellow"), theme.Item1);
        }

        private void btnBrown_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Brown"), theme.Item1);
        }

        private void btnSteel_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Steel"), theme.Item1);
        }
    }
}
