using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AI
{
    public class Cartographer
    {
        private readonly List<GameObject> _gameObjects = new List<GameObject>();
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
                    matrix[i, j] = Matrix[i].Attributes(j);

                }
            }

            return matrix;
        }

        /// <summary>
        /// Creates a map of all static game objects in the scene.
        /// </summary>
        private void FillStaticMap()
        {
            _gameObjects.AddRange(GameObject.FindGameObjectsWithTag("Interactable").ToList());
            foreach (GameObject gameObject in _gameObjects)
            {
                Vector3 position = gameObject.transform.position;
                int x = Convert.ToInt32(position.x);
                int y = Convert.ToInt32(position.y);

                _map[x, y] = InformationOf(gameObject);
            }
        }

        /// <summary>
        /// Retrieves the information of an object as a list of floats.
        /// </summary>
        /// <param name="gameObject">Game object for which the information should be found.</param>
        /// <returns>Attributes as floats wrapped in a map entry.</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static MapEntry InformationOf(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}