﻿using System;
using System.Collections.Generic;
using System.Text;

namespace euler.Utility
{
    static class ArrayExtensions
    {
        public static long Product(this IEnumerable<int> a)
        {
            long product = 1;
            foreach (var x in a)
            {
                product *= x;
            }
            return product;
        }
        
        public static int Product<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            /*if (source == null)
                throw Error.ArgumentNull(nameof (source));
            if (selector == null)
                throw Error.ArgumentNull(nameof (selector));*/
            int num = 1;
            foreach (TSource source1 in source)
                checked { num *= selector(source1); }
            return num;
        }

        public static int[] CumulativeSum(int[] values)
        {
            if (values == null || values.Length == 0) return new int[0];

            for (var i = 1; i < values.Length; i++)
            {
                values[i] = values[i - 1] + values[i];
            }

            return values;
        }

        public static List<List<int>> ExtractDiagonals(this int[,] m)
        {
            var rows = m.GetLength(0);
            var columns = m.GetLength(1);

            if (rows != columns)
            {
                throw new ArgumentException($"The two-dimensional array must be square. The array has {rows} row(s) and {columns} column(s).");
            }
            
            var diagonal = new List<int>();
            var listOfDiagonals = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                diagonal.Add(m[i, i]);
            }
            
            listOfDiagonals.Add(diagonal);

            for (int i = 1; i < columns; i++)
            {
                var upperDiagonal = new List<int>();
                var lowerDiagonal = new List<int>();

                for (int j = 0; j < rows && j + i < rows; j++)
                {
                    upperDiagonal.Add(m[j, j + i]);
                    lowerDiagonal.Add(m[j + i, j]);
                }
                
                listOfDiagonals.Add(upperDiagonal);
                listOfDiagonals.Add(lowerDiagonal);
            }

            return listOfDiagonals;
        }

        public static int[,] Transpose(this int[,] m)
        {
            var rows = m.GetLength(0);
            var columns = m.GetLength(1);

            var result = new int[rows, columns];
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = m[j, i];
                }
            }

            return result;
        }
        
        public static int[,] Reverse(this int[,] m)
        {
            var rows = m.GetLength(0);
            var columns = m.GetLength(1);
            
            if (rows != columns)
            {
                throw new ArgumentException($"The two-dimensional array must be square. The array has {rows} row(s) and {columns} column(s).");
            }
            
            var n = rows-1;

            var result = new int[rows, columns];
            
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    result[i, j] = m[i, n-j];
                }
            }

            return result;
        }
    }
}