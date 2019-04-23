using System;
using System.Collections.Generic;
using System.Text;

namespace SEA
{
    /// <summary>
    /// Utility class to do math over arrays.
    /// </summary>
    class SEAMath
    {

        public static double Max(double[] data)
        {
            double max = 0;
            foreach (double num in data)
            {
                max = Math.Max(max, num);
            }
            return max;
        }

        public static double Min(double[] data)
        {
            double min = 1000000000000000;
            foreach (double num in data)
            {
                min = Math.Min(min, num);
            }
            return min;
        }

        public static double Mean(double[] data)
        {
            double sum = 0;
            foreach (double num in data)
            {
                sum += num;
            }
            return sum / data.Length;
        }

        public static double StandardDeviation(double[] data)
        {

            double ret = 0;
            double DataAverage = 0;
            double TotalVariance = 0;
            int Max = 0;

            try
            {

                Max = data.Length;

                if (Max == 0) { return ret; }

                DataAverage = Mean(data);

                for (int i = 0; i < Max; i++)
                {
                    TotalVariance += Math.Pow(data[i] - DataAverage, 2);
                }

                ret = Math.Sqrt(SafeDivide(TotalVariance, Max));

            }
            catch (Exception) { throw; }
            return ret;
        }

        private static double SafeDivide(double value1,double value2)
          {

            double ret = 0;

            try
            {

              if ((value1 == 0) || ( value2 == 0)) { return ret; }

              ret =  value1 / value2;
            
            }
            catch { } 
            return ret;
          }


  }

    }

