using System;
using System.Collections.Generic;

namespace DataAccessLayer.Abstractions
{
    public abstract class AbstractStorage<T>
    {
        public List<T> Data { get; }

        public void Add(T item) => Data.Add(item);

        public bool Remove(T item) => Data.Remove(item);

        public List<T> Find(Func<T, bool> predicate)
        {
            List<T> ans = new List<T>();
            foreach (var item in Data)
            {
                if (predicate(item))
                {
                    ans.Add(item);
                }
            }

            return ans.Count != 0 ? ans : null;
        }
    }
}