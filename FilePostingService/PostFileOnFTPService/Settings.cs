using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PostFileOnFTPService
{
    public class Settings
    {
        #region Settings
        public static JObject appSettings;
        static string appSettingsFile;
        public static DateTime lastExecutionTime;
        public static int runEveryAfterXSeconds;

        #endregion
        static Settings()
        {
            string appSettingsFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString() + @"\AppSettings.json";
            if (!File.Exists(appSettingsFile))
            {
                appSettingsFile = Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).ToString() + @"\AppSettings.json";
            }

            appSettings = new JObject(File.ReadAllText(appSettingsFile));
            if(appSettings != null)
            {
                lastExecutionTime = Convert.ToDateTime(appSettings["ServiceSettings"]["LastExecutionTime"]);
                runEveryAfterXSeconds= Convert.ToInt32(appSettings["ServiceSettings"]["RunEveryAfterXSeconds"]);
            }
        }

        public static void UpdateAppSettings()
        {
            try
            {
                File.WriteAllText(appSettingsFile, JsonConvert.SerializeObject(appSettings,Formatting.Indented));
            }
            catch (Exception ex)
            {

            }
        }
    }
}
