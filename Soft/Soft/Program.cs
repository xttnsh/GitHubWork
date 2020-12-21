using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = GetArr();
            Console.WriteLine("排序前数组:");
            WriteArr(arr);

            Console.WriteLine("请按数字选择:");
            Console.WriteLine("A.冒泡排序（Bubble Sort）");
            Console.WriteLine("B.选择排序（Selection Sort）");
            Console.WriteLine("C.插入排序（Insertion Sort）");
            Console.WriteLine("D.希尔排序（Shell Sort）");
            Console.WriteLine("E.快速排序（Quick Sort）");
            bool isSoft = true;
            do
            {
                switch (Console.ReadKey().Key.ToString())
                {
                    case "A":
                        //1.冒泡排序（Bubble Sort）
                        Console.WriteLine("冒泡排序后:");
                        BubbleSort(arr);
                        break;
                    case "B":
                        //2.选择排序（Selection Sort）
                        Console.WriteLine("选择排序后:");
                        SelectionSort(arr);
                        break;
                    case "C":
                        //3.插入排序（Insertion Sort）
                        Console.WriteLine("插入排序后:");
                        InsertionSort(arr);
                        break;
                    case "D":
                        //4.希尔排序（Shell Sort）
                        Console.WriteLine("希尔排序后:");
                        ShellSort(arr);
                        break;
                    case "E":
                        //5.快速排序（Quick Sort）
                        Console.WriteLine("快速排序后:");

                        QuickSort(arr, 0, arr.Length - 1);
                        break;
                    default:
                        isSoft = false;
                        break;
                }
                //Console.ReadKey();
            } while (isSoft);


        }
        //获取随机数组
        public static int[] GetArr()
        {
            Random random = new Random();
            int[] arr = new int[random.Next(5,9)];//数组长度5-9之间随机
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(50);
            }
            return arr;
        }
        //控制台输出数组
        public static void WriteArr(int[] arr)
        {
            Console.Write("{ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i<arr.Length-1)
                {
                    Console.Write(",");
                }
            }
            Console.Write(" }\n");

        }
        //1.冒泡排序（Bubble Sort）
        public static void BubbleSort(int[] arr)
        {
            int temp;//临时变量
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {

                    if (arr[j] < arr[j - 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
            WriteArr(arr);
        }

        //2.选择排序（Selection Sort）
        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }
            WriteArr(arr);
        }

        //3.插入排序（Insertion Sort）
        public static void InsertionSort(int[] arr)
        {

            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            WriteArr(arr);
        }

        //4.希尔排序（Shell Sort）
        public static void ShellSort(int[] arr)
        {

            int temp = 0;
            int incre = arr.Length;

            while (true)
            {
                incre = incre / 2;

                for (int k = 0; k < incre; k++)
                {    //根据增量分为若干子序列

                    for (int i = k + incre; i < arr.Length; i += incre)
                    {

                        for (int j = i; j > k; j -= incre)
                        {
                            if (arr[j] < arr[j - incre])
                            {
                                temp = arr[j - incre];
                                arr[j - incre] = arr[j];
                                arr[j] = temp;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                if (incre == 1)
                {
                    break;
                }
            }
            WriteArr(arr);
        }

        //5.快速排序（Quick Sort）
        public static void QuickSort(int[] arr, int l, int r)
        {
            if (l >= r)
                return;

            int i = l; int j = r; int key = arr[l];//选择第一个数为key

            while (i < j)
            {

                while (i < j && arr[j] >= key)//从右向左找第一个小于key的值
                    j--;
                if (i < j)
                {
                    arr[i] = arr[j];
                    i++;
                }

                while (i < j && arr[i] < key)//从左向右找第一个大于key的值
                    i++;

                if (i < j)
                {
                    arr[j] = arr[i];
                    j--;
                }
            }
            //i == j
            arr[i] = key;
            QuickSort(arr, l, i - 1);//递归调用
            QuickSort(arr, i + 1, r);//递归调用
            WriteArr(arr);
        }
    }
}
