using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waiolib
{
    public class Math
    {
        // Public variables
        int average;

        // Basic Math Logic

        /// <summary> 
        /// Adds two numbers together.
        /// </summary>
        /// <param name="x">First Number</param>
        /// <param name="y">Second Number</param>
        /// <returns></returns>
        public float Add(int x, int y) { return x + y; }

        /// <summary>
        ///  Subtracts two numbers.
        /// </summary>
        /// <param name="x">First Number</param>
        /// <param name="y">Second Number</param>
        /// <returns></returns
        public float Subtract(float x, float y) { return x - y; }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="x">First Number</param>
        /// <param name="y">Second Number</param>
        /// <returns></returns>
        public float Multiply(float x, float y) { return x * y; }

        /// <summary>
        /// Divides two numbers.
        /// </summary>
        /// <param name="x">First Number</param>
        /// <param name="y">Second Number</param>
        /// <returns></returns>
        public float Divide(float x, float y) { return x / y; }

        // Advanced Math Logic

        /// <summary>
        /// Finds the average of a set of numbers. Can take any amount of numbers.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int Average(int[] numbers)
        {
            int n = 0;

            int phase1 = numbers[0];

            foreach (int element in numbers)
            {
                n++;
                average = phase1 + numbers[n];
            }

            return average;
        }
    }
}
