using System;
using Unity.MLAgents.SideChannels;
using UnityEngine;

namespace AI
{
    public class DebugSideChannel : SideChannel
    {
        public DebugSideChannel()
        {
            ChannelId = new Guid("0612127d-99fa-4b18-a195-7a49e048f2d6");
        }
        protected override void OnMessageReceived(IncomingMessage msg)
        {
            throw new NotImplementedException();
        }

        public void SendDebugLine(string line)
        {
            using (OutgoingMessage message = new OutgoingMessage())
            {
                message.WriteString(line);
                QueueMessageToSend(message);
            }
        }
        
        public void SendDebugStatementToPython(string logString, string stackTrace, LogType type)
        {
            if (type != LogType.Error) return;
            string stringToSend = type + ": " + logString + "\n" + stackTrace;
            using (OutgoingMessage msgOut = new OutgoingMessage())
            {
                msgOut.WriteString(stringToSend);
                QueueMessageToSend(msgOut);
            }
        }
    }
    
    
}