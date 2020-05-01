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
            //TODO: do actual reset
        }
    }
}
    
    