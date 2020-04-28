using System.Collections;
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
            // NorthWall
            Assert.AreEqual(1f, matrixNnReady[0, 0]);
            Assert.AreEqual(1f, matrixNnReady[1, 0]);
            Assert.AreEqual(1f, matrixNnReady[2, 0]);
            Assert.AreEqual(1f, matrixNnReady[3, 0]);
            Assert.AreEqual(1f, matrixNnReady[4, 0]);
            Assert.AreEqual(1f, matrixNnReady[6, 0]);
            Assert.AreEqual(1f, matrixNnReady[7, 0]);
            Assert.AreEqual(1f, matrixNnReady[8, 0]);
            Assert.AreEqual(1f, matrixNnReady[9, 0]);
            Assert.AreEqual(1f, matrixNnReady[10, 0]);

            //WestWall
            Assert.AreEqual(1f, matrixNnReady[11, 0]);
            Assert.AreEqual(1f, matrixNnReady[22, 0]);
            Assert.AreEqual(1f, matrixNnReady[33, 0]);
            Assert.AreEqual(1f, matrixNnReady[44, 0]);
            Assert.AreEqual(1f, matrixNnReady[55, 0]);
            Assert.AreEqual(1f, matrixNnReady[66, 0]);
            Assert.AreEqual(1f, matrixNnReady[77, 0]);
            Assert.AreEqual(1f, matrixNnReady[88, 0]);
            Assert.AreEqual(1f, matrixNnReady[99, 0]);
            Assert.AreEqual(1f, matrixNnReady[110, 0]);
            
            //EastWall
            Assert.AreEqual(1f, matrixNnReady[21, 0]);
            Assert.AreEqual(1f, matrixNnReady[32, 0]);
            Assert.AreEqual(1f, matrixNnReady[43, 0]);
            Assert.AreEqual(1f, matrixNnReady[54, 0]);
            Assert.AreEqual(1f, matrixNnReady[65, 0]);
            Assert.AreEqual(1f, matrixNnReady[76, 0]);
            Assert.AreEqual(1f, matrixNnReady[87, 0]);
            Assert.AreEqual(1f, matrixNnReady[98, 0]);
            Assert.AreEqual(1f, matrixNnReady[109, 0]);
            Assert.AreEqual(1f, matrixNnReady[120, 0]);
            
            // SouthWall
            Assert.AreEqual(1f, matrixNnReady[111, 0]);
            Assert.AreEqual(1f, matrixNnReady[112, 0]);
            Assert.AreEqual(1f, matrixNnReady[113, 0]);
            Assert.AreEqual(1f, matrixNnReady[114, 0]);
            Assert.AreEqual(1f, matrixNnReady[116, 0]);
            Assert.AreEqual(1f, matrixNnReady[117, 0]);
            Assert.AreEqual(1f, matrixNnReady[118, 0]);
            Assert.AreEqual(1f, matrixNnReady[119, 0]);
        }
    }
}    