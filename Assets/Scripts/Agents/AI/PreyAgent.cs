using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Agents.AI
{
    public class PreyAgent : BaseAgent
    {
        private void Update()
        {
            AddReward(0.1f);
        }

        public override void OnActionReceived(float[] vectorAction)
        {
            base.OnActionReceived(vectorAction);

            float distance = CalculateDistanceToPredator();
            float reward = (float) (distance / Math.Sqrt(2 * 11 * 11));

            Debug.Log($"pred: {reward}");
            SetReward(reward);
        }

        private float CalculateDistanceToPredator()
        {
            List<GameObject> predators = GameObject.FindGameObjectsWithTag("Predator").ToList();
            return predators.Max(predator =>
                Mathf.Abs(Vector3.Distance(transform.position, predator.transform.position)));
        }
    }
}