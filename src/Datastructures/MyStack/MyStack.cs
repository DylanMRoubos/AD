using System;

namespace AD
{
    public partial class MyStack<T> : IMyStack<T>
    {
        public MyLinkedList<T> stack = new MyLinkedList<T>();

        public bool IsEmpty()
        {
            if(stack.Size() == 0)
            {
                return true;
            }
            return false;
        }

        public T Pop()
        {
            if (stack.Size() == 0) throw new MyStackEmptyException();
            var item = stack.GetFirst();
            stack.RemoveFirst();
            return item;
        }

        public void Push(T data)
        {            
            stack.AddFirst(data);
        }

        public T Top()
        {
            if (stack.Size() == 0) throw new MyStackEmptyException();
            return stack.GetFirst();
        }
    }
}
