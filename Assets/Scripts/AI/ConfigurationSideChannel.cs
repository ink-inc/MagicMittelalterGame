using System;
using System.Collections.Generic;
using Unity.MLAgents.SideChannels;

namespace AI
{
    public class ConfigurationSideChannel : SideChannel
    {
        readonly List<string> _allKeys = new List<string> {"team", "health", "armor", "vecX", "vecY", "vecZ"};

        private List<string> _attributeKeys;

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
                    if (!_allKeys.Contains(message)) return;
                    _attributeKeys.Add(message);
                    break;
            }
        }
    }
}