using System.Linq;

namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;

        //UHHHH someting to fixhere
        public MyArrayList(int capacity)
        {
            data = new int[capacity];
            size = 0;
        }

        public void Add(int n)
        {
            if (data.Length == size) { throw new MyArrayListFullException(); }
            data[size + 1] = n;
            size++;
        }

        public int Get(int index)
        {
            if (index < size) throw new MyArrayListIndexOutOfRangeException();
            return data[index];
        }

        public void Set(int index, int n)
        {
            // Write implementation here
            throw new System.NotImplementedException();
        }

        public int Capacity()
        {
            return size;
        }

        public int Size()
        {
            return data.Length;

        }

        public void Clear()
        {
            data = null;
            size = 0;
        }

        public int CountOccurences(int n)
        {
            var occurence = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == n)
                {
                    occurence++;
                }
            }
            return occurence;
        }
    }
}
