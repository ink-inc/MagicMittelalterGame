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
                    _map[i, j] =  new MapEntry(null);
                }
            }
        }

        public void SetEntry(int x, int y, MapEntry mapEntry)
        {
            _map[x + _halfX, y + _halfY] = mapEntry;
        }

        public List<MapEntry> ToList()
        {
            List<MapEntry> mapEntries = new List<MapEntry>();
            for (int j = _map.GetLength(1) - 1; j >= 0; j--)
            {
                for (int i = 0; i < _map.GetLength(0); i++)
                {
                    mapEntries.Add(_map[i,j]);
                }
            }

            return mapEntries;
        }
    }
}