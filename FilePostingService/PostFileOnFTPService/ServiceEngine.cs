using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostFileOnFTPService
{
    [System.Runtime.InteropServices.Guid("02d1ba1c-a7a8-460d-9a0f-c85fbd059473")]
    public class ServiceEngine
    {

        public void StartServiceEngine()
        {

        AppStart:
            try
            {
                while (true)
                {
                    #region Scan directory and Post File
                    ScanAndPostFile();
                    #endregion

                    #region Update Last Execution
                    Settings.lastExecutionTime = DateTime.Now;
                    Settings.appSettings["ServiceSettings"]["LastExecutionTime"] = Settings.lastExecutionTime.ToString("yyyy-MM-dd HH:mm:ss");
                    Settings.UpdateAppSettings();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                //Log
                Thread.Sleep(TimeSpan.FromSeconds(15));
                goto AppStart;
            }
        }

        void ScanAndPostFile()
        {
            try
            {

            }
            catch (Exception ex)
            {


            }
        }
    }
}
