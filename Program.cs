using System.Diagnostics;

namespace SortingAlgorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 6, 1, 7, 4, 2, 9, 8, 5, 3 };
            int[] arr2 = { 6, 1, 7, 4, 2, 9, 8, 5, 3 };
            int[] arr3 = { 6, 1, 7, 4, 2, 9, 8, 5, 3 };
            int[] arrSorted1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arrSorted2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arrSorted3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            InsertionSort(arrSorted1);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Insertion Sort: {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            stopwatch.Start();
            BubbleSort(arrSorted2);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Bubble Sort: {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            stopwatch.Start();
            SelectionSort(arrSorted3);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Selection Sort: {stopwatch.ElapsedTicks}");

            Console.WriteLine("Please select a sorting algorithm");
            Console.WriteLine("1: Bubble Sort");
            Console.WriteLine("2: Selection Sort");
            Console.WriteLine("3: Insertion Sort");

            string? userSelection = Console.ReadLine();

            Student student1 = new Student("Melissa", 4.0);
            Student student2 = new Student("Rich", 3.0);
            Student student3 = new Student("Adam", 3.8);

            Student[] students = { student1, student2 };

            switch (userSelection)
            {
                case "1":
                    BubbleSort(students);
                    // call bubble sort method
                    break;
                case "2":
                    // call selection sort method
                    break;
                case "3":
                    // call insertion sort method
                    break;
                default:
                    // none of the cases matched
                    break;
            }

            PrintArray(students);
        }

        public static void PrintArray(Student[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item.name}: {item.gpa} ");
            }
            Console.WriteLine();
        }

        public static int BubbleSort(int[] arrToSort) //good if low on system memory 
        {
            int totalOuterIterations = 0;
            int temp;
            // Overall O(n^2) runtime
            // Big Omega - O(n^2)

            for (int i = 0; i < arrToSort.Length; i++) //how many times through unsorted elements O(n)
            {
                ++totalOuterIterations;
                int swaps = 0;
                for (int j = 0; j < arrToSort.Length - 1 - i; j++) //O(n)
                {
                    //swap places if j is greater than j + 1
                    if (arrToSort[j] > arrToSort[j + 1]) //change to < to reverse array
                    {
                        swaps++;
                        temp = arrToSort[j];
                        arrToSort[j] = arrToSort[j + 1];
                        arrToSort[j + 1] = temp;
                    }
                }
                if (swaps == 0) break;
            }
            return totalOuterIterations;
        }

        public static void SelectionSort(int[] arrToSort)
        {
            // minIndex keeps track of smallest index in each iteration
            // temp stores the value being swapped
            int minIndex, temp;

            for (int i = 0; i < arrToSort.Length - 1; i++) // iterate through unsorted elements O(n)
            {
                minIndex = i; // set minIndex to current index

                for (int j = i + 1; j < arrToSort.Length; j++) // iterate through the remaining elements O(n)
                {
                    // update minIndex if the current element is smaller than the element at minIndex
                    if (arrToSort[j] < arrToSort[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // swap the elements if minIndex is not the current index
                if (minIndex != i)
                {
                    temp = arrToSort[i];
                    arrToSort[i] = arrToSort[minIndex];
                    arrToSort[minIndex] = temp;
                }
            }
        }

        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];  // store the current element - as it might be overwritten
                int priorIndex = i - 1; // start comparing with the element before the current element

                // if our prior element is greater than our stored element
                // and we haven't reached the end of the array
                while (arr[priorIndex] > temp && priorIndex >= 0)
                {
                    arr[priorIndex + 1] = arr[priorIndex];
                    priorIndex--;
                }

                // need to an assignment
                arr[priorIndex + 1] = temp;
            }
        }

        public static void BubbleSort(Student[] arrToSort)
        {
            Student temp;
            for (int i = 0; i < arrToSort.Length - 1; i++) //how many times through unsorted elements O(n)
            {
                int swaps = 0;
                for (int j = 0; j < arrToSort.Length - 1 - i; j++)
                {
                    // we need to swap
                    if (arrToSort[j].gpa < arrToSort[j + 1].gpa)
                    {
                        temp = arrToSort[j];
                        arrToSort[j] = arrToSort[j + 1];
                        arrToSort[j + 1] = temp;
                    }
                }
            }
        }
    }
}
