using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static bool EqualSequence(List<string> a, List<string> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }

        for (int i = 0; i < a.Count; i++)
        {
            if(a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }
}
