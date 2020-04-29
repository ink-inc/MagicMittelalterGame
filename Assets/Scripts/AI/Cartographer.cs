using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AI
{
    public class Cartographer
    {
        private readonly int _teamId;
        private readonly List<AiWrapper> _gameObjects = new List<AiWrapper>();
        private readonly Map _map;

        /// <summary>
        /// Constructs a cartographer for a given width and height
        /// </summary>
        /// <param name="width">Width of the map.</param>
        /// <param name="height">Height of the map.</param>
        /// <param name="teamId">The id of the character's team.</param>
        public Cartographer(int width, int height, int teamId)
        {
            _teamId = teamId;
            _map = new Map(width, height);
        }

        /// <summary>
        /// Converts the matrix to a array which is readable by neuronal networks.
        /// </summary>
        /// <returns>float matrix [x,y, information]</returns>
        public float[,] MatrixNnReady(List<string> attributeKeys)
        {

            DrawMap();
            List<MapEntry> mapEntries = _map.ToList();
            int infoDimension = attributeKeys.Count;
            

            float[, ] matrix = new float[mapEntries.Count, infoDimension];
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
        private void DrawMap()
        {
            _gameObjects.AddRange(Object.FindObjectsOfType<AiWrapper>().ToList());
            foreach (AiWrapper gameObject in _gameObjects)
            {
                SetEntryOnMap(gameObject);
            }
        }

        private void SetEntryOnMap(AiWrapper wrapper)
        {
            Vector3 position = wrapper.Position;
            Vector3 size = wrapper.Size;

            IEnumerable<int> xRange = Enumerable.Range(-(int)(size.x / 2), (int) size.x).ToList();
            IEnumerable<int> zRange = Enumerable.Range(-(int)(size.z / 2), (int) size.z).ToList();

            foreach (int sizeX in xRange)
            {
                foreach (int sizeY in zRange)
                {
                    int x = Convert.ToInt32(position.x + sizeX);
                    int y= Convert.ToInt32(position.z + sizeY);

                    //TODO: check for other objects on it.
                    _map.SetEntry(x, y, wrapper.MapEntry(_teamId));
                }
            }
            
            
        }
    }
}