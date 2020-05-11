using Unity.MLAgents;
using Unity.MLAgents.SideChannels;
using UnityEngine;

namespace AI
{
    public class MmgAcademy : MonoBehaviour
    {
        private ConfigurationSideChannel _configurationSideChannel;

        private void Awake()
        {
            Academy.Instance.OnEnvironmentReset += EnvironmentReset;
            _configurationSideChannel = new ConfigurationSideChannel();
            SideChannelsManager.RegisterSideChannel(_configurationSideChannel);
        }


        private void EnvironmentReset ()
        {
            foreach (BaseAgent baseAgent in FindObjectsOfType<BaseAgent>())
            {
                baseAgent.EndEpisode();
                baseAgent.AttributeKeys = _configurationSideChannel.AttributeKeys;
                _configurationSideChannel.SendActiveObservation();
                _configurationSideChannel.SendActiveActions();
            }
            
            //TODO: get Random Scene
        }

        private void OnDestroy()
        {
            if (Academy.IsInitialized)
            {
                SideChannelsManager.UnregisterSideChannel(_configurationSideChannel);
            }
        }
    }
}
    
    