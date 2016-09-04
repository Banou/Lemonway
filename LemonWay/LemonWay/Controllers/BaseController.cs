using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LemonWay.Controllers
{
    public class BaseController : ApiController
    {
        public static readonly ILog logger = LogManager.GetLogger("LogFileAppender");
        public static readonly ILog InfoLog = LogManager.GetLogger("RequestLog");

        public static void logFormat(Exception e)
        {
            logger.ErrorFormat("Message : {0}", e.Message);
            if (e.InnerException != null)
            {
                logger.Error("-------------------------------");
                if (e.InnerException.InnerException != null)
                    logger.ErrorFormat("InnerException Message : {0}", e.InnerException.InnerException.Message);
                else
                    logger.ErrorFormat("InnerException Message : {0}", e.InnerException.Message);
            }
            logger.Error("-------------------------------");
            logger.ErrorFormat("StackTrace : {0}", e.StackTrace);
        }

        public static void logRequest(string str)
        {
            InfoLog.InfoFormat(str);
        }
    }
}
