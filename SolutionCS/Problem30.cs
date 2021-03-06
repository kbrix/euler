﻿using System;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem30
    {
        public static int Solution(int p)
        {
            var min = 2 * Math.Pow(2, p);
            var max = p * Math.Pow(9, p);

            var sum = 0;

            for (var i = (int)min; i <= (int)max; i++)
            {
                var y = i.DigitSum(p);

                if (i == y)
                {
                    sum += y;
                }
            }

            return sum;
        }
    }
}
