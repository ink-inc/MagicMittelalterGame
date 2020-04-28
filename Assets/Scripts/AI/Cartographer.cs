using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AI
{
    public class Cartographer
    {
        private readonly List<AiWrapper> _gameObjects = new List<AiWrapper>();
        private readonly Map _map;

        /// <summary>
        /// Constructs a cartographer for a given width and height
        /// </summary>
        /// <param name="width">Width of the map.</param>
        /// <param name="height">Height of the map.</param>
        public Cartographer(int width, int height)
        {
            _map = new Map(width, height);
            FillStaticMap();
        }

        /// <summary>
        /// Converts the matrix to a array which is readable by neuronal networks.
        /// </summary>
        /// <returns>float matrix [x,y, information]</returns>
        public float[,] MatrixNnReady()
        {
            int infoDimension = 0;

            List<MapEntry> mapEntries = _map.ToList();
            foreach (MapEntry entry in mapEntries.Where(entry => entry.Dimension() > infoDimension))
            {
                infoDimension = entry.Dimension();
            }

            float[, ] matrix = new float[mapEntries.Count, infoDimension];
            for (int i = 0; i < mapEntries.Count; i++)
            {
                List<float> attributes = mapEntries[i].Attributes;
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
        private void FillStaticMap()
        {
            _gameObjects.AddRange(collection: Object.FindObjectsOfType<MonoBehaviour>().OfType<AiWrapper>().ToList());
            foreach (AiWrapper gameObject in _gameObjects)
            {
                SetEntryOnMap(gameObject);
            }
        }

        private void SetEntryOnMap(AiWrapper gameObject)
        {
            Vector3 position = gameObject.Position;
            Vector3 size = gameObject.Size;

            IEnumerable<int> xRange = Enumerable.Range(-(int)(size.x / 2), (int) size.x).ToList();
            IEnumerable<int> zRange = Enumerable.Range(-(int)(size.z / 2), (int) size.z).ToList();

            foreach (int sizeX in xRange)
            {
                foreach (int sizeY in zRange)
                {
                    int x = Convert.ToInt32(position.x + sizeX);
                    int y= Convert.ToInt32(position.z + sizeY);

                    //TODO: check for other objects on it.
                    _map.SetEntry(x, y, gameObject.MapEntry);
                }
            }
            
            
        }
    }
}