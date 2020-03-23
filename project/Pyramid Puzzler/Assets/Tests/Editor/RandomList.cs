using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RandomList
    {
        // A Test behaves as an ordinary method
        public static List<int> toRandom = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        [Test]
        public void RandomListPasses()
        {
            QuestionCanvas test = new QuestionCanvas();
            List<int> random = QuestionCanvas.Shuffle(toRandom);
            for (int i = 0; i < 5; i++)
            {
                if (random != toRandom)
                    break;
            }
            Assert.AreNotEqual(toRandom, random);

        }
    }
}
