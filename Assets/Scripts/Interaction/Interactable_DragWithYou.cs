using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_DragWithYou : Interactable
{
    public Transform newHolder;
    private Transform _originalHolder;
    private bool _isAttached = false;

    public void Start()
    {
        _originalHolder = transform.parent;
    }
    public override void interact()
    {
        if (_isAttached == false)
        {
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = newHolder;
            _isAttached = true;
        }
        else
        {
            //gameObject.GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = _originalHolder;
            _isAttached = false;
        }
    }
}
