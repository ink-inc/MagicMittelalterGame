using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public List<GameObject> currentCollisions = new List<GameObject>();

    public void OnTriggerEnter(Collider other)
    {
        if (other.name != "Underwater PostFX") { 
            currentCollisions.Add(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        currentCollisions.Remove(other.gameObject);
    }
}