using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class ShuffleAlgo 
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
       for(int i = 0; i < n; i++)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
