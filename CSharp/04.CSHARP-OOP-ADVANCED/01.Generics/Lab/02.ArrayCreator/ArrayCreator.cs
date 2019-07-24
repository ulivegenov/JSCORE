using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public static class ArrayCreator
{
    public static T[] Create<T>(int lenght, T item)
    {
        T[] array = new T[lenght];
        for (int i = 0; i < lenght; i++)
        {
            array[i] = item;
        }

        return array;
    }
}

