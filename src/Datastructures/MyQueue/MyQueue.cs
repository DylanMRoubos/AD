using System.Collections.Generic;

namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        List<T> queue = new List<T>();

        public bool IsEmpty()
        {
            if (queue.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void Enqueue(T data)
        {
            queue.Insert(queue.Count, data);
        }

        public T GetFront()
        {
            if (queue.Count == 0) throw new MyQueueEmptyException();

            return queue[0];
        }

        public T Dequeue()
        {
            if (queue.Count == 0) throw new MyQueueEmptyException();

            var item = queue[0];
            queue.RemoveAt(0);
            return item;
        }

        public void Clear()
        {
            queue = null;
        }

    }
}