using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    // Takes the current position of the player and applies the input movement vector to it.
    // We subtract y from row and x from column because row and column are from an array
    // perspective while the input x and y are from a cartesian coordinate perspective.
    public Tuple<int, int> updatePosition(Tuple<int, int> position, Vector2 input) {
        return new Tuple<int, int>((int) (position.Item1 - input.y), (int) (position.Item2 - input.x));
    }

    // Checks if the current row and column is within the boundaries.
    public bool inbounds(int row, int col, int maxRow, int maxCol) {
        return 0 <= row && row < maxRow && 0 <= col && col < maxCol;
    }


    // Checks if the tile the player wants to move onto is a valid location.
    // A valid location is defined to be a tile that is:
    //  - A tile that is within the map boundaries.
    //  - Not a block tile.
    // ***This may be subject to change, but as of right now, these are the only restrictions.
    public bool validateMovement(Tuple<int, int> position, string[] map) {
        if(!inbounds(position.Item1, position.Item2, map.Length, map[0].Length)) return false;
        if(map[position.Item1][position.Item2] == '#') return false;
        return true;
    }

    // Here are the restrictions for player movement:
    //  - The player can only move in 1 direction, so to handle this, one of
    //    the input directions is zeroed out completely
    //  - The way movement is used only allows for +1, 0, or -1, so to handle this,
    //    the signs of the input directions are used instead (using System.Math.Sign()).
    //    System.Math.Sign() returns 0 for 0, so it works perfectly as needed.
    public Vector2 restrictInput(Vector2 input) {
        if(Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
            input.y = 0;
        } else {
            input.x = 0;
        }
        return new Vector2(System.Math.Sign(input.x), System.Math.Sign(input.y));
    }

    // Starting position in the game at the moment will
    // be the first '.' on the bottom row.
    public void findStartingPosition(ref Tuple<int, int> position, ref Vector3 curPos, ref Vector3 endPos, ref Vector3 movePos, string[] map) {
        for(int i = 0 ; i < map[0].Length ; i++) {
            if(map[map.Length - 1][i] == '.') {
                position = new Tuple<int, int>(map.Length - 1, i);
                curPos = new Vector3(i, 0, 0);
                endPos = new Vector3(i, 0, 0);
                movePos = new Vector3(i, 0, 0);
                break;
            }
        }
    }
}
