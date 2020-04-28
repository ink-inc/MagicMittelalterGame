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
            
            Assert.AreEqual(1f, matrixNnReady[0,1]);
        }
    }
}