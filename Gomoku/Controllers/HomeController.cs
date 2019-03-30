using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Gomoku.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System;

namespace Gomoku.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Record record = HttpContext.Session.Get<Record>("record");
            if (record == null)
            {
                record = new Record(true);
            }
            else if (record.Sente == false && !record.Records.Any())
            {
                Random rand = new Random();
                record.Records.Add(new int[] { rand.Next(5, 10), rand.Next(5, 10) });
            }
            HttpContext.Session.Set("record", record);
            return View(record);
        }

        [HttpPost]
        public string Move(int i, int j)
        {
            Record record = HttpContext.Session.Get<Record>("record");
            if (record.Records.Exists(_ => _[0] == i && _[1] == j))
                return "exist";
            record.Records.Add(new int[2] { i, j });
            HttpContext.Session.Set("record", record);
            if (Winner() != "")
                return "";
            int[] c = Computer();
            return c[0] + "," + c[1];
        }

        public int[] Computer()
        {
            int w = Wins.WinList.Count();
            Record record = HttpContext.Session.Get<Record>("record");
            int[] player;
            int[] computer;
            if (record.Sente)
            {
                player = record.Black;
                computer = record.White;
            }
            else
            {
                player = record.White;
                computer = record.Black;
            }

            int[][] playerScore = new int[15][];
            int[][] computerScore = new int[15][];
            for (int i = 0; i < 15; i++)
            {
                playerScore[i] = new int[15];
                computerScore[i] = new int[15];
            }

            int s = 0;
            int max = 0;
            int u = 0, v = 0;
            for (var i = 0; i < 15; i++)
            {
                for (var j = 0; j < 15; j++)
                {
                    if (!record.Records.Exists(_ => _[0] == i && _[1] == j))
                    {
                        for (var k = 0; k < w; k++)
                        {
                            if (Wins.WinList[k].Exists(_ => _[0] == i && _[1] == j))
                            {
                                s = 0;
                                switch (player[k])
                                {
                                    case 1:
                                        s = 200;
                                        break;
                                    case 2:
                                        s = 400;
                                        break;
                                    case 3:
                                        s = 2000;
                                        break;
                                    case 4:
                                        s = 10000;
                                        break;
                                }
                                playerScore[i][j] += s;

                                s = 0;
                                switch (computer[k])
                                {
                                    case 1:
                                        s = 220;
                                        break;
                                    case 2:
                                        s = 420;
                                        break;
                                    case 3:
                                        s = 2200;
                                        break;
                                    case 4:
                                        s = 20000;
                                        break;
                                }
                                computerScore[i][j] += s;

                                if (playerScore[i][j] > max)
                                {
                                    max = playerScore[i][j];
                                    u = i;
                                    v = j;
                                }
                                else if (playerScore[i][j] == max)
                                {
                                    if (computerScore[i][j] > computerScore[u][v])
                                    {
                                        u = i;
                                        v = j;
                                    }
                                }

                                if (computerScore[i][j] > max)
                                {
                                    max = computerScore[i][j];
                                    u = i;
                                    v = j;
                                }
                                else if (computerScore[i][j] == max)
                                {
                                    if (playerScore[i][j] > playerScore[u][v])
                                    {
                                        u = i;
                                        v = j;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!"+max);
            if (!record.Records.Exists(_ => _[0] == u && _[1] == v))
            {
                int[] c = { u, v };
                record.Records.Add(c);
                HttpContext.Session.Set("record", record);
                return c;
            }
            return null;
        }

        [HttpGet]
        public string Winner()
        {
            int w = Wins.WinList.Count();
            int[] black = new int[w];
            int[] white = new int[w];
            Record record = HttpContext.Session.Get<Record>("record");
            if (record == null)
            {
                return "";
            }
            for (int i = 0; i < record.Records.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < w; j++)
                    {
                        if (Wins.WinList[j].Exists(_ => _[0] == record.Records[i][0] && _[1] == record.Records[i][1]))
                        {
                            black[j]++;
                            white[j] = 6;
                            if (black[j] == 5)
                            {
                                return "black win";
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < w; j++)
                    {
                        if (Wins.WinList[j].Exists(_ => _[0] == record.Records[i][0] && _[1] == record.Records[i][1]))
                        {
                            white[j]++;
                            black[j] = 6;
                            if (white[j] == 5)
                            {
                                return "white win";
                            }
                        }
                    }
                }
            }
            record.Black = black;
            record.White = white;
            HttpContext.Session.Set("record", record);
            if (black.All(_ => _ > 5) && white.All(_ => _ > 5))
            {
                return "draw";
            }
            return "";
        }


        [HttpGet]
        public void Restart()
        {
            bool sente = HttpContext.Session.Get<Record>("record").Sente;
            HttpContext.Session.Clear();
            Record record = new Record(sente);
            HttpContext.Session.Set("record", record);
        }

        [HttpGet]
        public void Sente()
        {
            bool sente = HttpContext.Session.Get<Record>("record").Sente;
            HttpContext.Session.Clear();
            Record record = new Record(!sente);
            HttpContext.Session.Set("record", record);
        }

        [HttpGet]
        public void Regret()
        {
            Record record = HttpContext.Session.Get<Record>("record");
            record.Records.RemoveAt(record.Records.Count() - 1);
            if (record.Sente == true && record.Records.Count() % 2 ==1 || record.Sente == false && record.Records.Count() % 2 == 0)
                record.Records.RemoveAt(record.Records.Count() - 1);
            HttpContext.Session.Set("record", record);
        }

        public IActionResult Help()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Debug.WriteLine("error");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
