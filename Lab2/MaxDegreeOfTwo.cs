using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    static class MaxDegreeOfTwo
    {
        private static ulong SolveFromOneToX(ulong x)
        {
            ulong ans = 0;
            while (x > 0)
            {
                ans += x / 2;
                x /= 2;
            }
            return ans;
        }
        public static ulong Solve(ulong leftBound, ulong rightBound)
        {
            if (leftBound == 0 || leftBound > rightBound)
            {
                throw new Exception("Неправильно введены числа\n");
            }
            return SolveFromOneToX(rightBound) - SolveFromOneToX(leftBound - 1); ;
        }
        public static ulong SlowSolve(ulong leftBound, ulong rightBound)
        {
            ulong ans = 0;
            for (ulong i = leftBound; i <= rightBound; i++)
            {
                ulong t = i;
                while (t % 2 == 0)
                {
                    ans++;
                    t /= 2;
                }
            }
            return ans;
        }
        public static ulong BigIntSolve(ulong leftBound, ulong rightBound)
        {
            System.Numerics.BigInteger tmp = 1;
            for (ulong i = leftBound; i <= rightBound; i++)
            {
                tmp *= i;
            }
            ulong ans = 0;
            while (tmp % 2 == 0)
            {
                ans++;
                tmp /= 2;
            }
            return ans;
        }
    }
}
