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
using System.Threading;

namespace AttraversamentoPonte
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ImageSource immAutoDx = new BitmapImage(uriAutoDx);
            imgAutoDx1.Source = immAutoDx;

        }

        object dx1 = new object();

        readonly Uri uriAutoDx = new Uri("autodx.png", UriKind.Relative);

        Random r = new Random();

        private void tmp_Click(object sender, RoutedEventArgs e)
        {
            int newMargin = 682;
            while (newMargin > 40)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(5, 7)));
                newMargin -= 1;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgAutoDx1.Margin = new Thickness(newMargin, 204, 0, 0);
                }));
            }
            
        }
    }
}
