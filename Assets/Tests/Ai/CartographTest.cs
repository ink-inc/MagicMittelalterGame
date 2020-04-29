using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AI;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.Ai
{
    public class CartographTest
    {
        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene("AiArena");
        }

        [TearDown]
        public void TearDown()
        {
            SceneManager.UnloadSceneAsync("AiArena");
        }
        
        [UnityTest]
        public IEnumerator MapAiArenaTest()
        {
            yield return null;
            Cartographer cartographer = new Cartographer(5, 5, 1);
            float[,] matrixNnReady = cartographer.MatrixNnReady(new List<string> {"team"});

            Assert.AreEqual(121,matrixNnReady.GetLength(0));
            Assert.AreEqual(1,matrixNnReady.GetLength(1));
            
            IEnumerable<int> northWall = Enumerable.Range(0, 11).ToList();
            IEnumerable<int> westWall = Enumerable.Range(0, 11).Select(x => x * 11).ToList();
            IEnumerable<int> eastWall = Enumerable.Range(1, 11).Select(x => x * 11 - 1).ToList();
            IEnumerable<int> southWall = Enumerable.Range(110, 11).ToList();

            IEnumerable<int> allWalls = northWall.Concat(eastWall).Concat(southWall).Concat(westWall).ToList();
            

            List<int> allFields = Enumerable.Range(0, matrixNnReady.GetLength(0)).ToList();
            IEnumerable<int> allWalkable = allFields.Where(x => allWalls.Contains(x) == false);
            
            foreach (int i in allWalls)
            {
                Assert.AreEqual(1f, matrixNnReady[i, 0], message: $"Not 1f at {i}");

            }
            
            foreach (int i in allWalkable)
            {
                Assert.AreEqual(0f, matrixNnReady[i, 0], message: $"Not 0f at {i}");

            }

            yield return null;
        }
        
        [UnityTest]
        public IEnumerator PartialMap()
        {
            yield return null;

            Cartographer cartographer = new Cartographer(5, 5, 1);
            float[,] matrixNnReady = cartographer.MatrixNnReady(new List<string>{"team"}, 3, 3, 2, 2);
            
            Assert.AreEqual(25,matrixNnReady.GetLength(0), message: $"Should be {25} but was {matrixNnReady.GetLength(0)}");
            Assert.AreEqual(1,matrixNnReady.GetLength(1));
        }
    }
}    