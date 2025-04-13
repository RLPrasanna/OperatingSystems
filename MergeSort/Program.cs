// See https://aka.ms/new-console-template for more information
using MergeSortUsingThreads;

List<int> list = new List<int> { 31, 21, 19, 23, 54 };
MergeSort mergeSort = new MergeSort(list);

// Alternatively, you can use MergeSortWithFixedThreadPool for Fixed Thread Pool

//var semaphore=new SemaphoreSlim(2); // Limit to 2 concurrent threads
//var mergeSort = new MergeSortWithFixedThreadPool(list, semaphore);

try
{
    List<int> sortedList = await mergeSort.SortAsync();
    Console.WriteLine("Sorted List: " + string.Join(", ", sortedList));
}
catch(Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}