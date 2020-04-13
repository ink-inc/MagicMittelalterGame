using Sounds.Manager;
using UnityEngine;

namespace Areas
{
    public class FightingArea : SoundArea
    {
        private void OnTriggerEnter(Collider other)
        {
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
}
    