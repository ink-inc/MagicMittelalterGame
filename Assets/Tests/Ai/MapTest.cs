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
            Dictionary<string, float> dict = new Dictionary<string, float> {{"type", 1f}};
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
        
        [Test]
        public void SetEntryUpperRightCornerTest()
        {
            _map.SetEntry(Width, Height, _mapEntry);
            List<MapEntry> mapEntries = _map.ToList();
            Assert.AreEqual(_mapEntry, mapEntries[2*Width]);
        }
        
        [Test]
        public void SetEntryLowerLeftCornerTest()
        {
            _map.SetEntry(-Width, -Height, _mapEntry);
            List<MapEntry> mapEntries = _map.ToList();
            Assert.AreEqual(_mapEntry, mapEntries[mapEntries.Count-1-2*Width]);
        }
        
        [Test]
        public void SetEntryLowerRightCornerTest()
        {
            _map.SetEntry(Width, -Height, _mapEntry);
            List<MapEntry> mapEntries = _map.ToList();
            Assert.AreEqual(_mapEntry, mapEntries[mapEntries.Count-1]);
        }
        
        [Test]
        public void PartialMap()
        {
            List<MapEntry> mapEntries = _map.ToList(3, 3, 2,2);
            
            Assert.AreEqual(25, mapEntries.Count);
        }
        
        [Test]
        public void PartialIsMaxMap()
        {
            List<MapEntry> mapEntries = _map.ToList(0, 0, Width, Height);
            
            Assert.AreEqual((Width*2+1)*(Height*2+1), mapEntries.Count);
        }
        
        [Test]
        public void PartialWithOutOfBounceMap()
        {
            List<MapEntry> mapEntries = _map.ToList(3, 3, Width, Height);
            
            Assert.AreEqual((Width*2+1)*(Height*2+1), mapEntries.Count);
        }
    }
}