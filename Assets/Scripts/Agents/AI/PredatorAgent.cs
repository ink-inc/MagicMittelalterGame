using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Agents.AI
{
    public class PredatorAgent : BaseAgent
    {
        private void Update()
        {
            AddReward(-0.1f);
        }

        public override void OnActionReceived(float[] vectorAction)
        {
            base.OnActionReceived(vectorAction);

            float distance = CalculateDistanceToPrey();
            float reward = (float) ((Math.Sqrt(2 * 11 * 11) - distance) / Math.Sqrt(2 * 11 * 11));

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