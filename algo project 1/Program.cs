// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

class HeapSort
{
    // Heapify a subtree rooted at index i
    private static void Heapify(int[] array, int heapSize, int rootIndex)
    {
        int largest = rootIndex;
        int leftChild = 2 * rootIndex + 1;
        int rightChild = 2 * rootIndex + 2;

        // Check if the left child is larger than the root
        if (leftChild < heapSize && array[leftChild] > array[largest])
        {
            largest = leftChild;
        }

        // Check if the right child is larger than the largest so far
        if (rightChild < heapSize && array[rightChild] > array[largest])
        {
            largest = rightChild;
        }

        // If the largest is not the root, swap and heapify
        if (largest != rootIndex)
        {
            Swap(array, rootIndex, largest);
            Heapify(array, heapSize, largest);
        }
    }

    // Build a max heap from the array
    private static void BuildMaxHeap(int[] array)
    {
        int startIndex = (array.Length / 2) - 1;

        for (int i = startIndex; i >= 0; i--)
        {
            Heapify(array, array.Length, i);
        }
    }

    // Perform heap sort on the array
    public static void PerformHeapSort(int[] array)
    {
        BuildMaxHeap(array);

        // Extract elements from the heap
        for (int end = array.Length - 1; end > 0; end--)
        {
            // Move the root to the end
            Swap(array, 0, end);

            // Restore the max heap property
            Heapify(array, end, 0);
        }
    }

    // Swap two elements in the array
    private static void Swap(int[] array, int index1, int index2)
    {
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

    // Get user input as an integer array
    private static int[] GetUserInput()
    {
        Console.WriteLine("Enter a sequence of numbers (comma-separated):");
        string input = Console.ReadLine();
        return input.Split(',').Select(int.Parse).ToArray();
    }

    // Main method to execute the program
    public static void Main(string[] args)
    {
        // Get user input
        int[] numbers = GetUserInput();

        // Display the original array
        Console.WriteLine("Original array: " + string.Join(", ", numbers));

        // Perform heap sort
        PerformHeapSort(numbers);

        // Display the sorted array
        Console.WriteLine("Sorted array: " + string.Join(", ", numbers));
    }
}

