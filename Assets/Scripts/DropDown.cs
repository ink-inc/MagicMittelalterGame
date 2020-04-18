using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    [HideInInspector]
    public int arrayIndex = 0;

    [HideInInspector]
    public string[] array = new string[] { "alpha", "beta", "gamma" };

    [HideInInspector]
    public int listIndex = 0;

    [HideInInspector]
    public List<string> list = new List<string>(new string[] { "alpha", "beta", "gamma" });
}