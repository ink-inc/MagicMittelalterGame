using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class NPCHealthbar : PlayerHealthbar
{
    private Transform _playerCamera;

    private void Start()
    {
        _playerCamera = FindObjectOfType<Camera>().transform;
    }

    private void Update()
    {
        base.Update();
    }

    private void LateUpdate()
    {
        transform.LookAt(_playerCamera);
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
