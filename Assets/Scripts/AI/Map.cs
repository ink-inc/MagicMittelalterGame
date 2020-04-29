using System;
using System.Collections.Generic;

namespace AI
{
    public class Map
    {
        private readonly MapEntry[,] _map;
        private readonly int _halfX;
        private readonly int _halfY;

        public Map(int width, int height)
        {
            _halfX = width;
            _halfY = height;
            int widthNorm = width * 2+1;
            int heightNorm = height * 2+1;
            _map = new MapEntry[widthNorm, heightNorm];
            for (int i = 0; i < heightNorm; i++)
            {
                for (int j = 0; j < widthNorm; j++)
                {
                    _map[i, j] =  new MapEntry(new Dictionary<string, float>());
                }
            }
        }

        public void SetEntry(int x, int y, MapEntry mapEntry)
        {
            _map[x + _halfX, y + _halfY] = mapEntry;
        }

        public List<MapEntry> ToList(int x=0, int y=0, int? radiusX = null, int? radiusY = null)
        {
            List<MapEntry> mapEntries = new List<MapEntry>();

            radiusX = radiusX.HasValue ? radiusX + 1 : (int) Math.Ceiling(_map.GetLength(0) / 2f);
            radiusY = radiusY.HasValue ? radiusY + 1 : (int) Math.Ceiling(_map.GetLength(1) / 2f);
            
            int minX = (int) (_map.GetLength(0)/2 + x -  radiusX + 1);
            int minY = (int) (_map.GetLength(1)/2 + y -  radiusY + 1);

            int maxX = (int) (_map.GetLength(0)/2 + x +  radiusX);
            int maxY = (int) (_map.GetLength(1)/2 + y + radiusX);

            for (int j = maxY - 1; j >= minY; j--)
            {
                for (int i = minX; i < maxX; i++)
                {
                    if (i < _map.GetLength(0) && j < _map.GetLength(1))
                    {
                        mapEntries.Add(_map[i, j]);
                    }
                    else
                    {
                        mapEntries.Add(new MapEntry(new Dictionary<string, float>()));
                    }
                }
            }

            return mapEntries;
        }
    }
}