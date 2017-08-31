/**============================================================
* 命名空间: FreshManBasicDiamond.Search
*
* 功 能： N/A
* 类 名： Search
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2017/8/31 14:24:57 FreshMan 初版
*
* Copyright (c) 2017 Lir Corporation. All rights reserved.
*==============================================================
*==此技术信息为本公司机密信息,未经本公司书面同意禁止向第三方披露==
*==版权所有：重庆慧都科技有限公司                             ==
*==============================================================
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

// ReSharper disable once CheckNamespace
namespace FreshManBasicDiamond
{
    /// <summary>
    /// 查找算法
    /// </summary>
    public class Search
    {
        /// <summary>
        /// 二分查找
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">待查找的数据集合</param>
        /// <param name="value">查询目标值</param>
        /// <returns></returns>
        public int BinarySearch<T>(List<T> list, T value) where T : IComparable<T>
        {
            if (list == null || list.Count < 1) return -1;
            int low = 0;
            int high = list.Count - 1;
            while (low < high)
            {
                var mid = (low + high) / 2;
                if (list[mid].CompareTo(value) == 0) return mid;
                if (list[mid].CompareTo(value) == -1) low = mid + 1;
                else high = mid - 1;
            }
            return -1;
        }

        /// <summary>
        /// 插值查找
        /// <para>折半查找这种查找方式，不是自适应的（也就是说是傻瓜式的）。二分查找中查找点计算如下：mid=(low+high)/2, 即mid=low+1/2*(high-low);通过类比，我们可以将查找的点改进为如下：mid=low+(key-a[low])/(a[high]-a[low])*(high-low)，也就是将上述的比例参数1/2改进为自适应的，根据关键字在整个有序表中所处的位置，让mid值的变化更靠近关键字key，这样也就间接地减少了比较次数。</para>
        /// </summary>
        /// <param name="list">待查找的数据集合</param>
        /// <param name="value">查询目标值</param>
        /// <returns></returns>
        public int InsertionSearch(List<int> list, int value)
        {
            if (list == null || list.Count < 1) return -1;
            int low = 0;
            int high = list.Count - 1;
            while (low < high)
            {
                int mid = GetMiddleIndex(value, list[low], list[high], high, low);
                if (list[mid].CompareTo(value) == 0) return mid;
                if (list[mid].CompareTo(value) == -1) low = mid + 1;
                else high = mid - 1;
            }
            return -1;
        }

        /// <summary>
        /// 插值查找
        /// <para>折半查找这种查找方式，不是自适应的（也就是说是傻瓜式的）。二分查找中查找点计算如下：mid=(low+high)/2, 即mid=low+1/2*(high-low);通过类比，我们可以将查找的点改进为如下：mid=low+(key-a[low])/(a[high]-a[low])*(high-low)，也就是将上述的比例参数1/2改进为自适应的，根据关键字在整个有序表中所处的位置，让mid值的变化更靠近关键字key，这样也就间接地减少了比较次数。</para>
        /// </summary>
        /// <param name="list">待查找的数据集合</param>
        /// <param name="value">查询目标值</param>
        /// <returns></returns>
        public int InsertionSearch(List<long> list, long value)
        {
            if (list == null || list.Count < 1) return -1;
            int low = 0;
            int high = list.Count - 1;
            while (low < high)
            {
                int mid = GetMiddleIndex(value, list[low], list[high], high, low);
                if (list[mid].CompareTo(value) == 0) return mid;
                if (list[mid].CompareTo(value) == -1) low = mid + 1;
                else high = mid - 1;
            }
            return -1;
        }

        /// <summary>
        /// 插值查找
        /// <para>折半查找这种查找方式，不是自适应的（也就是说是傻瓜式的）。二分查找中查找点计算如下：mid=(low+high)/2, 即mid=low+1/2*(high-low);通过类比，我们可以将查找的点改进为如下：mid=low+(key-a[low])/(a[high]-a[low])*(high-low)，也就是将上述的比例参数1/2改进为自适应的，根据关键字在整个有序表中所处的位置，让mid值的变化更靠近关键字key，这样也就间接地减少了比较次数。</para>
        /// </summary>
        /// <param name="list">待查找的数据集合</param>
        /// <param name="value">查询目标值</param>
        /// <returns></returns>
        public int InsertionSearch(List<double> list, double value)
        {
            if (list == null || list.Count < 1) return -1;
            int low = 0;
            int high = list.Count - 1;
            while (low < high)
            {
                int mid = GetMiddleIndex(value, list[low], list[high], high, low);
                if (list[mid].CompareTo(value) == 0) return mid;
                if (list[mid].CompareTo(value) == -1) low = mid + 1;
                else high = mid - 1;
            }
            return -1;
        }

        /// <summary>
        /// 获取折半位置
        /// </summary>
        /// <param name="searchValue">查询值</param>
        /// <param name="lowValue">低位值</param>
        /// <param name="highValue">高位值</param>
        /// <param name="high">高位索引</param>
        /// <param name="low">低位索引</param>
        /// <returns>折半位置</returns>
        private int GetMiddleIndex(double searchValue, double lowValue, double highValue, int high, int low)
        {
            return (int)(low + (searchValue - lowValue) / (highValue - lowValue) * (high - low));
        }
    }
}
