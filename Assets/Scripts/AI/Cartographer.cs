using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AI
{
    public class Cartographer
    {
        private readonly List<AiWrapper> _gameObjects = new List<AiWrapper>();
        private readonly int _height;
        private readonly int _scale;
        private readonly int _teamId;
        private readonly int _width;

        /// <summary>
        /// Constructs a cartographer for a given width and height
        /// </summary>
        /// <param name="width">Width of the map.</param>
        /// <param name="height">Height of the map.</param>
        /// <param name="teamId">The id of the character's team.</param>
        /// <param name="scale">Factor for details on the map. A larger values increases resolution.</param>
        public Cartographer(int width, int height, int teamId, int scale = 1)
        {
            _width = width;
            _height = height;
            _teamId = teamId;
            _scale = scale;
        }

        public int Dimension => (_height * 2 + 1) * (_width * 2 + 1) * _scale;

        /// <summary>
        /// Converts the matrix to a array which is readable by neuronal networks.
        /// </summary>
        /// <returns>float matrix [x,y, information]</returns>
        public float[,] MatrixNnReady(Vector3 agentPosition, Vector3 agentForward, List<string> attributeKeys,
            int x = 0, int y = 0, int? radiusX = null,
            int? radiusY = null)
        {
            List<MapEntry> mapEntries = DrawMap(x, y, radiusX, radiusY, agentPosition, agentForward);
            int infoDimension = attributeKeys.Count;

            float[,] matrix = new float[mapEntries.Count, infoDimension];
            for (int i = 0; i < mapEntries.Count; i++)
            {
                List<float> attributes = mapEntries[i].Attributes(attributeKeys);
                for (int j = 0; j < infoDimension; j++)
                {
                    matrix[i, j] = attributes == null || attributes.Count <= j ? 0f : attributes[j];
                }
            }

            return matrix;
        }

        /// <summary>
        /// Creates a map of all static game objects in the scene.
        /// </summary>
        private List<MapEntry> DrawMap(int x, int y, int? radiusX, int? radiusY, Vector3 agentPosition,
            Vector3 agentForward)
        {
            Map map = new Map(_width, _height, _scale);
            _gameObjects.AddRange(Object.FindObjectsOfType<AiWrapper>().ToList());
            foreach (AiWrapper gameObject in _gameObjects)
            {
                SetEntryOnMap(gameObject, map, agentPosition, agentForward);
            }

            x = x * _scale + 1;
            y = y * _scale + 1;

            return map.ToList(x, y, radiusX, radiusY);
        }

        private void SetEntryOnMap(AiWrapper wrapper, Map map, Vector3 agentPosition, Vector3 agentForward)
        {
            Vector3 position = wrapper.Position;
            Vector3 size = wrapper.Size;
            Vector3 forward = agentForward;

            Vector3 direction = (agentPosition - position).normalized;

            if (!(Vector3.Dot(forward, direction) > 0.9f)) return;

            int lowerX = (int) (position.x - size.x / 2) * _scale;
            int upperX = (int) (position.x + size.x / 2) * _scale;
            int lowerY = (int) (position.z - size.z / 2) * _scale;
            int upperY = (int) (position.z + size.z / 2) * _scale;

            for (int i = lowerX; i <= upperX; i++)
            {
                for (int j = lowerY; j <= upperY; j++)
                {
                    //TODO: check for other objects on it.
                    map.SetEntry(i, j, wrapper.MapEntry(_teamId));
                }
            }

            Debug.DrawLine(agentPosition, position + direction * 10, Color.yellow, 1f);
        }
    }
}