using System;
using System.Collections.Generic;
using Unity.MLAgents.SideChannels;

namespace AI
{
    public class ConfigurationSideChannel : SideChannel
    {
        private readonly List<string> _allKeys = new List<string>
        {
            "team",
            "health",
            "armor",
            "vecX",
            "vecY",
            "vecZ",
            "height",
            "damageCounter"
        };
        private List<string> _attributeKeys;

        public List<string> AttributeKeys => _attributeKeys.Count == 0 ? _allKeys : _attributeKeys;

        public ConfigurationSideChannel()
        {
            ChannelId = new Guid("48e64270-4c96-4406-82f5-2b9e9258beae");
            _attributeKeys = new List<string>();
        }
        protected override void OnMessageReceived(IncomingMessage msg)
        {
            string message = msg.ReadString();
            switch (message)
            {
                case "clear":
                    _attributeKeys = new List<string>();
                    break;
                case "all":
                    _attributeKeys = _allKeys;
                    break;
                default:
                    if (message[0] == '!')
                    {
                        _attributeKeys.Remove(message.TrimStart('!'));
                        break;
                    }
                    if (!_allKeys.Contains(message)) SendError($"ERROR: This obs key does not exists: {message}.");
                    
                    _attributeKeys.Add(message);
                    break;
            }
        }

        private void SendError(string error)
        {
            using (OutgoingMessage message = new OutgoingMessage())
            {
                message.WriteString(error);
                QueueMessageToSend(message);
            }
        }

        public void SendActiveObservation()
        {
            
            using (OutgoingMessage message = new OutgoingMessage())
            {
                message.WriteString($"obs: {string.Join(", ", _attributeKeys)}");
                QueueMessageToSend(message);
            }
        }
    }
}