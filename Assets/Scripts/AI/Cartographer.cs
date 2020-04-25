using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AI
{
    public class Cartographer
    {
        private readonly List<GameObject> _gameObjects = new List<GameObject>();
        private readonly int[,] _map;

        /// <summary>
        /// Constructs a cartographer for a given width and height
        /// </summary>
        /// <param name="width">Width of the map.</param>
        /// <param name="height">Height of the map.</param>
        public Cartographer(int width, int height)
        {
            _map = new int[width, height];
        }

        /// <summary>
        /// Creates a map of all static game objects in the scene.
        /// </summary>
        public void FillStaticMap()
        {
            _gameObjects.AddRange(GameObject.FindGameObjectsWithTag("Interactable").ToList());
            foreach (GameObject gameObject in _gameObjects)
            {
                Vector3 position = gameObject.transform.position;
                int x = Convert.ToInt32(position.x);
                int y = Convert.ToInt32(position.y);

                _map[x, y] = NumberOf(gameObject);
            }
        }

        /// <summary>
        /// Calculates the type number of the game object.
        /// </summary>
        /// <param name="gameObject">Game object for which a type number should be found.</param>
        /// <returns>The type number.</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static int NumberOf(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}