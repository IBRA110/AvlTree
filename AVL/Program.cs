using AvlTree;

namespace Program
{
    public class StartApp
    {
        public static void Main() 
        {

            AvlTree<int> t = new(1, 2);

            List<int> arr = [4, 5, 6, 1, 2, 3, 7, 8];

            foreach (int i in arr)
            {
                t.Insert(i, i);
            }

            foreach(int i in t.InOrder())
            {
                Console.WriteLine(i);
            }
        }
    }
}