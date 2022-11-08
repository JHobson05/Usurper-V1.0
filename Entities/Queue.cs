using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class Queue
    {
        //Custom queue data type desgined specifically for integers. Main use is in found in the Battle State to determine which character is attacking.
        private int[] queue;
        private int fPointer, rPointer,Size,cSize;
        public Queue(int size)
        {
            queue = new int[size];
            fPointer = 0;
            rPointer = 0;
            Size = size;
            cSize = 0;
        }

        public void Enqueue(int value)
        {
            if (!isFull())
            {
                queue[fPointer] = value;
                fPointer = (fPointer + 1) % Size;
                cSize++;
            }
            else return;
        }

        //Will fix at some point. Probably
        public int Dequeue()
        {
            if (!isEmpty())
            {
                int value = queue[rPointer];
                rPointer = (rPointer + 1) % Size;
                cSize--;
                return value;
            }
            return -1;
        }

        public int Pointer()
        {
            return rPointer;
        }

        public bool isEmpty()
        {
            if (cSize <= 0)
            {
                return true;
            }
            else return false;
        }

        public bool isFull()
        {
            if (cSize >= Size)
            {
                return true;
            }
            else return false;
        }
    }
}
