using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace easySaveV3
{
    /// <summary>
    /// Interaction logic for ProgressBars.xaml
    /// </summary>
    public partial class ProgressBars : Window
    {

        ConfigHelper ConfH = new ConfigHelper();


        public ProgressBars()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e) //fonction qui contient les paramètre de mise a jour A CHANGER
        {

            //MessageBox.Show(ConfH.GetParticularKeyValue("RemainingLength100"));
            //while (Int32.Parse(ConfH.GetParticularKeyValue("RemainingLength100"))>10)
            //{
            //for (int i = 0; i < 100000; i++)
            //{
            while (true) {

                int u = 101 - Int32.Parse(ConfH.GetParticularKeyValue("RemainingLength100"));
                //MessageBox.Show(u.ToString());
                (sender as BackgroundWorker).ReportProgress(u);
                Thread.Sleep(10);
            }
               // }
            ////}
            
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            savepbar.Value = e.ProgressPercentage;
        }

        private void btnPlayPause_Click(object sender, RoutedEventArgs e)
        {
            if (Model.loadsaveThread.ThreadState == ThreadState.Running)
            {
                Model.loadsaveThread.Suspend();
                btnPlayPause.Content = "Play";
            }
                
            else if (Model.loadsaveThread.ThreadState == ThreadState.Suspended)
            {
                Model.loadsaveThread.Resume();
                btnPlayPause.Content = "Pause";
            }
                
        }
    }
}
