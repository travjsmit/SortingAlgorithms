using SortingAlgorithms;
using System.Diagnostics;
using System.Reflection;

namespace SortingAlgorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //int[] arr1 = { 6, 1, 7, 4, 2, 9, 8, 5, 3 };
            //int[] arr2 = { 6, 1, 7, 4, 2, 9, 8, 5, 3 };
            //int[] arr3 = { 6, 1, 7, 4, 2, 9, 8, 5, 3 };
            //int[] arrSorted1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] arrSorted2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] arrSorted3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //InsertionSort(arrSorted1);
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time for Insertion Sort: {stopwatch.ElapsedTicks}");

            //stopwatch.Restart();
            //stopwatch.Start();
            //BubbleSort(arrSorted2);
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time for Bubble Sort: {stopwatch.ElapsedTicks}");

            //stopwatch.Restart();
            //stopwatch.Start();
            //SelectionSort(arrSorted3);
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time for Selection Sort: {stopwatch.ElapsedTicks}");

            List<Student> students = new List<Student>
            {
                new Student("Melissa", 4.0),
                new Student("Rich", 3.0),
                new Student("Adam", 3.8),
                new Student("Andrew", 3.9),
                new Student("Alyssa", 3.7),
            };

            while (true)
            {
                Console.WriteLine("Please select a sorting algorithm");
                Console.WriteLine("1: Bubble Sort");
                Console.WriteLine("2: Selection Sort");
                Console.WriteLine("3: Insertion Sort");
                Console.WriteLine("4: Merge Sort");
                Console.WriteLine("5: Exit");

                string? userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        BubbleSort(students);
                        break;
                    case "2":
                        SelectionSort(students);
                        break;
                    case "3":
                        InsertionSort(students);
                        break;
                    case "4":
                        students = MergeSort(students);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                }

                PrintStudents(students);
            }
        }

        //    int[] mergeArray = { 3, 2, 5, 6, 7, 4, 1, 0 };
        //    //MergeSort(mergeArray);
        //    //Console.WriteLine();
        //    QuickSort(mergeArray);
        //    PrintArray(mergeArray);
        //}

        //public static void QuickSort(int[] arr)
        //{
        //    if (arr == null || arr.Length == 0) return;
        //    QuickSortHelper(arr, 0, arr.Length - 1);
        //}

        /// <summary>
        /// Utilizes a quick sort algorithm to sort the passed array
        /// </summary>
        /// <param name="arr"> the array which shoulld be sorted </param>
        /// <param name="low"> the smaller index of the (sub)array </param>
        /// <param name="high"> the larger index of the (sub)array </param>
        //public static void QuickSortHelper(int[] arr, int low, int high)
        //{
        //    if (low < high)
        //    {
        //        // Partition retirn pivot location to us
        //        int pivotIndex = Partition(arr, low, high);

        //        // Call QuickSort again on the new subarrays based on pivots position
        //        QuickSortHelper(arr, low, pivotIndex - 1);
        //        QuickSortHelper(arr, pivotIndex + 1, high);
        //    }
        //}

        //public static int Partition(int[] arr, int low, int high)
        //{
        //    int pivot = arr[high]; // setting pivot to be the last value in the array
        //    int i = low - 1;

        //    for (int j = low; j < high; j++)
        //    {
        //        if (arr[j] < pivot)
        //        {
        //            i++;
        //            Swap(arr, i, j);
        //        }
        //    }

        //    Swap(arr, ++i, high);
        //    return i;
        //}

        //public static void Swap(int[] arr, int i, int j)
        //{
        //    // swap - could also move this into a helper method
        //    int temp = arr[i];
        //    arr[i] = arr[j];
        //    arr[j] = temp;
        //}

        // Splits array up and eventually merges it together
        // Calls itself recursively
        public static void List<Student> MergeSort(List<Student> students)
        {
            if (students.Count <= 1) return students;

            int mid = students.Count / 2;
            List<Student> left = students.GetRange(0, mid);
            List<Student> right = students.GetRange(mid, students.Count - mid);

            return Merge(MergeSort(left), MergeSort(right));
        }
                
        public static List<Student> Merge(List<Student> left, List<Student> right)
        {
            List<Student> result = new List<Student>();
            while (left.Count > 0 && right.Count > 0) ;
            {
                if (left[0].GPA <= right[0].GPA)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
                result.AddRange(left);
                result.AddRange(right);

                return result;
        }



        //public static void PrintArray(int[] arr)
        //{
        //    foreach (var item in arr)
        //    {
        //        Console.Write(item + " ");
        //    }
        //    Console.WriteLine();
        //}

        public static void PrintArray(List<Student> students)
        {
            foreach (var item in students)
            {
                Console.Write($"{item.Name}: {item.GPA} ");
            }
            Console.WriteLine();
        }

        //public static void BubbleSort(int[] arrToSort) //good if low on system memory 
        //{
        //    int temp;
        //    // Overall O(n^2) runtime
        //    // Big Omega - O(n^2)

        //    for (int i = 0; i < arrToSort.Length; i++) //how many times through unsorted elements O(n)
        //    {
        //        for (int j = 0; j < arrToSort.Length - 1 - i; j++) //O(n)
        //        {
        //            if (arrToSort[j] > arrToSort[j + 1]) //change to < to reverse array
        //            {
        //                temp = arrToSort[j];
        //                arrToSort[j] = arrToSort[j + 1];
        //                arrToSort[j + 1] = temp;
        //            }
        //        }
        //    }
        //}

        public static void BubbleSort(List<Student> students)
        {
            for (int i = 0; i < students.Count - 1; i++) //how many times through unsorted array
            {
                for (int j = 0; j < students.Count - 1 - i; j++) //O(n)
                {
                    if (students[j].GPA > students[j + 1].GPA)
                    {
                        var temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }

        //public static void SelectionSort(int[] arrToSort)
        //{
        //    // minIndex keeps track of smallest index in each iteration
        //    // temp stores the value being swapped
        //    int minIndex, temp;

        //    for (int i = 0; i < arrToSort.Length - 1; i++) // iterate through unsorted elements O(n)
        //    {
        //        minIndex = i; // set minIndex to current index

        //        for (int j = i + 1; j < arrToSort.Length; j++) // iterate through the remaining elements O(n)
        //        {
        //            // update minIndex if the current element is smaller than the element at minIndex
        //            if (arrToSort[j] < arrToSort[minIndex])
        //            {
        //                minIndex = j;
        //            }
        //        }

        //        // swap the elements if minIndex is not the current index
        //        if (minIndex != i)
        //        {
        //            temp = arrToSort[i];
        //            arrToSort[i] = arrToSort[minIndex];
        //            arrToSort[minIndex] = temp;
        //        }
        //    }
        //}

        public static void SelectionSort(List<Student> students)
        {
            for (int i = 0; i < students.Count - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < students.Count; j++)
                {
                    if (students[j].GPA < students[maxIndex].GPA)
                    {
                        maxIndex = j;
                    }
                }
                var temp = students[i];
                students[i] = students[maxIndex];
                students[maxIndex] = temp;
            }
        }

        //public static void InsertionSort(int[] arr)
        //{
        //    // Overall worst case scenario: O(n^2)
        //    // Best case scenario: O(n)
        //    for (int i = 1; i < arr.Length; i++) // O(n)
        //    {
        //        int temp = arr[i];  // store the current element - as it might be overwritten
        //        int priorIndex = i - 1; // start comparing with the element before the current element

        //        // if our prior element is greater than our stored element
        //        // and we haven't reached the end of the array
        //        while (arr[priorIndex] > temp && priorIndex >= 0)
        //        {
        //            arr[priorIndex + 1] = arr[priorIndex];
        //            priorIndex--;
        //        }

        //        // need to an assignment
        //        arr[priorIndex + 1] = temp;
        //    }
        //}

        public static void InsertionSort(List<Student> students)
        {
            for (int i = 1; i < students.Count; i++)
            {
                var key = students[i];
                int j = i - 1;

                while (j >= 0 && students[j].GPA < key.GPA)
                {
                    students[j + 1] = students[j];
                    j--;
                }

                students[j + 1] = key;
            }
        }
    }
}

