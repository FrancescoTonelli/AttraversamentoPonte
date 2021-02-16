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

        Thread d1, d2, d3, d4, d5, d6, d7, d8, d9, d10;
        Thread s1, s2, s3, s4, s5, s6, s7, s8, s9, s10;

        private void Start()
        {
            imgStopDx.Visibility = Visibility.Hidden;
            imgStopSx.Visibility = Visibility.Hidden;
            autoDx1.Visibility = Visibility.Hidden;
            autoDx2.Visibility = Visibility.Hidden;
            autoDx3.Visibility = Visibility.Hidden;
            autoDx4.Visibility = Visibility.Hidden;
            autoDx5.Visibility = Visibility.Hidden;
            autoDx6.Visibility = Visibility.Hidden;
            autoDx7.Visibility = Visibility.Hidden;
            autoDx8.Visibility = Visibility.Hidden;
            autoDx9.Visibility = Visibility.Hidden;
            autoDx10.Visibility = Visibility.Hidden;
            autoSx1.Visibility = Visibility.Hidden;
            autoSx2.Visibility = Visibility.Hidden;
            autoSx3.Visibility = Visibility.Hidden;
            autoSx4.Visibility = Visibility.Hidden;
            autoSx5.Visibility = Visibility.Hidden;
            autoSx6.Visibility = Visibility.Hidden;
            autoSx7.Visibility = Visibility.Hidden;
            autoSx8.Visibility = Visibility.Hidden;
            autoSx9.Visibility = Visibility.Hidden;
            autoSx10.Visibility = Visibility.Hidden;

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
                        for (int i = 1; i <= macchineADx; i++)
                        {
                            
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
                        for (int i = 1; i <= macchineADx; i++)
                        {
                            
                        }
                    }
                    imgStopDx.Visibility = Visibility.Hidden;

                }));
            }
        }
    }
}
