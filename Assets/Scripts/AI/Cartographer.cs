using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AI
{
    public class Cartographer
    {
        private readonly List<GameObject> _gameObjects = new List<GameObject>();
        private readonly List<float>[,] _map;

        /// <summary>
        /// Constructs a cartographer for a given width and height
        /// </summary>
        /// <param name="width">Width of the map.</param>
        /// <param name="height">Height of the map.</param>
        public Cartographer(int width, int height)
        {
            _map = new List<float>[width, height];
        }
        
        private List<List<float>> Matrix
        {
            get
            {
                FillStaticMap();
                List<List<float>> matrix = new List<List<float>>();

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
        /// <returns>Attributes as floats.</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static List<float> InformationOf(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}