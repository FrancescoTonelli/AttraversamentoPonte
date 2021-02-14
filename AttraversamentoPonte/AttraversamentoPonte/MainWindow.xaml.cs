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

            Start();
        }


        Random r = new Random();
        int macchineADx, macchineASx;
        bool blocco;
        public object ponte = new object();
        Dictionary<int, Image> autoDx = new Dictionary<int, Image>();
        Dictionary<int, Image> autoSx = new Dictionary<int, Image>();

        private void Start()
        {
            imgStopDx.Visibility = Visibility.Hidden;
            imgStopSx.Visibility = Visibility.Hidden;
            autoDx1.Visibility = Visibility.Hidden;
            autoDx.Add(1, autoDx1);
            autoDx2.Visibility = Visibility.Hidden;
            autoDx.Add(2, autoDx2);
            autoDx3.Visibility = Visibility.Hidden;
            autoDx.Add(3, autoDx3);
            autoDx4.Visibility = Visibility.Hidden;
            autoDx.Add(4, autoDx4);
            autoDx5.Visibility = Visibility.Hidden;
            autoDx.Add(5, autoDx5);
            autoDx6.Visibility = Visibility.Hidden;
            autoDx.Add(6, autoDx6);
            autoDx7.Visibility = Visibility.Hidden;
            autoDx.Add(7, autoDx7);
            autoDx8.Visibility = Visibility.Hidden;
            autoDx.Add(8, autoDx8);
            autoDx9.Visibility = Visibility.Hidden;
            autoDx.Add(9, autoDx9);
            autoDx10.Visibility = Visibility.Hidden;
            autoDx.Add(10, autoDx10);
            autoSx1.Visibility = Visibility.Hidden;
            autoSx.Add(1, autoSx1);
            autoSx2.Visibility = Visibility.Hidden;
            autoSx.Add(2, autoSx2);
            autoSx3.Visibility = Visibility.Hidden;
            autoSx.Add(3, autoSx3);
            autoSx4.Visibility = Visibility.Hidden;
            autoSx.Add(4, autoSx4);
            autoSx5.Visibility = Visibility.Hidden;
            autoSx.Add(5, autoSx5);
            autoSx6.Visibility = Visibility.Hidden;
            autoSx.Add(6, autoSx6);
            autoSx7.Visibility = Visibility.Hidden;
            autoSx.Add(7, autoSx7);
            autoSx8.Visibility = Visibility.Hidden;
            autoSx.Add(8, autoSx8);
            autoSx9.Visibility = Visibility.Hidden;
            autoSx.Add(9, autoSx9);
            autoSx10.Visibility = Visibility.Hidden;
            autoSx.Add(10, autoSx10);

            btnPlay.Visibility = Visibility.Hidden;

            Thread AggiuntaMacchine = new Thread(new ThreadStart(AggiungiMacchine));
            Thread MuoviMacchineDaDx = new Thread(new ThreadStart(MuoviDaDx));
            Thread MuoviMacchineDaSx = new Thread(new ThreadStart(MuoviDaSx));
            AggiuntaMacchine.Start();
            MuoviMacchineDaDx.Start();
            MuoviMacchineDaSx.Start();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            blocco = true;
            lblMacchineDx.Content = "";
            lblMacchineSx.Content = "";
        }

        public void AggiungiMacchine()
        {
            macchineADx = 0;
            macchineASx = 0;
            blocco = false;

            while(!blocco)
            {
                int ind = r.Next(1, 3);
                if (ind == 1 && macchineADx <= 10)
                {
                    macchineADx++;
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {

                        lblMacchineDx.Content = "Macchine in attesa: " + macchineADx;

                    }));
                }
                if (ind == 2 && macchineASx <= 10)
                {
                    macchineASx++;
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {

                        lblMacchineSx.Content = "Macchine in attesa: " + macchineASx;

                    }));
                }
                Thread.Sleep(TimeSpan.FromSeconds(r.Next(5, 11)));
            }
        }

        public void MuoviDaDx()
        {
            lock (ponte)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgStopSx.Visibility = Visibility.Visible;
                    while(macchineADx != 0)
                    {
                        for (int i = 0; i < macchineADx; i++)
                        {
                            autoSx[i].Visibility = Visibility.Visible;
                            autoSx[i].Margin = new Thickness(172, 231, 0, 0);
                            Thread.Sleep(TimeSpan.FromSeconds(r.Next(1, 3)));
                            autoSx[i].Margin = new Thickness(419, 231, 0, 0);
                            Thread.Sleep(TimeSpan.FromSeconds(r.Next(1, 3)));
                            autoSx[i].Margin = new Thickness(682, 231, 0, 0);
                            autoSx[i].Visibility = Visibility.Hidden;
                            autoSx[i].Margin = new Thickness(1, 231, 0, 0);
                            macchineASx--;
                            lblMacchineSx.Content = "Macchine in attesa: " + macchineASx;
                        }
                    }
                    imgStopSx.Visibility = Visibility.Hidden;

                }));
            }
        }

        public void MuoviDaSx()
        {
            lock (ponte)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgStopDx.Visibility = Visibility.Visible;
                    while (macchineADx != 0)
                    {
                        for (int i = 0; i < macchineADx; i++)
                        {
                            autoDx[i].Visibility = Visibility.Visible;
                            autoDx[i].Margin = new Thickness(462, 231, 0, 0);
                            Thread.Sleep(TimeSpan.FromSeconds(r.Next(1, 3)));
                            autoDx[i].Margin = new Thickness(236, 231, 0, 0);
                            Thread.Sleep(TimeSpan.FromSeconds(r.Next(1, 3)));
                            autoDx[i].Margin = new Thickness(10, 231, 0, 0);
                            autoDx[i].Visibility = Visibility.Hidden;
                            autoDx[i].Margin = new Thickness(692, 231, 0, 0);
                            macchineADx--;
                            lblMacchineDx.Content = "Macchine in attesa: " + macchineADx;
                        }
                    }
                    imgStopDx.Visibility = Visibility.Hidden;

                }));
            }
        }
    }
}
