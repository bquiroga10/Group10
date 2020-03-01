using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MapTests
{
    [Test]
    public void findMapStartingPositionTest1() {
		// Use TESTMAP1 for this test
		string[] map = System.IO.File.ReadAllLines("Assets/Tests/Editor/Test Maps/TESTMAP1.txt");

		// Use the function to get the answer.
		Tuple<int, int> position = new Tuple<int, int>(-1, -1);
		Vector3 curPos = new Vector3(-1, -1, -1);
		Vector3 endPos = new Vector3(-1, -1, -1);
		Vector3 movePos = new Vector3(-1, -1, -1);
		PlayerMovement tester = new PlayerMovement();
		tester.findStartingPosition(ref position, ref curPos, ref endPos, ref movePos, map);

		// The hard-coded answer.
		Tuple<int, int> correct_position = new Tuple<int, int>(0, 0);
		Vector3 correct_curPos = new Vector3(0, 0, 0);
		Vector3 correct_endPos = new Vector3(0, 0, 0);
		Vector3 correct_movePos = new Vector3(0, 0, 0);

		Assert.AreEqual(position, correct_position);
		Assert.AreEqual(curPos, correct_curPos);
		Assert.AreEqual(endPos, correct_endPos);
		Assert.AreEqual(movePos, correct_movePos);
	}

	[Test]
	public void findMapStartingPositionTest2() {
		// Use TESTMAP2 for this test
		string[] map = System.IO.File.ReadAllLines("Assets/Tests/Editor/Test Maps/TESTMAP2.txt");

		// Use the function to get the answer.
		Tuple<int, int> position = new Tuple<int, int>(-1, -1);
		Vector3 curPos = new Vector3(-1, -1, -1);
		Vector3 endPos = new Vector3(-1, -1, -1);
		Vector3 movePos = new Vector3(-1, -1, -1);
		PlayerMovement tester = new PlayerMovement();
		tester.findStartingPosition(ref position, ref curPos, ref endPos, ref movePos, map);

		// The hard-coded answer.
		Tuple<int, int> correct_position = new Tuple<int, int>(3, 2);
		Vector3 correct_curPos = new Vector3(2, 0, 0);
		Vector3 correct_endPos = new Vector3(2, 0, 0);
		Vector3 correct_movePos = new Vector3(2, 0, 0);

		Assert.AreEqual(position, correct_position);
		Assert.AreEqual(curPos, correct_curPos);
		Assert.AreEqual(endPos, correct_endPos);
		Assert.AreEqual(movePos, correct_movePos);
	}

	[Test]
	public void findMapStartingPositionTest3() {
		// Use TESTMAP2 for this test
		string[] map = System.IO.File.ReadAllLines("Assets/Tests/Editor/Test Maps/TESTMAP3.txt");

		// Use the function to get the answer.
		Tuple<int, int> position = new Tuple<int, int>(-1, -1);
		Vector3 curPos = new Vector3(-1, -1, -1);
		Vector3 endPos = new Vector3(-1, -1, -1);
		Vector3 movePos = new Vector3(-1, -1, -1);
		PlayerMovement tester = new PlayerMovement();
		tester.findStartingPosition(ref position, ref curPos, ref endPos, ref movePos, map);

		// The hard-coded answer.
		Tuple<int, int> correct_position = new Tuple<int, int>(4, 5);
		Vector3 correct_curPos = new Vector3(5, 0, 0);
		Vector3 correct_endPos = new Vector3(5, 0, 0);
		Vector3 correct_movePos = new Vector3(5, 0, 0);

		Assert.AreEqual(position, correct_position);
		Assert.AreEqual(curPos, correct_curPos);
		Assert.AreEqual(endPos, correct_endPos);
		Assert.AreEqual(movePos, correct_movePos);
	}

}
