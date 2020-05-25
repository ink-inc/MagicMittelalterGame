using System;

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

            SetReward((float) (distance / Math.Sqrt(2 * 11 * 11)));
        }

        private float CalculateDistanceToPrey()
        {
            throw new NotImplementedException();
        }
    }
}