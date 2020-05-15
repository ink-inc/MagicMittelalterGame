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
            _debugSideChannel = new DebugSideChannel();
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
            

            List<Arena> arenas = FindObjectsOfType<Arena>().ToList();

            foreach (Arena arena in arenas)
            {
                List<BaseAgent> agents = arena.gameObject.GetComponentsInChildren<BaseAgent>().ToList();

                for (int i = agents.Count; i < 3; i++)
                {
                    BaseAgent agent = Instantiate(baseAgent, Vector3.zero, Quaternion.identity).GetComponent<BaseAgent>();
                    agent.Team = Random.Range(1, 10);
                    agent.transform.parent = arena.transform;
                    agents.Add(agent);
                }
                
                List<int> agentIdx = Enumerable.Range(0, agents.Count).ToList();
            
                for (int index = 0; index < agents.Count; index++)
                {
                    BaseAgent agent = agents[index];
                    agent.Team = index+1; //Team = 0 are environment objects
                    agent.Enemies = agentIdx.Where(i => i != index).ToList();
                    agent.AttributeKeys = _configurationSideChannel.AttributeKeys;
                    agent.DecisionPeriod = (int) _environmentParameters.GetWithDefault("decisionPeriod", 5f);
                }
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
    
    