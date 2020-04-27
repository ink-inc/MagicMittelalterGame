using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static bool EqualSequence(List<string> a, List<string> b)
    {
        Debug.Log("Sequence");
        if (a.Count != b.Count)
        {
            Debug.Log("False");
            return false;
        }

        for (int i = 0; i < a.Count; i++)
        {
            if(a[i] != b[i])
            {
                Debug.Log("False");
                return false;
            }
        }
        Debug.Log("True");
        return true;
    }
}
