using System.Collections.Generic;
using System.Linq;
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
            
            BaseAgent[] agents = FindObjectsOfType<BaseAgent>();
            List<int> agentIdx = Enumerable.Range(0, agents.Length).ToList();
            for (int index = 0; index < agents.Length; index++)
            {
                BaseAgent baseAgent = agents[index];
                baseAgent.EndEpisode();
                baseAgent.Team = index+1; //Team = 0 are environment objects
                baseAgent.Enemies = agentIdx.Where(i => i != index).ToList();
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
    
    