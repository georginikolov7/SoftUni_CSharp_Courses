
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05_DateModifier
{
    public static class DateModifier
    {
        public static int GetDifferenceInDays(string start, string end)
        {
            //1992 05 31
            int[] date1 = start.Split(" ").Select(int.Parse).ToArray();
            int[] date2 = end.Split(" ").Select(int.Parse).ToArray();
            DateTime firstDate = new DateTime(date1[0], date1[1], date1[2]);
            DateTime secondDate = new DateTime(date2[0], date2[1], date2[2]);
            return Math.Abs((firstDate - secondDate).Days);
        }

    }
}
