using System;
using System.Collections.Generic;
using Unity.MLAgents.SideChannels;
using UnityEngine;

namespace AI
{
    public class ConfigurationSideChannel : SideChannel
    {
        private readonly List<string> _actions;

        private readonly List<string> _allActions = new List<string>
        {
            "forceX",
            "forceZ"
        };

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


        public ConfigurationSideChannel()
        {
            ChannelId = new Guid("48e64270-4c96-4406-82f5-2b9e9258beae");
            _attributeKeys = new List<string>();
            //This will change once ML-Agents supports dynamic change of behaviour parameter.
            _actions = _allActions;
        }

        public List<string> AttributeKeys => _attributeKeys.Count == 0 ? _allKeys : _attributeKeys;

        public List<string> Actions => _actions.Count == 0 ? _allActions : _actions;

        protected override void OnMessageReceived(IncomingMessage msg)
        {
            string message = msg.ReadString();
            switch (message)
            {
                case "clear":
                    throw new MlAgentException();
                    _attributeKeys = new List<string>();
                    break;
                case "all":
                    _attributeKeys = _allKeys;
                    break;
                default:
                    throw new MlAgentException();
                    if (message[0] == '!')
                    {
                        _attributeKeys.Remove(message.TrimStart('!'));
                        break;
                    }

                    if (!_allKeys.Contains(message)) SendError($"ERROR: This obs key does not exists: {message}.");

                    if (!_attributeKeys.Contains(message))
                    {
                        _attributeKeys.Add(message);
                    }

                    break;
            }
        }

        internal void SendError(string error)
        {
            using (OutgoingMessage message = new OutgoingMessage())
            {
                message.WriteString(error);
                QueueMessageToSend(message);
            }
        }

        public void SendMapShape(Vector2 mapShape)
        {
            using (OutgoingMessage message = new OutgoingMessage())
            {
                message.WriteString($"map: x:{mapShape.x}, y:{mapShape.y}");
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

        public void SendActiveActions()
        {
            using (OutgoingMessage message = new OutgoingMessage())
            {
                message.WriteString($"action: {string.Join(", ", _actions)}");
                QueueMessageToSend(message);
            }
        }
    }
}