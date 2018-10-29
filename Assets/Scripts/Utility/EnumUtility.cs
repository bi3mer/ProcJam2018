using System.Collections.Generic;
using System;

public static class EnumUtility
{
    public static List<T> ToList<T>(bool ignoreMax = true)
    {
        List<T> list = new List<T>();

        foreach (T t in Enum.GetValues(typeof(T)))
        {
            if (ignoreMax == true && t.ToString().ToLower().Equals("max") == false)
            {
                list.Add(t);
            }
        }

        return list;
    }
}