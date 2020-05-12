using Unity.MLAgents;
using Unity.MLAgents.SideChannels;
using UnityEngine;

namespace AI
{
    public class MmgAcademy : MonoBehaviour
    {
        private ConfigurationSideChannel _configurationSideChannel;
        private DebugSideChannel _debugSideChannel;

        private void Awake()
        {
            Academy.Instance.OnEnvironmentReset += EnvironmentReset;
            
            _configurationSideChannel = new ConfigurationSideChannel();
            SideChannelsManager.RegisterSideChannel(_configurationSideChannel);
            Application.logMessageReceived += _debugSideChannel.SendDebugStatementToPython;
            SideChannelsManager.RegisterSideChannel(_debugSideChannel);
            
            _configurationSideChannel.SendActiveObservation();
            _configurationSideChannel.SendActiveActions();
            _debugSideChannel = new DebugSideChannel();
        }


        private void EnvironmentReset ()
        {
            _configurationSideChannel.SendActiveObservation();
            _configurationSideChannel.SendActiveActions();
            foreach (BaseAgent baseAgent in FindObjectsOfType<BaseAgent>())
            {
                baseAgent.EndEpisode();
                baseAgent.AttributeKeys = _configurationSideChannel.AttributeKeys;
                
            }
            //TODO: get Random Scene
        }

        private void OnDestroy()
        {
            Application.logMessageReceived -= _debugSideChannel.SendDebugStatementToPython;

            if (!Academy.IsInitialized) return;
            SideChannelsManager.UnregisterSideChannel(_configurationSideChannel);
            SideChannelsManager.UnregisterSideChannel(_debugSideChannel);
        }
    }
}
    
    