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
        private readonly MapEntry[,] _map;

        /// <summary>
        /// Constructs a cartographer for a given width and height
        /// </summary>
        /// <param name="width">Width of the map.</param>
        /// <param name="height">Height of the map.</param>
        public Cartographer(int width, int height)
        {
            _map = new MapEntry[width, height];
        }
        
        /// <summary>
        /// The matrix as list of information of the objects.
        /// </summary>
        private List<MapEntry> Matrix
        {
            get
            {
                FillStaticMap();
                List<MapEntry> matrix = new List<MapEntry>();

                for (int y = 0; y < _map.GetLength(0); y++)
                {
                    for (int x = 0; x < _map.GetLength(1); x++)
                    {
                        matrix.Add(_map[x, y]);
                    }
                }

                return matrix;
            }
        }

        /// <summary>
        /// Converts the matrix to a array which is readable by neuronal networks.
        /// </summary>
        /// <returns>float matrix [x,y, information]</returns>
        private float[,] MatrixNnReady()
        {
            int infoDimension = 0;

            foreach (MapEntry entry in Matrix.Where(entry => entry.Dimension() > infoDimension))
            {
                infoDimension = entry.Dimension();
            }

            float[, ] matrix = new float[Matrix.Count, infoDimension];
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < infoDimension; j++)
                {
                    matrix[i, j] = Matrix[i].Attributes[j];

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
                Vector3 position = gameObject.Position;
                //TODO: Take extent of the object into account
                int x = Convert.ToInt32(position.x);
                int y = Convert.ToInt32(position.y);

                _map[x, y] = gameObject.MapEntry;
            }
        }
    }
}