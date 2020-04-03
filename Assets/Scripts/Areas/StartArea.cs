using Sounds.Manager;
using UnityEngine;

public class StartArea : MonoBehaviour
{
    private void OnTriggerExit(Collider other) {
		if (other.name == "Player")
        {
            GameObject.Find("Player").GetComponent<MusicManager>().Background("default");
        }
	}
}
