using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortUsingThreads
{
    internal class MergeSort
    {
        private List<int> list;

        public MergeSort(List<int> list)
        {
            this.list = list;
        }

        // Asynchronous method to sort the list using merge sort
        public async Task<List<int>> SortAsync()
        {
            if (list.Count == 0)
            {
                return new List<int>();
            }

            if (list.Count == 1)
            {
                return list;
            }

            // Split the list into two halves
            int mid = list.Count / 2;
            List<int> left = list.Take(mid).ToList();
            List<int> right = list.Skip(mid).ToList();

            // Create MergeSort instances for the left and right halves
            var leftSorter = new MergeSort(left);
            var rightSorter = new MergeSort(right);

            // Sort the left and right halves asynchronously
            Task<List<int>> leftTask = Task.Run(() => leftSorter.SortAsync());
            Task<List<int>> rightTask = Task.Run(() => rightSorter.SortAsync());

            // Wait for both sorting tasks to complete
            List<int>[] sortedLists = await Task.WhenAll(leftTask, rightTask);

            return Merge(sortedLists[0], sortedLists[1]);
        }

        // Helper method to merge two sorted lists into one sorted list
        private List<int> Merge(List<int> left, List<int> right)
        {
            List<int> merged = new List<int>();
            int i = 0, j = 0;

            // Merge elements from both lists in sorted order
            while (i < left.Count && j < right.Count)
            {
                if (left[i] < right[j])
                {
                    merged.Add(left[i]);
                    i++;
                }
                else
                {
                    merged.Add(right[j]);
                    j++;
                }
            }

            // Add any remaining elements from the left list
            while (i < left.Count)
            {
                merged.Add(left[i]);
                i++;
            }

            // Add any remaining elements from the right list
            while (j < right.Count)
            {
                merged.Add(right[j]);
                j++;
            }

            return merged;
        }
    }
}
