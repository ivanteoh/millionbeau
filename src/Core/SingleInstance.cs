using System;
using System.Collections.Generic;
using System.Text;
using System.IO; // Namespace for FileSystemInfo class
using System.Threading; // Namespace for Mutex class
using System.Reflection; // Namespace for Assembly class

namespace MillionBeauty
{
    public static class SingleInstance
    {
        private static Mutex mutex;

        public static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location; // Get the application path.
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            bool firstInstance;

            mutex = new Mutex(true, "Global\\" + sExeName, out firstInstance);
            if (firstInstance)
                mutex.ReleaseMutex(); // Release the application lock.
            return !firstInstance;
        }      
    }
}
