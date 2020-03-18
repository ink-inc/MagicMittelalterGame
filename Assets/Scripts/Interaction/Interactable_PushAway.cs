using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_PushAway : Interactable
{
    public float force = 5f;
    public Rigidbody rb;
    public override void interact()
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}
