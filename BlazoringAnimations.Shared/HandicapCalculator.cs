using System;
using System.Collections.Generic;
//Adapted from https://github.com/AthensWorks/golf-handicap.git
namespace BlazoringAnimations.Shared
{
    public class HandicapCalculator
    {
        public static double GetHandicap(List<Round> scoreList)
        {
            var diffList = new List<double>();
            var resultDiffs = new List<double>();
            for (int i = 0; i < scoreList.Count; i++) // Loop through List with for
            {
                var diff = 0.0;
                var c = scoreList[i];
                diff = (c.Score - c.Rating) * 113 / (double)c.Slope;
                diffList.Add(diff);
            }
            resultDiffs = GetCorrectDiffs(diffList);
            double sum = 0;
            for (int i = 0; i < resultDiffs.Count; i++) // Loop through List with for
            {
                double c = resultDiffs[i];
                sum += c;
            }
            double result = sum / resultDiffs.Count;
            result = result * .96;
            result = Math.Truncate(10 * result) / 10;
            return result;
        }
        private static List<double> GetCorrectDiffs(List<double> orgDiffs)
        {
            var result = new List<double>();
            var count = orgDiffs.Count;
            var numDiffs = NumLowest(count);
            orgDiffs.Sort();
            for (int i = 0; i < numDiffs; i++)
            {
                result.Add(orgDiffs[i]);
            }
            return result;
        }
        private static int NumLowest(int num)
        {
            switch (num)
            {
                case 5:
                case 6:
                    return 1;
                case 7:
                case 8:
                    return 2;
                case 9:
                case 10:
                    return 3;
                case 11:
                case 12:
                    return 4;
                case 13:
                case 14:
                    return 5;
                case 15:
                case 16:
                    return 6;
                case 17:
                    return 7;
                case 18:
                    return 8;
                case 19:
                    return 9;
                case 20:
                    return 10;
                default:
                    return 0;
            }
        }
    }
}
