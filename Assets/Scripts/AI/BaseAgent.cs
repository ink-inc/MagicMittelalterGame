using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace AI
{
    public class BaseAgent : Agent
    {
        private Cartographer _cartographer;
        private List<string> _attributeKeys;
        private Rigidbody _rigidbody;

        private void Start()
        {
            if (!TryGetComponent(typeof(AiWrapper), out Component _))
            {
                throw new MissingComponentException("An agents needs an AiWrapper, but none could be found.");
            }

            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void OnEpisodeBegin()
        {
            _cartographer = new Cartographer(5,5, 1);
            _attributeKeys = new List<string>();
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