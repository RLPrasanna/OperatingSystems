using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortUsingThreads
{
    internal class MergeSortWithFixedThreadPool
    {
        private List<int> list;
        private SemaphoreSlim semaphore;
        public MergeSortWithFixedThreadPool(List<int> list, SemaphoreSlim semaphoreSlim) 
        {
            this.list = list;
            this.semaphore = semaphoreSlim;
        }

        public async Task<List<int>> SortAsync()
        {
            if(list.Count == 0)
            {
                return new List<int>();
            }

            if (list.Count == 1)
            {
                return list;
            }

            int mid = list.Count / 2;
            List<int> left = list.Take(mid).ToList();
            List<int> right = list.Skip(mid).ToList();

            var leftSorter = new MergeSortWithFixedThreadPool(left,semaphore);
            var rightSorter = new MergeSortWithFixedThreadPool(right,semaphore);

            await semaphore.WaitAsync();
            Task<List<int>> leftTask = Task.Run(() =>
            {
                try {
                    return leftSorter.SortAsync();
                }
                finally
                {
                    semaphore.Release();
                }
            });

            await semaphore.WaitAsync();
            Task<List<int>> rightTask = Task.Run(() => {
                try {
                    return rightSorter.SortAsync();
                }
                finally
                {
                    semaphore.Release();
                }
            });

            List<int>[] sortedLists = await Task.WhenAll(leftTask, rightTask);
            
            return Merge(sortedLists[0], sortedLists[1]);
        }

        private List<int> Merge(List<int> left, List<int> right)
        {
            List<int> merged = new List<int>();
            int i = 0, j = 0;

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

            while (i < left.Count)
            {
                merged.Add(left[i]);
                i++;
            }

            while (j < right.Count)
            {
                merged.Add(right[j]);
                j++;
            }

            return merged;
        }
    }
}
