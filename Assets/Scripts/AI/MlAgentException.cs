using System;

namespace AI
{
    public class MlAgentException : Exception
    {
        public MlAgentException() : base("ML-Agents does not support behaviour parameters to be changed at runtime.")
        {
            
        }
    }
}