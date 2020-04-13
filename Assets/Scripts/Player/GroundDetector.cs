using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private const string GroundTypePrefix = "GroundType_";
    private String _groundType;
    public List<GameObject> currentCollisions = new List<GameObject>();

    public string GroundType => _groundType;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("AreaTrigger")) return;

        if (other.name != "Underwater PostFX") { 
            currentCollisions.Add(other.gameObject);
        }
        
        Material material = other.GetComponent<Renderer>().material;
        _groundType = material.name;
    }

    public void OnTriggerExit(Collider other)
    {
        currentCollisions.Remove(other.gameObject);
        
        if (other.tag.Contains(GroundTypePrefix))
        {
            _groundType = null;
        }
    }
}