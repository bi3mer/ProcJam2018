using System.Collections;
using UnityEngine;

public static  class ListExtensions
{
    public static void Shuffle(this IList list)
    {
        int length = list.Count;
        for (int i = 0; i < length; ++i)
        {
            int randomIndex = Random.Range(i, list.Count);
            object temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
