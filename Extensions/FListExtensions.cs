using System;
using System.Collections.Generic;

namespace Fer.Tools
{
    public static class FListExtensions
    {
        public static List<T> GetRandomUniqueItems<T>(this List<T> sourceItems, int numberOfItems)
        {
            if (sourceItems == null || sourceItems.Count == 0 || numberOfItems <= 0)
            {
                throw new ArgumentException("Invalid arguments");
            }

            if (numberOfItems > sourceItems.Count)
            {
                throw new ArgumentException("Requested number of items is more than available items");
            }

            Random random = new Random();
            HashSet<int> selectedIndexes = new HashSet<int>();
            List<T> uniqueItems = new List<T>();

            while (uniqueItems.Count < numberOfItems)
            {
                int index = random.Next(sourceItems.Count);
                if (selectedIndexes.Add(index)) // Returns false if the index is already in the set
                {
                    uniqueItems.Add(sourceItems[index]);
                }
            }

            return uniqueItems;
        }
    }
}