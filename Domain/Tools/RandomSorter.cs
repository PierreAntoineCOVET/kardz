﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Tools
{
    /// <summary>
    /// Randomiser tool.
    /// </summary>
    public static class RandomSorter
    {
        /// <summary>
        /// Randomly sort an IEnumerable.
        /// </summary>
        /// <typeparam name="T">Type of the enumerable to randomise.</typeparam>
        /// <param name="list">Enumerable to randomise.</param>
        /// <returns>Randomised Enumerable.</returns>
        public static IEnumerable<T> Randomize<T>(IEnumerable<T> list)
        {
            var buffer = list.ToList();
            var shuffledItems = new List<T>(buffer.Count);
            var random = new Random();

            for (int i = 0; i < list.Count(); i++)
            {
                var randomCardIndex = random.Next(0, buffer.Count);
                shuffledItems.Add(buffer.ElementAt(randomCardIndex));
                buffer.RemoveAt(randomCardIndex);
            }

            return shuffledItems;
        }
    }
}
