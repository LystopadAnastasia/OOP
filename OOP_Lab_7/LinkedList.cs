using System;
using System.Collections;

class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class LinkedList : IEnumerable
{
    private Node head;

    // Додавання елемента в кінець списку
    public void Add(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node current = head;

        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newNode;
    }

    // Підтримка foreach
    public IEnumerator GetEnumerator()
    {
        Node current = head;

        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    // Виведення списку
    public void Print()
    {
        foreach (int item in this)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }

    // 1. Знайти перший елемент більший за задане значення
    public int? FindFirstGreater(int value)
    {
        foreach (int item in this)
        {
            if (item > value)
            {
                return item;
            }
        }

        return null;
    }

    // 2. Знайти суму елементів менших за задане значення
    public int SumLessThan(int value)
    {
        int sum = 0;

        foreach (int item in this)
        {
            if (item < value)
            {
                sum += item;
            }
        }

        return sum;
    }

    // 3. Створити новий список з елементів більших за задане значення
    public LinkedList GetGreaterList(int value)
    {
        LinkedList newList = new LinkedList();

        foreach (int item in this)
        {
            if (item > value)
            {
                newList.Add(item);
            }
        }

        return newList;
    }

    // 4. Видалити елементи після максимального
    public void RemoveAfterMax()
    {
        if (head == null)
        {
            return;
        }

        Node current = head;
        Node maxNode = head;

        while (current != null)
        {
            if (current.Data > maxNode.Data)
            {
                maxNode = current;
            }

            current = current.Next;
        }

        maxNode.Next = null;
    }
}