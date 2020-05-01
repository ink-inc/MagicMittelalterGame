using Unity.MLAgents;
using UnityEngine;

namespace AI
{
    public class MmgAcademy : MonoBehaviour
    {
        private void Awake()
        {
            Academy.Instance.OnEnvironmentReset += EnvironmentReset;
        }

        
        void EnvironmentReset ()
        {
            foreach (BaseAgent baseAgent in FindObjectsOfType<BaseAgent>())
            {
                baseAgent.EndEpisode();
            }
            
            //TODO: get Random Scene
        }
    }
}
    
    