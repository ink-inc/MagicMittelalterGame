using System;
using System.Collections.Generic;
using Unity.MLAgents.SideChannels;
using UnityEngine;

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
                    if (!_allKeys.Contains(message)) SendError($"This obs key does not exists: {message}.");
                    _attributeKeys.Add(message);
                    break;
            }
        }

        public void SendActiveObservation()
        {
            
            using (OutgoingMessage message = new OutgoingMessage())
            {
               Debug.Log(_attributeKeys.ToString());
                message.WriteString($"obs: {string.Join(", ", _attributeKeys)}");
                QueueMessageToSend(message);
            }
        }
    }
}