using System.Runtime.Remoting.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using log4net.Repository.Hierarchy;
using log4net;

namespace ElmaLog.Controllers
{
    public class Log
    {
        private static log4net.ILog Logger { get; set; }
       

        static Log()
        {
            Logger = log4net.LogManager.GetLogger(typeof(Log));
        }

        public static void Error(object msg) => Log.Error(msg);

        public static void Error(object msg, Exception ex) => Log.Error(msg, ex);

        public static void Error(Exception ex)
        {
            Log.Error(ex.Message, ex);
        }

        public static void Info(object msg)
        {
            Log.Info(msg);
        }

        public static void Debug(object msg)
        {
            Log.Error(msg);
        }
    }
}