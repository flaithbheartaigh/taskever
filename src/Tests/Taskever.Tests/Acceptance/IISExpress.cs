using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Taskever.Tests.Acceptance
{
    public class IISExpress : IDisposable
    {
        private Boolean _isDisposed;
        private Process _process;

        private IList<String> StartedSites = new List<String>();

        public void Dispose()
        {
            Dispose(true);
        }

        public void Start(String siteName, String appHostsConfigFile = null)
        {
            if(StartedSites.Contains(siteName))
                return;

            StartedSites.Add(siteName);

            var configfile = appHostsConfigFile == null ? "" : " /config:" + appHostsConfigFile;

            var iisExpressPath = DetermineIisExpressPath();
            var arguments = String.Format(
                CultureInfo.InvariantCulture, "/site:\"{0}\"{1}", siteName, configfile);

            // TODO: Redirect output so that tests get a log from the web server
            var info = new ProcessStartInfo(iisExpressPath)
            {
                WindowStyle = ProcessWindowStyle.Normal,
                ErrorDialog = true,
                LoadUserProfile = true,
                CreateNoWindow = false,
                UseShellExecute = false,
                Arguments = arguments
            };

            var startThread = new Thread(() => StartIISExpress(info))
            {
                IsBackground = true
            };

            startThread.Start();
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                if (_process.HasExited == false)
                {
                    _process.Kill();
                }

                _process.Dispose();
            }

            _isDisposed = true;
        }

        private static String DetermineIisExpressPath()
        {
            String iisExpressPath;

            iisExpressPath = Environment.GetFolderPath(Environment.Is64BitOperatingSystem
                ? Environment.SpecialFolder.ProgramFilesX86
                : Environment.SpecialFolder.ProgramFiles);

            iisExpressPath = Path.Combine(iisExpressPath, @"IIS Express\iisexpress.exe");

            return iisExpressPath;
        }

        private void StartIISExpress(ProcessStartInfo info)
        {
            try
            {
                _process = Process.Start(info);

                _process.WaitForExit();
            }
            catch (Exception)
            {
                Dispose();
            }
        }
    }
}
