using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScoreTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ScoreTestSimplePasses()
        {
            ScoreManager test = new ScoreManager();

            test.ScoreUP("easy");
            Assert.AreEqual(test.score, 10);

            test.ScoreUP("medium");
            Assert.AreEqual(test.score, 30);

            test.ScoreUP("hard");
            Assert.AreEqual(test.score, 60);

        }
    }
}
