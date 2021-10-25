using System;


namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T>
        where T : IComparable<T>
    {
        public static int DEFAULT_CAPACITY = 100;
        public int size;   // Number of elements in heap
        public T[] array;  // The heap array

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public PriorityQueue()
        {
            size = 0;
            array = new T[DEFAULT_CAPACITY];
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            size = 0;
            array = new T[DEFAULT_CAPACITY];
        }

        public void Add(T x)
        {
            //check if array will be too small
            if (size + 1 == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
            int hole = ++size;

            array[hole] = x;

            if(size != 1)
            {
                for (int i = size; i > 1; i /= 2)
                {
                    if (array[i / 2].CompareTo(array[i]) > 0)
                    {
                        var temp = array[i / 2];
                        array[i / 2] = array[i];
                        array[i] = temp;
                    }
                }
            }
        }

        // Removes the smallest item in the priority queue
        public T Remove()
        {
            if (size == 0)
            {
                throw new PriorityQueueEmptyException();
            }

            var joe = array[1];

            array[1] = array[size];
            array[size] = default(T);
            size--;

            PercolateDown(1);

            return joe;
        }

        private void PercolateDown(int hole)
        {
            int min_index = hole;
            int left = hole * 2;
            int right = hole * 2 + 1;

            //Check if the left child is in the array, and if its smaller than the parent 
            if(left <= size && array[left].CompareTo(array[min_index]) < 0)
            {
                min_index = left;
            }
            //Check if the right child is in the array, and if its smaller than the parent or the left sibling if its changed in the if aboven
            if (right <= size && array[right].CompareTo(array[min_index]) < 0)
            {
                min_index = right;
            }
            if(min_index != hole)
            {
                var temp = array[hole];
                array[hole] = array[min_index];
                array[min_index] = temp;
                PercolateDown(min_index);
            }

        }

        public override string ToString()
        {
            if (size == 0) return "";

            var text = "";

            for (int i = 1; i < size + 1; i++)
            {
                text += array[i] + " ";
            }

            return text.Remove(text.Length - 1);
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            array[size + 1] = x;
            size++;
        }

        public void BuildHeap()
        {
            for(int i = size / 2; i > 0; i--)
            {
                PercolateDown(i);
            }
        }

    }
}
