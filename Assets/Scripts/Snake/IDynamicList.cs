namespace Snake
{
    public interface IDynamicList<T>
    {
        public int Count { get; }

        public int IndexOf(T item);

        public void PrintList();

        public void Add(T item);

        public bool Contains(T item);

        public void Clear();
        //public void Insert(int index, T item);

        //public void RemoveAt(int index);

       
        //public void CopyTo(T[] target, int index);

        public T this[int index]
        {
            get;
            set;
        }
    }
}


