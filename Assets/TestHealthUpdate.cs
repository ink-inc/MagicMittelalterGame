using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthUpdate : MonoBehaviour
{
    public PlayerHealthbar e;
    public PlayerProperties prop;

    private void FixedUpdate()
    {
        e.SetHealth(prop.GetCurHealth());
    }
}
