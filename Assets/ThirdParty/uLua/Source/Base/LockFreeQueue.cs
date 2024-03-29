﻿/*
作者: 蒙占志 日期: 2013-11-22
作用: 无锁一读一写线程安全队列
*/
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;


#if NO_LOCK
//完全多线程安全的，但IOS AOT编译不过
internal sealed class SingleLinkNode<T>
{
    public SingleLinkNode(T item)
    {
        this.Item = item;
    }

    public SingleLinkNode<T> Next = null;
    public T Item;
}

public class LockFreeQueue<T>
{
    SingleLinkNode<T> head;
    SingleLinkNode<T> tail;
    private int count;    

    public int Count
    {
        get
        {
            return count;
        }
    }

    public LockFreeQueue()
    {
        head = new SingleLinkNode<T>(default(T));
        tail = head;
        count = 0;
    }

    bool CAS(ref SingleLinkNode<T> location, SingleLinkNode<T> comparand, SingleLinkNode<T> newValue)
    {
        return comparand == Interlocked.CompareExchange<SingleLinkNode<T>>(ref location, newValue, comparand);
    }

    public void Clear()
    {        
        do
        {
            tail = head;
        }
        while (!CAS(ref head.Next, tail.Next, null));
    }

    public bool IsEmpty()
    {
        return count <= 0;
    }

    public void Enqueue(T item)
    {
        SingleLinkNode<T> oldTail = null;
        SingleLinkNode<T> oldNext = null;

        SingleLinkNode<T> node = new SingleLinkNode<T>(item);        
        
        /* 循环直到更新tail的next指向我们新的node节点 */
        bool UpdatedNewLink = false;

        while (!UpdatedNewLink)
        {
            /* 保留tail和他的next一分本地拷贝，避免其他线程改动tail */
            oldTail = tail;
            oldNext = oldTail.Next; /*必须用oldTail，本地拷贝, 因为tail可能被其他线程改动了*/

            if (tail == oldTail)
            {
                if (oldNext == null && CAS(ref tail.Next, null, node))
                {
                    //tail.next = node
                    Interlocked.Increment(ref count);
                    UpdatedNewLink = true;
                }
                else
                {
                    /*tail = tail.next*/
                    CAS(ref tail, oldTail, oldNext);
                }
            }
        }

        /* tail = node*/
        CAS(ref tail, oldTail, node);        
    }

    public T Dequeue()
    {        
        T result = default(T);
        bool HaveAdvancedHead = false;             

        while (!HaveAdvancedHead)
        {            
            SingleLinkNode<T> oldHead = head;
            SingleLinkNode<T> oldTail = tail;
            SingleLinkNode<T> oldHeadNext = oldHead.Next;
            
            if (oldHead == head)
            {                
                if (oldHead == oldTail)
                {                    
                    if (oldHeadNext == null)
                    {                        
                        return default(T);
                    }
                    
                    CAS(ref tail, oldTail, oldHeadNext);
                }                
                else
                {                    
                    result = oldHeadNext.Item;
                    HaveAdvancedHead = CAS(ref head, oldHead, oldHeadNext);                    
                }
            }
        }

        Interlocked.Decrement(ref count);
        return result;
    }
}

#else
/*一读一写安全队列*/
public class LockFreeQueue<T>
{
    public int head;
    public int tail;
    public T[] items;

    //public int Count
    //{
    //    get
    //    {
    //        return tail - head;
    //    }
    //}

    private int capacity;

    public LockFreeQueue()
        : this(512) //防止大量服务器包涌入
    {
    }

    public LockFreeQueue(int count)
    {
        items = new T[count];
        lock (this)
        {
            tail = head = 0;
            capacity = count;
        }
    }

    public bool IsEmpty()
    {
        bool bEmpty = true;
        lock (this)
        {
           bEmpty = (head == tail);
        }
        return bEmpty;
    }

    public void Clear()
    {
        lock (this)
        {
            head = tail = 0;
        }
    }

    bool IsFull()
    {
        bool bFull = false;
        lock (this)
        {
            bFull = (tail - head >= capacity);
        }
        return bFull;
    }
    
    public void Enqueue(T item)
    {
        while (IsFull())
        {
            System.Threading.Thread.Sleep(1);
        }

        int pos = 0;
        lock (this)
        {
            pos = tail % capacity;
            ++tail;
        }
        //只锁位置，不锁整个队列，这样减少整个锁占用的时间，防止锁等待
        items[pos] = item;
    }
    
    public T Dequeue()
    {
        if (IsEmpty())
        {
            return default(T);
        }

        int pos = 0;
        lock (this)
        {
            pos = head % capacity;
            ++head;
        }
        //因为POS是锁定计算出来的，所以直接用已经是安全的了
        T item = items[pos];        
        return item;
    }
}
#endif