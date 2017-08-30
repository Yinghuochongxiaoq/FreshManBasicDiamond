using FreshManBasicDiamond.Tree;

namespace FreshManBasicDiamondTest.Tree
{
    public class BinarySearchTreeTest
    {
        /// <summary>
        /// 测试平衡树
        /// </summary>
        public void TestSearchTree()
        {
            var search = new BinarySearchTree();
            search.Add(40);
            search.Add(25);
            search.Add(50);
            search.Add(10);
            search.Add(70);
            search.Add(43);

            search.PreOrder(search.Head);
            search.InOrder(search.Head);
            search.PostOrder(search.Head);
        }
    }
}
