using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTests
{
    [Test]
    public void RestrictInputTests() {
        PlayerMovement tester = new PlayerMovement();
        float lowerBound = -10f;
        float upperBound = +10f;
        for(int i = 0 ; i < 25 ; i++) {
            float x = Random.Range(lowerBound, upperBound);
            float y = Random.Range(lowerBound, upperBound);
            Vector2 input = new Vector2(x, y);
            input = tester.restrictInput(input);

            Vector2 correct_input = new Vector2(x, y);
            if(Mathf.Abs(correct_input.x) > Mathf.Abs(correct_input.y)) {
                correct_input.y = 0;
            } else {
                correct_input.x = 0;
            }
            correct_input.x = System.Math.Sign(correct_input.x);
            correct_input.y = System.Math.Sign(correct_input.y);
            Assert.AreEqual(input, correct_input);
        }
    }

    [Test]
    public void validateMovementTestInboundsChecker() {
        PlayerMovement tester = new PlayerMovement();
        // Since this test calls for a map to be used. We will test it using TESTMAP3
        string[] map = System.IO.File.ReadAllLines("Assets/Tests/Editor/Test Maps/TESTMAP3.txt");

        const int further = 10;

        for(int i = 0 - further ; i < map.Length + further ; i++) {
            for(int j = 0 - further ; j < map[0].Length + further ; j++) {

                System.Tuple<int, int> position = new System.Tuple<int, int>(i, j);
                bool answer = tester.inbounds(position.Item1, position.Item2, map.Length, map[0].Length);

                bool correct_answer = false;
                if(0 <= i && i < map.Length && 0 <= j && j < map[0].Length)
                    correct_answer = true;
                
                Assert.AreEqual(answer, correct_answer);
            }
        }
    }

    [Test]
    public void validateMovementTestBlockTileChecker() {
        PlayerMovement tester = new PlayerMovement();
        // Since this test calls for a map to be used. We will test it using TESTMAP3
        string[] map = System.IO.File.ReadAllLines("Assets/Tests/Editor/Test Maps/TESTMAP3.txt");

        // Tests all tile positions on the test map
        for(int i = 0 ; i < map.Length ; i++) {
            for(int j = 0 ; j < map[0].Length ; j++) {

                bool answer = tester.isBlockingTile(i, j, map);
                bool correct_answer = false;
                if(map[i][j] == '#')
                    correct_answer = true;
                
                Assert.AreEqual(answer, correct_answer);
            }
        }
    }

    [Test]
    public void updatePositionTest() {
        PlayerMovement tester = new PlayerMovement();
        // There are only 4 possible input vectors that can be given in this function,
        // so just manually try all 4.
        Vector2 input;
        System.Tuple<int, int> position, correct_position;

        // Testing (1, 0)
        input = new Vector2(1, 0);
        position = new System.Tuple<int, int>(3, 4);
        position = tester.updatePosition(position, input);

        correct_position = new System.Tuple<int, int>(3, 3);
        
        Assert.AreEqual(position, correct_position);

        // Testing (-1, 0)
        input = new Vector2(-1, 0);
        position = new System.Tuple<int, int>(10, 5);
        position = tester.updatePosition(position, input);

        correct_position = new System.Tuple<int, int>(10, 6);
        
        Assert.AreEqual(position, correct_position);

        // Testing (0, 1)
        input = new Vector2(0, 1);
        position = new System.Tuple<int, int>(2, 9);
        position = tester.updatePosition(position, input);

        correct_position = new System.Tuple<int, int>(1, 9);
        
        Assert.AreEqual(position, correct_position);

        // Testing (0, -1)
        input = new Vector2(0, -1);
        position = new System.Tuple<int, int>(9, 16);
        position = tester.updatePosition(position, input);

        correct_position = new System.Tuple<int, int>(10, 16);
        
        Assert.AreEqual(position, correct_position);
    }
}
