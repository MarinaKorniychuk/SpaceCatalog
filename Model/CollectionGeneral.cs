using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCatalog.Model
{
    public class CollectionGeneral<T> : IList<T>, INotifyCollectionChanged
    {

        private T[] array;
        private int count;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public CollectionGeneral(int capacity = 16)
        {
            count = 0;
            array = new T[capacity];
        }

        #region IList<T> members

        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                    throw new ArgumentOutOfRangeException();
                return array[index];
            }

            set
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException();
                try
                {
                    array[index] = (T)value;
                }
                catch
                {
                    throw new InvalidCastException("Wrong type of argument");
                }
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException("The value of an index is outside the allowable range of values");
            if (count == array.Length)
                Array.Resize<T>(ref array, array.Length * 2);
            try
            {
                T temp = (T)item;
                for (int i = array.Length; i > index; i--)
                    array[i] = array[i - 1];
                array[index] = item;
                count++;
                if (CollectionChanged != null)
                    CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            }
            catch
            {
                throw new InvalidCastException("Wrong type of argument");
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException("The value of an index is outside the allowable range of values");
            for (int i = index; i < array.Length - 1; i++)
                array[i] = array[i + 1];
            count--;
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

        }
        #endregion

        #region ICollection<T> Members
        public void Add(T item)
        {
            if (count == array.Length)
                Array.Resize<T>(ref array, array.Length * 2);
            array[count] = item;
            try
            {
                array[count] = item;
                count++;
                if (CollectionChanged != null)
                    CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
            catch
            {
                throw new InvalidCastException("Wrong type of argument");
            }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }

        public int Count
        {
            get { return count; }
        }
        public void Clear()
        {
            Array.Resize<T>(ref array, 0);
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }
        public void CopyTo(T[] arr, int startIndex)
        {
            if (arr == null)
                throw new ArgumentNullException("No array");
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException("Wrong index");
            if (startIndex + this.Count > arr.Length)
                throw new ArgumentException("Require bigger array");
            for (int i = 0; i < count; i++)
                arr[i + startIndex] = array[i];
            // Array.Copy(array, 1, arr, startIndex, count);     
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }
            RemoveAt(index);
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            return true;
        }

        #endregion

        #region IEnumerable<T> members
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return array[i];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
