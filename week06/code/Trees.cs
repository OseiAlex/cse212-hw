using System;
using System.Linq;

public static class Trees
{
    /// <summary>
    /// Given a sorted list (sortedNumbers), create a balanced BST.  If the values in the
    /// sortedNumbers were inserted in order from left to right into the BST, then it
    /// would resemble a linked list (unbalanced). To get a balanced BST, the
    /// InsertMiddle function is called to find the middle item in the list to add
    /// first to the BST. The InsertMiddle function takes the whole list but also takes
    /// a range (first to last) to consider.  For the first call, the full range of 0 to
    /// Length-1 is used.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST.
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// This function inserts the middle element of the current subarray of sortedNumbers
    /// into the BST and then recursively processes the left and right subarrays.
    /// </summary>
    /// <param name="sortedNumbers">input numbers that are already sorted</param>
    /// <param name="first">the first index to consider</param>
    /// <param name="last">the last index to consider</param>
    /// <param name="bst">the BinarySearchTree into which values are inserted</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: if first index is greater than last, nothing to insert.
        if (first > last)
            return;

        // Find the middle index.
        int mid = (first + last) / 2;

        // Insert the middle element into the BST.
        bst.Insert(sortedNumbers[mid]);

        // Recursively process the left subarray.
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Recursively process the right subarray.
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}