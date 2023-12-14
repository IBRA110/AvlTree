namespace AvlTree
{
    public class AvlTree<T>
    {
        private int _key { get; set; }
        private AvlTree<T>? _left { get; set; }
        private AvlTree<T>? _right { get; set; }
        private int _height { get; set; }
        private int _parent { get; set; }
        private int _sum { get; set; }
        private T _data { get; set; }

        public int length { get; set; }

        public AvlTree(int key, T data, int parent = -1, AvlTree<T>? left = null, AvlTree<T>? right = null)
        {
            length = 1;
            _key = key;
            _left = left;
            _right = right;
            _height = 1;
            _parent = parent;
            _sum = key;
            _data = data;

            length = 1;
        }
    }
}