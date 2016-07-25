using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Catchyrime.Everything.Developer;
using static Catchyrime.Everything.Constant;

namespace Catchyrime.Everything.DSAA
{
    public class DSArray<T> : IList<T>
    {
        private SBTNode<T> m_Root = SBTNode<T>.Null;


        [Obsolete(OBSOLETE_SLOW_PERFORMACE)]
        public int IndexOf(T item)
        {
            int index = 0;
            foreach (T t in this) {
                if (object.Equals(t, item)) {  // TODO: Comparer
                    return index;
                }
                ++index;
            }
            return ILIST_INVALID_INDEX;
        }

        public void Insert([NotChecked] int index, [CanBeNull] T item)
        {
            Validations.Requires(index, nameof(index)).ArgumentInRange(0, this.Count);
            if (index == this.Count) {
                Add(item);
            }
            else {  // index < this.Count
                SBTHelper.InsertAt(ref this.m_Root, index, item);
            }
        }

        public void RemoveAt([NotChecked] int index, out T item)
        {
            Validations.Requires(index, nameof(index)).ArgumentInRange(0, this.Count - 1);
            SBTHelper.RemoveAt(ref this.m_Root, index, out item);
        }

        public void RemoveAt([NotChecked] int index)
        {
            T dummy;
            RemoveAt(index, out dummy);
        }

        public T this[[NotChecked]int index]
        {
            get {
                Validations.Requires(index, nameof(index)).IndexInRange(0, this.Count - 1);
                return SBTHelper.ElementAt(this.m_Root, index).Value;
            }
            set {
                Validations.Requires(index, nameof(index)).IndexInRange(0, this.Count);                
                if (index == this.Count) {
                    this.Add(value);
                }
                else {
                    SBTHelper.ElementAt(this.m_Root, index).Value = value;
                }
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            return SBTHelper.Enumerate(this.m_Root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add([CanBeNull] T item)
        {
            SBTHelper.InsertAtEnd(ref this.m_Root, item);
        }

        public void Clear()
        {
            this.m_Root = SBTNode<T>.Null;
        }

        [Obsolete(OBSOLETE_SLOW_PERFORMACE)]
        public bool Contains([CanBeNull] T item)
        {
            return (IndexOf(item) != ILIST_INVALID_INDEX);
        }

        public void CopyTo(
            [NotChecked_NotNull] T[] array, 
            [NotChecked] int arrayIndex
            )
        {
            Validations.Requires(array, nameof(array)).ArgumentNotNull();
            Validations.Requires(arrayIndex, nameof(arrayIndex)).ArgumentNotNegative();
            Validations.Requires(array.Length, nameof(array.Length)).GreaterOrEqual(arrayIndex + this.Count);

            SBTHelper.CopyToArray(this.m_Root, array, ref arrayIndex);
        }

        [Obsolete(OBSOLETE_SLOW_PERFORMACE)]
        public bool Remove([CanBeNull] T item)
        {
            int index = IndexOf(item);
            if (index == ILIST_INVALID_INDEX) {
                return false;
            }
            else {
                RemoveAt(index);
                return true;
            }
        }

        public int Count => this.m_Root.Size;

        public bool IsReadOnly => false;

    }
}
