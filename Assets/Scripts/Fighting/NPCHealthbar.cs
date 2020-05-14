using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class NPCHealthbar : PlayerHealthbar
{
    public Transform playerCamera;

    private void Update()
    {
        base.Update();
    }

    public void LateUpdate()
    {
        transform.LookAt(playerCamera);
        transform.Rotate(0f, 180f, 0f);
    }

    public void Refresh()  //Adjusts red health bar to current health
    {
        base.Refresh();
    }

    public void OnChange(Float f)
    {
        Refresh();
    }

    public void OnEnable()
    {
        base.OnEnable();
    }

    public void OnDisable()
    {
        base.OnEnable();
    }
}
