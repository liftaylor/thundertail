using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using NLog.Fluent;

namespace NLogTests
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            for (var i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                Logger.Info("{0}", DateTime.Now);
            }
        }
    }
}
