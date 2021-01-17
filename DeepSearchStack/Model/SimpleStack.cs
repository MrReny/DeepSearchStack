using System.Collections;
using System.Collections.Generic;

namespace DeepSearchStack
{
    public class SimpleStack<T>:IEnumerable<T>
    {
        private List<T> _list = new List<T>();

        public bool IsEmpty => _list.Count == 0;
        public int Push(T value)
        {
            _list.Add(value);
            return _list.Count - 1;
        }

        public T Peek()
        {
            var value = _list[_list.Count - 1];
            return value;
        }

        public T Pull()
        {
            var value = _list[_list.Count - 1];
            _list.RemoveAt(_list.Count - 1);
            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}