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
        if (other.name != "Underwater PostFX") { 
            currentCollisions.Add(other.gameObject);
        }

        if (other.tag.Contains(GroundTypePrefix))
        {
            _groundType = other.tag.Replace(GroundTypePrefix, "");
        }
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