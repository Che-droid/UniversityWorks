using System.Collections;

namespace PracticeLib
{
    public class DoubleLinkedListEnumerator : IEnumerator//class for iteration through the list
    {
        int index = -1;
        DoubleLinkedList list;

        public DoubleLinkedListEnumerator(DoubleLinkedList _list)
        {
            list = _list;
        }

        object IEnumerator.Current
        {
            get
            {
                if (index < 0 || list.Length <= index)
                    return default(Element);
                return list.GetNode(index).element;
            }
        }

        public bool MoveNext()//move to the next element of list
        {
            index++;
            return index < list.Length;
        }

        public void Reset()//move to the 0 element of the list
        {
            index = -1;
        }
    }
}
