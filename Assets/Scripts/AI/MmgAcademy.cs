using System.Collections.Generic;
using System.Linq;
using Unity.MLAgents;
using Unity.MLAgents.SideChannels;
using UnityEngine;

namespace AI
{
    public class MmgAcademy : MonoBehaviour
    {
        public GameObject baseAgent;
        
        private ConfigurationSideChannel _configurationSideChannel;
        private DebugSideChannel _debugSideChannel;
        private EnvironmentParameters _environmentParameters;

        private void Awake()
        {
            Academy.Instance.OnEnvironmentReset += EnvironmentReset;
            _environmentParameters = Academy.Instance.EnvironmentParameters;

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

            for (int i = agents.Length; i < 2; i++)
            {
                Instantiate(baseAgent, Vector3.zero, Quaternion.identity);
            }
            
            agents = FindObjectsOfType<BaseAgent>();

            List<int> agentIdx = Enumerable.Range(0, agents.Length).ToList();
            
            for (int index = 0; index < agents.Length; index++)
            {
                BaseAgent agent = agents[index];
                agent.EndEpisode();
                agent.Team = index+1; //Team = 0 are environment objects
                agent.Enemies = agentIdx.Where(i => i != index).ToList();
                agent.AttributeKeys = _configurationSideChannel.AttributeKeys;
                agent.DecisionPeriod = (int) _environmentParameters.GetWithDefault("decisionPeriod", 5f);
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
    
    