using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PostFileOnFTPService
{
    public partial class PostFileOnFTPServiceWindow : ServiceBase
    {
        private static System.Timers.Timer timer;
        private ServiceEngine service = new ServiceEngine();
        public PostFileOnFTPServiceWindow()
        {
            try
            {
                //Log
                InitializeComponent();
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                //Log
                timer = new System.Timers.Timer()
                {
                    Interval = 10000
                };
                timer.Elapsed += Timer_Elapsed;
                timer.AutoReset = false;
                timer.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                //Log
                timer.Enabled = false;
                service.StartServiceEngine();
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnStop()
        {
            try
            {
                //Log
                timer.Enabled = false;
                timer.Stop();
                timer.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
