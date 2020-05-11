using System;
using System.Collections.Generic;
using Character;
using Unity.MLAgents;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AI
{
    
    [RequireComponent(typeof(AiWrapper))] 
    [RequireComponent(typeof(DecisionRequester))] 
    [RequireComponent(typeof(CharacterProperties))]
    public class BaseAgent : Agent
    {
        private int _scale = 1;
        private Cartographer _cartographer;

        public List<string> AttributeKeys
        {
            get => _attributeKeys;
            internal set
            {
                _attributeKeys = value;
                _behaviorParameters.BrainParameters.VectorObservationSize = _attributeKeys.Count*_cartographer.Dimension;
            }
        }

        private Rigidbody _rigidbody;
        private BehaviorParameters _behaviorParameters;
        private DecisionRequester _decisionRequester;
        private EnvironmentParameters _environmentParameters;
        private List<string> _attributeKeys;
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
            _scale = (int) _environmentParameters.GetWithDefault("scale", _scale);
            _attributeKeys = new List<string>();
            _cartographer = new Cartographer(5,5, TeamId, _scale);
        }

        public override void OnEpisodeBegin()
        {
            _behaviorParameters.TeamId = TeamId;
            _behaviorParameters.BrainParameters.VectorObservationSize = _attributeKeys.Count*_cartographer.Dimension;
            _behaviorParameters.BrainParameters.VectorActionSize = ActionSize;
            _decisionRequester.DecisionPeriod = DecisionPeriod;
        }


        public override void CollectObservations(VectorSensor sensor)
        {
            float[,] obsMap = _cartographer.MatrixNnReady(_attributeKeys);

            int expectedSize = (5 * 2 * _scale + 1);
            expectedSize *= expectedSize;
            if (obsMap.GetLength(0) != expectedSize)
            {
                throw new Exception($"Map does not have the correct size. Expected: {expectedSize}, but was {obsMap.GetLength(0)}");
            }
            
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
