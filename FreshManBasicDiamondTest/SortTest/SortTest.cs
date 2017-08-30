using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FreshManBasicDiamond.Sort;

namespace FreshManBasicDiamondTest.SortTest
{
    public class MoreSortTest
    {
        /// <summary>
        /// 测试用的排序数据
        /// </summary>
        private readonly List<int> _sortData;

        /// <summary>
        /// 测试用的排序数据
        /// </summary>
        public List<int> SortData
        {
            get { return _sortData.Select(f => f).ToList(); }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public MoreSortTest()
        {
            _sortData = new List<int> { 42, 20, 17, 13, 28, 14, 23, 15 };
        }
        /// <summary>
        /// 冒泡排序
        /// </summary>
        public void BubbleSortTest()
        {
            var list = SortData;
            var sortList = Sort.BubbleSort(list);
            sortList.ForEach(f => Debug.Write(f));
            sortList[4].IsEqualTo(20);
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        public void SelectSortTest()
        {
            var list = SortData;
            var sortList = Sort.SelectSort(list);
            sortList.ForEach(f => Debug.Write(f));
            sortList[4].IsEqualTo(20);
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        public void InsertSortTest()
        {
            var list = SortData;
            var sortList = Sort.InsertSort(list);
            sortList.ForEach(f => Debug.Write(f));
            sortList[4].IsEqualTo(20);
        }

        /// <summary>
        /// 希尔排序
        /// </summary>
        public void ShellSortTest()
        {
            var list = SortData;
            var sortList = Sort.ShellSort(list);
            sortList.ForEach(f => Debug.Write(f));
            sortList[4].IsEqualTo(20);
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        public void QuickSortTest()
        {
            var list = SortData;
            var sortList = Sort.QuickSort(list);
            sortList.ForEach(f => Debug.Write(f));
            sortList[4].IsEqualTo(20);
        }

        /// <summary>
        /// 二路归并排序
        /// </summary>
        public void MergeSortTest()
        {
            var list = SortData;
            var sortList = Sort.MergeSort(list);
            sortList.ForEach(f => Debug.Write(f));
            sortList[4].IsEqualTo(20);
        }

        /// <summary>
        /// 堆排序
        /// </summary>
        public void MinHeapSortTest()
        {
            var list = SortData;
            var sortList = Sort.MinHeapSort(list);
            sortList.ForEach(f => Debug.Write(f));
            sortList[4].IsEqualTo(17);
        }

        /// <summary>
        /// 堆排序
        /// </summary>
        public void MaxHeapSortTest()
        {
            var list = SortData;
            var sortList = Sort.MaxHeapSort(list);
            sortList.ForEach(f => Debug.Write(f));
            sortList[4].IsEqualTo(20);
        }

        /// <summary>
        /// 基数排序
        /// </summary>
        public void RadixSortTest()
        {
            var list = SortData;
            var sortList = Sort.RadixSort(list, 2, 10);
            sortList.ForEach(f => Debug.Write(f));
            sortList[4].IsEqualTo(20);
        }
    }
}
