using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using FreshManBasicDiamondTest.SortTest;

namespace FreshManBasicDiamondTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Type> classTypeList = new List<Type>
            {
                //typeof(BinarySearchTreeTest),
                typeof(MoreSortTest)
            };

            var stopwatch = Stopwatch.StartNew();
            foreach (var type in classTypeList)
            {
                var pgtester = Activator.CreateInstance(type);
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly |BindingFlags.GetProperty).Where(f=>!f.Name.Contains("get_")))
                {
                    var testwatch = Stopwatch.StartNew();
                    Console.Write("Running\t" + method.Name + "\tin FreshCommonUtilityNetTest:");
                    method.Invoke(pgtester, null);
                    Console.WriteLine("\t- OK! \t{0}ms", testwatch.ElapsedMilliseconds);
                }

            }
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            Console.ReadKey();
        }
    }
}
