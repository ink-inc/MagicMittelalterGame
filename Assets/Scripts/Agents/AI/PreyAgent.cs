using System;

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

            SetReward((float) ((Math.Sqrt(2 * 11 * 11) - distance) / Math.Sqrt(2 * 11 * 11)));
        }

        private float CalculateDistanceToPredator()
        {
            throw new NotImplementedException();
        }
    }
}