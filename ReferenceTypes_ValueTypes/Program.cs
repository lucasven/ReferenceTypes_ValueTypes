﻿using System;
using System.Linq;

namespace ReferenceTypes_ValueTypes
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's Grade Book");

            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The higgest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
        }
    }
}
