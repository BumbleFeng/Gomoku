using System;
using System.Collections.Generic;

namespace Gomoku.Models
{
    public static class Wins
    {
        public static List<List<int[]>> WinList { set; get;}

        static Wins()
        {
            WinList = new List<List<int[]>>();
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    List<int[]> win1 = new List<int[]>();
                    List<int[]> win2 = new List<int[]>();
                    for (int k = 0; k < 5; k++)
                    {
                        win1.Add(new int[2] { i, j + k });
                        win2.Add(new int[2] { j + k, i });
                    }
                    WinList.Add(win1);
                    WinList.Add(win2);
                }
            }

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    List<int[]> win = new List<int[]>();
                    for (int k = 0; k < 5; k++)
                    {
                        win.Add(new int[2] { i + k, j + k });
                    }
                    WinList.Add(win);
                }
            }

            for (int i = 0; i < 11; i++)
            {
                for (int j = 14; j > 3; j--)
                {
                    List<int[]> win = new List<int[]>();
                    for (int k = 0; k < 5; k++)
                    {
                        win.Add(new int[2] { i + k, j - k });
                    }
                    WinList.Add(win);
                }
            }
        }
    }
}
