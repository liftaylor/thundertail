using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkDataSourceTest
{
    class Program
    {
        static void DebugLog(int level, string msg)
        {
            System.Console.WriteLine("DEBUG {0}: {1}", Spark.LogLevelStr(level), msg);
        }

        static void Main(string[] args)
        {
            int i;
            string username, passwd, code;

            if (args.Length < 3)
            {
                System.Console.WriteLine("Usage: <username> <passwd> <code> [ depth | orders | trades | history | news ]...");
                return;
            }

            username = args[0];
            passwd = args[1];
            code = args[2];

            Spark.Init();
            Spark.SetLogin(username, passwd);
            // Spark.SetCacheDir("cachedir", -1);

            Spark.SetLogCallback(new Spark.LogCallback(DebugLog));

            for (i = 3; i < args.Length; i++)
            {
                if (args[i] == "news")
                {
                    Spark.SetOptions(Spark.OPTION_INFO);
                }
            }

            if (!Spark.Connect())
            {
                System.Console.WriteLine("can't connect: {0}", Spark.DescribeError(Spark.GetLastError()));
                return;
            }

            Spark.Stock stock = new Spark.Stock();

            if (!Spark.GetStock(ref stock, code, ""))
            {
                System.Console.WriteLine("can't get {0}: {1}",
                                         code, Spark.DescribeError(Spark.GetLastError()));
            }
            else
            {
                System.Console.WriteLine("{0} {1} {2}", stock.Code, stock.Last, stock.Volume);

                for (i = 3; i < args.Length; i++)
                {
                    if (args[i] == "depth")
                    {
                        Spark.Depth depth = new Spark.Depth();
                        if (Spark.GetStockDepth(ref stock, ref depth, 10, false))
                        {
                            foreach (Spark.DepthLevel level in Spark.Levels(depth.bids))
                            {
                                System.Console.WriteLine("B {0,7} {1,9} {2,4}",
                                                         level.Price, level.Volume, level.Count);
                            }
                            foreach (Spark.DepthLevel level in Spark.Levels(depth.offers))
                            {
                                System.Console.WriteLine("S {0,7} {1,9} {2,4}",
                                                         level.Price, level.Volume, level.Count);
                            }
                        }
                    }

                    if (args[i] == "orders")
                    {
                        foreach (Spark.DepthDetail detail in Spark.Orders(code, "", 0))
                        {
                            System.Console.WriteLine("{0} {1,7} {2,9} {3:s}",
                                                     ((detail.Flags & Spark.DEPTH_FLAG_BID) != 0) ? "B" : "S",
                                                     detail.Price, detail.Volume,
                                                     Spark.TimeToDateTime(detail.TimePlaced));
                        }
                    }

                    if (args[i] == "trades")
                    {
                        foreach (Spark.Trade trade in Spark.Trades(code, null))
                        {
                            System.Console.WriteLine("{0:s} {1,7} {2,9}",
                                                     Spark.TimeToDateTime(trade.Time),
                                                     trade.Price, trade.Volume);
                        }
                    }

                    if (args[i] == "pasttrades")
                    {
                        foreach (Spark.Trade trade in Spark.PastTrades(code, null, DateTime.Now.AddDays(-2).Date))
                        {
                            System.Console.WriteLine("{0:s} {1,7} {2,9}",
                                                     Spark.TimeToDateTime(trade.Time),
                                                     trade.Price, trade.Volume);
                        }
                    }

                    if (args[i] == "history")
                    {
                        foreach (Spark.History history in Spark.StockHistory(code, null))
                        {
                            System.Console.WriteLine("{0:yyyy-MM-dd} {1,7} {2,9}",
                                                     Spark.TimeToDateTime(history.Date),
                                                     history.Last, history.Volume);
                        }
                    }

                    if (args[i] == "news")
                    {
                        foreach (Spark.NewsItem news in Spark.NewsHistory(code, null))
                        {
                            System.Console.WriteLine("{0:yyyy-MM-dd} {1}\n{2}",
                                                     Spark.TimeToDateTime(news.Time),
                                                     news.Summary,
                                                     Spark.GetNewsURL(code, "",
                                                                      news.Reference));
                        }
                    }

                    if (args[i] == "memtest")
                    {
                        Spark.Trade trade = new Spark.Trade();

                        for (i = 1; i < 32; i++)
                        {
                            DateTime date = DateTime.Now.AddDays(-i).Date;

                            if (Spark.GetPastStockTrades(ref stock, ref trade, date))
                            {
                                System.Console.WriteLine("{0} trades for {1}", code, date);
                                while (Spark.GetNextPastStockTrade(ref stock, ref trade))
                                {
                                    System.Console.WriteLine("{0:s} {1,7} {2,9}",
                                                             Spark.TimeToDateTime(trade.Time),
                                                             trade.Price, trade.Volume);
                                }

                                Spark.ReleasePastStockEvents(ref stock, date);
                            }
                        }
                    }
                }
            }

            Spark.Disconnect();

            Spark.Exit();
        }
    }
}
