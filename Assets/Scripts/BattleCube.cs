using Sounds.Manager;
using UnityEngine;

public class BattleCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Some one enter battle cube.");
        if (other.name == "Player")
        {
            GameObject.Find("Player").GetComponent<MusicManager>().Fight();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "GroundDetector")
        {
            GameObject.Find("Player").GetComponent<MusicManager>().Background("Default");
        }
    }
}
    