using System.Collections.Generic;
using AI;
using NUnit.Framework;

namespace Tests.Ai
{
    public class MapTest
    {
        private const int Width = 10;
        private const int Height = 10;
        private Map _map;
        private MapEntry _mapEntry;

        [SetUp]
        public void SetUp()
        {
            _map = new Map(Width, Height);
            SortedDictionary<string, float> dict = new SortedDictionary<string, float> {{"type", 1f}};
            _mapEntry = new MapEntry(dict);
        }
        [Test]
        public void MapTestConstructor()
        {
            List<MapEntry> mapEntries = _map.ToList();
            Assert.AreEqual(((Width*2+1)*(Height*2+1)), mapEntries.Count);
        }

        [Test]
        public void SetEntryTest()
        {
            
            _map.SetEntry(0, 0, _mapEntry);
            List<MapEntry> mapEntries = _map.ToList();
            Assert.AreEqual(_mapEntry, mapEntries[Width+(Height*(Width*2+1))]);
        }
        
    }
}