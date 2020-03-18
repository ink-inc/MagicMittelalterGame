using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public List<GameObject> currentCollisions = new List<GameObject>();

    public void OnTriggerEnter(Collider other)
    {
        currentCollisions.Add(other.gameObject);
    }

    public void OnTriggerExit(Collider other)
    {
        currentCollisions.Remove(other.gameObject);
    }

    private void printAllCollisions()
    {
        foreach (GameObject gObject in currentCollisions)
        {
            print(gObject.name);
        }
    }
}