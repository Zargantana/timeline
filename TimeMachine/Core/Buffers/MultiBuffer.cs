using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeMachine
{
    public interface IMultiBuffer<T>
    {
        void writeNew(T newElement);
        T readLast();
    }
    public class MultiBuffer<T> : IMultiBuffer<T>
    {
        public const int SIZE = 24; //1 second of lag at 24 frames per second (aprox 40ms between freames)

        T[] _internalList = new T[SIZE];
        int _writePointer = 0;        

        public void writeNew(T newElement)
        {
            _internalList[_writePointer] = newElement;
            _writePointer = (_writePointer + 1) % SIZE;            
        }

        public T readLast()
        {
            int i = _writePointer - 1;
            i = i < 0 ? SIZE - 1 : i;
            T _local = _internalList[i]; //Quick pointer copy (addref).
            return _local;
        }

    }
}
