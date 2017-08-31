using System;
using System.Collections.Generic;

namespace FreshManBasicDiamond.Sort
{
    /// <summary>
    /// 排序
    /// </summary>
    public static partial class Sort
    {
        #region [1、冒泡排序]

        /// <summary>
        /// 优化的冒泡排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> BubbleSort<T>(List<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count < 1) return list;
            //表示趟数
            for (int i = 0; i < list.Count - 1; i++)
            {
                //是否交换标志
                var flag = false;
                for (int j = list.Count - 1; j > i; j--)
                {
                    if (list[j].CompareTo(list[j - 1]) == -1)
                    {
                        //临时变量
                        var temp = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = temp;
                        flag = true;
                    }
                }
                if (!flag) break;
            }
            return list;
        }
        #endregion

        #region [2、选择排序]

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> SelectSort<T>(List<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count < 1) return list;
            for (int i = 0; i < list.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j].CompareTo(list[minIndex]) == -1)
                    {
                        minIndex = j;
                    }
                }
                //交换
                if (minIndex != i)
                {
                    T temp = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = temp;
                }
            }
            return list;
        }
        #endregion

        #region [3、插入排序]

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> InsertSort<T>(List<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count < 1) return list;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (list[j].CompareTo(list[j - 1]) == -1)
                    {
                        T temp = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return list;
        }
        #endregion

        #region [4、希尔排序]

        /// <summary>
        /// 希尔排序
        /// <para>已知的最好步长序列是由Sedgewick提出的(1, 5, 19, 41, 109,...)，
        /// 该序列的项来自 9 times 4^{i}-9 times 2^{i}+1和 2^{i+2} times (2^{i+2}-3)+1}这两个算式</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> ShellSort<T>(List<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count < 1) return list;
            int incre = list.Count;
            while (true)
            {
                incre = incre / 2;
                for (int k = 0; k < incre; k++)
                {
                    for (int i = k + incre; i < list.Count; i += incre)
                    {
                        for (int j = i; j > k; j -= incre)
                        {
                            if (list[j].CompareTo(list[j - incre]) == -1)
                            {
                                var temp = list[j - incre];
                                list[j - incre] = list[j];
                                list[j] = temp;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                if (incre == 1) break;
            }
            return list;
        }
        #endregion

        #region [5、快速排序]

        /// <summary>
        /// 获取中间位置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private static int MiddlePosition<T>(List<T> list, int low, int high) where T : IComparable<T>
        {
            //选取首元素为关键元
            T temp = list[low];
            while (low < high)
            {
                while (low < high && list[high].CompareTo(temp) != -1)
                {
                    high--;
                }
                list[low] = list[high];
                while (low < high && list[low].CompareTo(temp) != 1)
                {
                    low++;
                }
                list[high] = list[low];
            }
            list[low] = temp;
            return low;
        }

        /// <summary>
        /// 递归快速排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private static List<T> RecursiveQuickSort<T>(List<T> list, int low, int high) where T : IComparable<T>
        {
            if (list == null || list.Count < 1) return list;
            if (low < high)
            {
                int mid = MiddlePosition(list, low, high);
                RecursiveQuickSort(list, low, mid - 1);
                RecursiveQuickSort(list, mid + 1, high);
            }
            return list;
        }

        /// <summary>
        /// 非递归快速排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private static List<T> StackQuickSort<T>(List<T> list, int low, int high) where T : IComparable<T>
        {
            Stack<int> st = new Stack<int>();
            if (low < high)
            {
                int mid = MiddlePosition(list, low, high);
                if (low < mid - 1)
                {
                    st.Push(low);
                    st.Push(mid - 1);
                }
                if (mid + 1 < high)
                {
                    st.Push(mid + 1);
                    st.Push(high);
                }
                while (st.Count > 0)
                {
                    int q = st.Pop();
                    int p = st.Pop();
                    mid = MiddlePosition(list, p, q);
                    if (p < mid - 1)
                    {
                        st.Push(p);
                        st.Push(mid - 1);
                    }
                    if (mid + 1 < q)
                    {
                        st.Push(mid + 1);
                        st.Push(q);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> QuickSort<T>(List<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count < 1) return list;
            var low = 0;
            var high = list.Count - 1;
            return high > 3500 ? StackQuickSort(list, low, high) : RecursiveQuickSort(list, low, high);
        }
        #endregion

        #region [6、二路归并排序]

        /// <summary>
        /// 二路归并排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> MergeSort<T>(List<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count < 1) return list;
            var low = 0;
            var high = list.Count - 1;
            SplitSort(list, low, high);
            return list;
        }

        /// <summary>
        /// 分治排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        private static void SplitSort<T>(List<T> list, int low, int high) where T : IComparable<T>
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                SplitSort(list, low, middle);
                SplitSort(list, middle + 1, high);
                MergeTwoListSort(list, low, middle, high);
            }
        }

        /// <summary>
        /// 合并两个列表并修改原有集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="low"></param>
        /// <param name="middle"></param>
        /// <param name="high"></param>
        private static void MergeTwoListSort<T>(List<T> list, int low, int middle, int high) where T : IComparable<T>
        {
            List<T> result = new List<T>(high - low + 1);
            for (int j = 0; j < high - low + 1; j++)
            {
                T temp = default(T);
                result.Add(temp);
            }
            int i = low;
            int highMiddle = middle + 1;
            var k = 0;
            while (low <= middle && highMiddle <= high)
            {
                if (list[low].CompareTo(list[highMiddle]) != 1)
                {
                    result[k] = list[low];
                    k++;
                    low++;
                }
                else
                {
                    result[k] = list[highMiddle];
                    k++;
                    highMiddle++;
                }
            }
            while (low <= middle)
            {
                result[k] = list[low];
                k++;
                low++;
            }
            while (highMiddle <= high)
            {
                result[k] = list[highMiddle];
                k++;
                highMiddle++;
            }
            for (int j = 0; j < k; j++)
            {
                list[i + j] = result[j];
            }
        }
        #endregion

        #region [7、小根堆排序]

        /// <summary>
        /// 小根堆排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> MinHeapSort<T>(List<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count < 1) return list;
            var n = list.Count;
            MakeMinHeap(list);
            for (int i = n - 1; i > 0; i--)
            {
                T temp = list[0];
                list[0] = list[i];
                list[i] = temp;
                MinHeapFixdown(list, 0, i);
            }
            return list;
        }

        /// <summary>
        /// 构建小根堆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        private static void MakeMinHeap<T>(List<T> list) where T : IComparable<T>
        {
            var n = list.Count;
            for (int i = (n - 1) / 2; i >= 0; i--)
            {
                MinHeapFixdown(list, i, n);
            }
        }

        /// <summary>
        /// 从i结点开始调整，n为结点总数，从0开始计算 i结点的子节点为2*i+1，2*i+2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="i"></param>
        /// <param name="n"></param>
        private static void MinHeapFixdown<T>(List<T> list, int i, int n) where T : IComparable<T>
        {
            //子节点
            int j = 2 * i + 1;
            while (j < n)
            {
                //在左右子节点中寻找最小的
                if (j + 1 < n && list[j + 1].CompareTo(list[j]) == -1)
                {
                    j++;
                }
                if (list[i].CompareTo(list[j]) != 1)
                {
                    break;
                }
                //较大节点下移
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;

                i = j;
                j = 2 * i + 1;
            }
        }
        #endregion

        #region [8、大根堆排序]
        /// <summary>
        /// 堆排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> MaxHeapSort<T>(List<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count < 1) return list;
            var n = list.Count;
            MakeMaxHeap(list);
            for (int i = n - 1; i > 0; i--)
            {
                T temp = list[0];
                list[0] = list[i];
                list[i] = temp;
                MaxHeapFixdown(list, 0, i);
            }
            return list;
        }

        /// <summary>
        /// 构建小根堆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        private static void MakeMaxHeap<T>(List<T> list) where T : IComparable<T>
        {
            var n = list.Count;
            for (int i = (n - 1) / 2; i >= 0; i--)
            {
                MaxHeapFixdown(list, i, n);
            }
        }

        /// <summary>
        /// 从i结点开始调整，n为结点总数，从0开始计算 i结点的子节点为2*i+1，2*i+2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="i"></param>
        /// <param name="n"></param>
        private static void MaxHeapFixdown<T>(List<T> list, int i, int n) where T : IComparable<T>
        {
            //子节点
            int j = 2 * i + 1;
            while (j < n)
            {
                //在左右子节点中寻找最大的
                if (j + 1 < n && list[j + 1].CompareTo(list[j]) == 1)
                {
                    j++;
                }
                if (list[i].CompareTo(list[j]) != -1)
                {
                    break;
                }
                //较小节点下移
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;

                i = j;
                j = 2 * i + 1;
            }
        }
        #endregion

        #region [9、基数排序]

        /// <summary>
        /// 基数排序
        /// </summary>
        /// <param name="list">待排序数组</param>
        /// <param name="bitWidth">最大数的位数</param>
        /// <param name="baseNumber">基数10</param>
        /// <returns></returns>
        public static List<int> RadixSort(List<int> list, int bitWidth, int baseNumber)
        {
            //初始化辅助数组
            var n = list.Count;
            List<int> temp = new List<int>(n);
            //记录对应位置的数量
            List<int> cnt = new List<int>(baseNumber);
            //初始化对应位置的数量记录数组
            for (int s = 0; s < baseNumber; s++)
            {
                cnt.Add(0);
            }
            //初始化辅助数组
            for (int t = 0; t < n; t++)
            {
                temp.Add(0);
            }
            for (int i = 0, rtok = 1; i < bitWidth; i++, rtok = rtok * baseNumber)
            {
                //初始化
                for (int j = 0; j < baseNumber; j++)
                {
                    cnt[j] = 0;
                }

                //计算每个箱子的数字个数
                for (int j = 0; j < n; j++)
                {
                    cnt[(list[j] / rtok) % baseNumber]++;
                }
                //cnt[j]的个数修改未前j个箱子一共有几个待排数字
                for (int j = 1; j < baseNumber; j++)
                {
                    cnt[j] = cnt[j - 1] + cnt[j];
                }
                //将数字置于辅助数组中的本趟位置
                for (int j = n - 1; j >= 0; j--)
                {
                    //数字个数减一
                    cnt[(list[j] / rtok) % baseNumber]--;
                    //对应位置的数字归位
                    temp[cnt[(list[j] / rtok) % baseNumber]] = list[j];
                }
                //修正本次排序结果到list中
                for (int j = 0; j < n; j++)
                {
                    list[j] = temp[j];
                }
            }
            return list;
        }
        #endregion
    }
}
