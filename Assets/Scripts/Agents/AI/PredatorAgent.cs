using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Agents.AI
{
    public class PredatorAgent : BaseAgent
    {
        private const float width = 6f;

        private void Update()
        {
            AddReward(-0.1f);
        }

        public override void OnActionReceived(float[] vectorAction)
        {
            base.OnActionReceived(vectorAction);

            float distance = CalculateDistanceToPrey();
            float reward = (float) ((Math.Sqrt(2 * width * width) - distance) / Math.Sqrt(2 * width * width));

            Debug.Log($"pred: {reward}");
            SetReward(reward);
        }

        private float CalculateDistanceToPrey()
        {
            List<GameObject> preys = GameObject.FindGameObjectsWithTag("Prey").ToList();
            return preys.Min(prey => Mathf.Abs(Vector3.Distance(transform.position, prey.transform.position)));
        }
    }
}