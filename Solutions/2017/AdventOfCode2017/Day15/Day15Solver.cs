namespace AdventOfCode2017.Day15
{
    using System;

    public class Day15Solver
    {
        public int PuzzleOne(int a, int b)
        {
            var aLong = (long)a;
            var bLong = (long)b;

            var aFactor = 16807L;
            var bFactor = 48271L;

            var sum = 0;

            for (var i = 0; i < 40000000; i++)
            {
                aLong = (aLong * aFactor) % int.MaxValue;
                bLong = (bLong * bFactor) % int.MaxValue;

                var aBinary = ToBinary(aLong);
                var bBinary = ToBinary(bLong);

                if (aBinary.Substring(16, 16) == bBinary.Substring(16, 16))
                {
                    sum++;
                }
            }

            return sum;
        }
        public int PuzzleTwo(int a, int b)
        {
            var aLong = (long)a;
            var bLong = (long)b;

            var aFactor = 16807L;
            var bFactor = 48271L;

            var aMultiple = 4;
            var bMultiple = 8;

            var sum = 0;

            for (var i = 0; i < 5000000; i++)
            {
                do
                {
                    aLong = (aLong * aFactor) % int.MaxValue;
                }
                while (aLong % aMultiple != 0);

                do
                {
                    bLong = (bLong * bFactor) % int.MaxValue;
                }
                while (bLong % bMultiple != 0);

                var aBinary = ToBinary(aLong);
                var bBinary = ToBinary(bLong);

                if (aBinary.Substring(16, 16) == bBinary.Substring(16, 16))
                {
                    sum++;
                }
            }

            return sum;
        }

        private static string ToBinary(long number)
            => Convert.ToString(number, 2).PadLeft(32, '0');
    }
}