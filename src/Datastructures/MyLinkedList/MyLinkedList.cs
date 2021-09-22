using System;

namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyLinkedListNode<T> first;
        private int size;

        public MyLinkedList()
        {
            first = null;
            size = 0;
        }

        public void AddFirst(T data)
        {
            first = new MyLinkedListNode<T>()
            {
                data = data,
                next = first
            };
            size++;
        }

        public T GetFirst()
        {
            if (size == 0)
            {
                throw new MyLinkedListEmptyException();
            }
            return first.data;
        }

        public void RemoveFirst()
        {
            if (size == 0)
            {
                throw new MyLinkedListEmptyException();
            }
            first = first.next;
            size--;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            first = null;
            size = 0;
        }

        public void Insert(int index, T data)
        {
            if (first == null) throw new MyLinkedListEmptyException();

            if (index < 0 || index > size) throw new MyLinkedListIndexOutOfRangeException();

            MyLinkedListNode<T> prev = null;
            MyLinkedListNode<T> next = first;
            for (int i = 0; i < size; i++)
            {
                if (index == i)
                {
                    if (next == null)
                    {
                        first = new MyLinkedListNode<T>
                        {
                            data = data,
                        };
                        size++;
                        return;
                    }
                    else
                    {
                        prev.next = new MyLinkedListNode<T>
                        {
                            data = data,
                            next = next
                        };
                        size++;
                        return;

                    }
                }
                if (next.next != null)
                {
                    prev = next;
                    next = next.next;
                }
            }
        }

        public override string ToString()
        {
            if (size == 0) return "NIL";

            var current = first;

            var text = "[";

            for (int i = 0; i < size; i++)
            {
                if (i != size - 1)
                {
                    text += $"{current.data},";
                }
                else
                {
                    text += $"{current.data}]";
                }
                current = current.next;
            }
            return text;
        }
    }
}