using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthUpdate : MonoBehaviour
{
    public PlayerHealthbar e;
    public PlayerProperties prop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        e.SetHealth(prop.GetCurHealth());
    }
}
