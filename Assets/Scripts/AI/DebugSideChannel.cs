using System;
using Unity.MLAgents.SideChannels;

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
    }
    
    
}