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

        public List<string> AttributeKeys { get; internal set; }

        private Rigidbody _rigidbody;
        private BehaviorParameters _behaviorParameters;
        private DecisionRequester _decisionRequester;
        private EnvironmentParameters _environmentParameters;
        private CharacterProperties _characterProperties;
        private const int TeamId = 1;

        public int DecisionPeriod { get; internal set; }
        public List<int> Enemies { get; set; }
        public int Team { get; set; }


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _behaviorParameters = GetComponent<BehaviorParameters>();
            _decisionRequester = GetComponent<DecisionRequester>();
            _characterProperties = GetComponent<CharacterProperties>();
            _environmentParameters = Academy.Instance.EnvironmentParameters;    
            DecisionPeriod = (int) _environmentParameters.GetWithDefault("decisionPeriod", 5f);
            _scale = (int) _environmentParameters.GetWithDefault("scale", _scale);
            _cartographer = new Cartographer(5,5, TeamId, _scale);
        }

        public override void OnEpisodeBegin()
        {
            Start();
            _behaviorParameters.TeamId = Team;
            _decisionRequester.DecisionPeriod = DecisionPeriod;
            _characterProperties.enemies = Enemies;
            _characterProperties.team.Value = Team;
        }


        public override void CollectObservations(VectorSensor sensor)
        {
            float[,] obsMap = _cartographer.MatrixNnReady(AttributeKeys);

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
