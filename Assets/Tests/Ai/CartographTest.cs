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
        [UnityTest]
        public IEnumerator MapAiArenaTest()
        {
            SceneManager.LoadScene("TestScene 1");
            yield return null;
            Cartographer cartographer = new Cartographer(5, 5);
            float[,] matrixNnReady = cartographer.MatrixNnReady();

            Assert.AreEqual(121,matrixNnReady.GetLength(0));
            Assert.AreEqual(1,matrixNnReady.GetLength(1));
            
            IEnumerable<int> northWall = Enumerable.Range(0, 11);
            foreach (int i in northWall)
            {
                Assert.AreEqual(1f, matrixNnReady[i, 0], message: $"Not 1f at {i}");

            }

            IEnumerable<int> westWall = Enumerable.Range(0, 11).Select(x => x * 11);
            foreach (int i in westWall)
            {
                Assert.AreEqual(1f, matrixNnReady[i, 0], message: $"Not 1f at {i}");

            }

            IEnumerable<int> eastWall = Enumerable.Range(1, 11).Select(x => x * 11 - 1);
            foreach (int i in eastWall)
            {
                Assert.AreEqual(1f, matrixNnReady[i, 0], message: $"Not 1f at {i}");

            }

            IEnumerable<int> southWall = Enumerable.Range(110, 11);
            foreach (int i in southWall)
            {
                Assert.AreEqual(1f, matrixNnReady[i, 0], message: $"Not 1f at {i}");

            }
        }
    }
}    