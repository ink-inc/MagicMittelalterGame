using System;
using System.Collections.Generic;
using AI;
using Character;
using Unity.MLAgents;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors;
using UnityEngine;
using CharacterController = Character.CharacterController;
using Random = UnityEngine.Random;

namespace Agents.AI
{
    [RequireComponent(typeof(AiWrapper))]
    [RequireComponent(typeof(DecisionRequester))]
    [RequireComponent(typeof(CharacterProperties))]
    public class BaseAgent : Agent
    {
        private MmgAcademy _academy;
        private AiWrapper _aiWrapper;
        private BehaviorParameters _behaviorParameters;
        private Cartographer _cartographer;
        private CharacterController _characterController;
        private CharacterProperties _characterProperties;
        private DecisionRequester _decisionRequester;
        private EnvironmentParameters _environmentParameters;

        private Rigidbody _rigidbody;

        public int Scale => (int) _academy.Scale;

        public List<string> AttributeKeys { get; internal set; }

        public int DecisionPeriod { get; internal set; }
        public List<int> Enemies { get; set; }

        public int Team
        {
            get => (int) _characterProperties.team.Value;
            set => _characterProperties.team.Value = value;
        }


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _behaviorParameters = GetComponent<BehaviorParameters>();
            _decisionRequester = GetComponent<DecisionRequester>();
            _characterProperties = GetComponent<CharacterProperties>();
            _characterController = GetComponent<CharacterController>();
            _environmentParameters = Academy.Instance.EnvironmentParameters;
            _academy = FindObjectOfType<MmgAcademy>();
            DecisionPeriod = (int) _environmentParameters.GetWithDefault("decisionPeriod", 5f);

            _cartographer = new Cartographer((int) _academy.MapShape.x, (int) _academy.MapShape.y, Team, Scale);
            _aiWrapper = GetComponent<AiWrapper>();
        }

        public override void OnEpisodeBegin()
        {
            Start();
            _decisionRequester.DecisionPeriod = DecisionPeriod;
            _characterProperties.enemies = Enemies;
        }


        public override void CollectObservations(VectorSensor sensor)
        {
            Vector3 position = _aiWrapper.Position;
            float[,] obsMap = _cartographer.MatrixNnReady(AttributeKeys, (int) position.x, (int) position.z);

            int expectedSize = (5 * 2 * Scale + 1);
            expectedSize *= expectedSize;
            if (obsMap.GetLength(0) != expectedSize)
            {
                throw new Exception(
                    $"Map does not have the correct size. Expected: {expectedSize}, but was {obsMap.GetLength(0)}");
            }

            foreach (float observation in obsMap)
            {
                sensor.AddObservation(observation);
            }
        }

        public override void OnActionReceived(float[] vectorAction)
        {
            const float factor = 20f;
            const float rotationFactor = 3f;
            float forceX = vectorAction[0] * factor;
            float forceZ = vectorAction[1] * factor;
            float rotation = vectorAction[0] * rotationFactor;
            _characterController.Movement(forceX, forceZ, _characterProperties);
            _characterController.Rotation(rotation);
        }

        public override void Heuristic(float[] actionsOut)
        {
            for (int i = 0; i < actionsOut.Length; i++)
            {
                actionsOut[i] = Random.Range(-1f, 1f);
            }
        }
    }
}