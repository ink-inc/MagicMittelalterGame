using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace AI
{
    [RequireComponent(typeof(AiWrapper))] 
    [RequireComponent(typeof(DecisionRequester))] 
    public class BaseAgent : Agent
    {
        private Cartographer _cartographer;
        public List<string> AttributeKeys { get; internal set; }
        private Rigidbody _rigidbody;
        private BehaviorParameters _behaviorParameters;
        private DecisionRequester _decisionRequester;
        private EnvironmentParameters _environmentParameters;
        private const int TeamId = 1;

        public int[] ActionSize { get; private set; }
        public int DecisionPeriod { get; private set; }


        private void Start()
        {
            
            _rigidbody = GetComponent<Rigidbody>();
            _behaviorParameters = GetComponent<BehaviorParameters>();
            _decisionRequester = GetComponent<DecisionRequester>();
            _environmentParameters = Academy.Instance.EnvironmentParameters;    
            ActionSize = new[] {(int) _environmentParameters.GetWithDefault("actionSize", 3f)};
            DecisionPeriod = (int) _environmentParameters.GetWithDefault("decisionPeriod", 5f);
            AttributeKeys = new List<string>();
            _cartographer = new Cartographer(5,5, TeamId);
        }

        public override void OnEpisodeBegin()
        {
            _behaviorParameters.TeamId = TeamId;
            _behaviorParameters.BrainParameters.VectorObservationSize = AttributeKeys.Count*_cartographer.Dimension;
            _behaviorParameters.BrainParameters.VectorActionSize = ActionSize;
            _decisionRequester.DecisionPeriod = DecisionPeriod;
        }


        public override void CollectObservations(VectorSensor sensor)
        {
            float[,] obsMap = _cartographer.MatrixNnReady(AttributeKeys);
            foreach (float observation in obsMap)
            {
                sensor.AddObservation(observation);
            }
        }
        public override void OnActionReceived(float[] vectorAction)
        {
            const float factor = 20f;
            float forceX = vectorAction[0]*factor;
            float forceZ = vectorAction[1]*factor;
            Vector3 move = new Vector3(forceX, 0, forceZ);
            _rigidbody.AddForce(move);
            _rigidbody.AddTorque(forceX,  forceZ, 0);
        }

        public override void Heuristic(float[] actionsOut)
        {
            actionsOut[0] = Random.Range(-1f, 1f);
            actionsOut[1] = Random.Range(-1f, 1f);
        }
    }
}