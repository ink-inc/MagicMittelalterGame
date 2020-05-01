using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace AI
{
    public class BaseAgent : Agent
    {
        private Cartographer _cartographer;
        private List<string> _attributeKeys;
        private Rigidbody _rigidbody;
        private BehaviorParameters _behaviorParameters;
        private const int TeamId = 1;

        public int[] ActionSize { get; private set; }

        private void Start()
        {
            if (!TryGetComponent(typeof(AiWrapper), out Component _))
            {
                throw new MissingComponentException("An agents needs an AiWrapper, but none could be found.");
            }

            _rigidbody = GetComponent<Rigidbody>();
            _behaviorParameters = GetComponent<BehaviorParameters>();
            ActionSize = new []{2,2,1};

        }

        public override void OnEpisodeBegin()
        {
            _cartographer = new Cartographer(5,5, TeamId);
            _attributeKeys = new List<string>();
            _behaviorParameters.TeamId = TeamId;
            _behaviorParameters.BrainParameters.VectorObservationSize = _attributeKeys.Count;
            _behaviorParameters.BrainParameters.VectorActionSize = ActionSize;
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            foreach (float observation in _cartographer.MatrixNnReady(_attributeKeys))
            {
                sensor.AddObservation(observation);
            }
        }
        public override void OnActionReceived(float[] vectorAction)
        {
            Vector3 move = new Vector3(vectorAction[0], 0, vectorAction[1]);
            _rigidbody.AddForce(move);
            transform.Rotate(vectorAction[0],  vectorAction[1], 0);
        }
    }
}