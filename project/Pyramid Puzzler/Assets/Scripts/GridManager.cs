using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public Vector2 input;
    private bool isMoving;
    public Vector3 endPos, curPos, movePos;
    private float t;
    public float walkSpeed = 3f;
    private GameObject question_tile, block_tile;
    private string[] map;
    private int curRow, curCol;
    private GameObject[,] tiles;
    // Start is called before the first frame update
    void Start() {
        map = System.IO.File.ReadAllLines("Assets/Scripts/MAP.txt");
        question_tile = (GameObject)Instantiate(Resources.Load("QUESTION_TILE"));
        block_tile = (GameObject)Instantiate(Resources.Load("BLOCK_TILE"));
        tiles = new GameObject[map.Length, map[0].Length];
        for(int i = 0 ; i < map.Length ; i++) {
            for(int j = 0 ; j < map[i].Length ; j++) {
                if(map[i][j] == '.') {
                    tiles[i, j] = spawnTile(i, j, 0);
                }
                if(map[i][j] == '#') {
                    tiles[i, j] = spawnTile(i, j, 1);
                }
            }
            Debug.Log("Row " + (i + 1) + map[i]);
        }
        findStartingPosition();
    }

    // Starting position in the game at the moment will
    // be the first '.' on the bottom row.
    private void findStartingPosition() {
        for(int i = 0 ; i < map[0].Length ; i++) {
            if(map[map.Length - 1][i] == '.') {
                curRow = map.Length - 1;
                curCol = i;
                curPos = new Vector3(i, 0, 0);
                endPos = new Vector3(i, 0, 0);
                movePos = new Vector3(i, 0, 0);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        showGrid();
        movement();
    }
    // Shows the current state of the grid on the screen
    private void showGrid() {
        for(int i = 0 ; i < map.Length ; i++) {
            for(int j = 0 ; j < map[i].Length ; j++) {
                // For this tile, subtract out the current position of the character
                tiles[map.Length - i - 1, map[i].Length - j - 1].transform.position = new Vector3(j, i, 0) - curPos;
            }
        }
    }

    bool inbounds(int row, int col) {
        return 0 <= row && row < map.Length && 0 <= col && col < map[0].Length;
    }

    //
    private void movement() {
        if(!isMoving) {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if(Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
                input.y = 0;
            } else {
                input.x = 0;
            }
            if(input != Vector2.zero) {
                input = new Vector2(System.Math.Sign(input.x), System.Math.Sign(input.y));
                // Negate the y value because going up in a 2d array subtracts from
                // the row, while in Unity, it increases
                int nextRow = (int) (curRow - input.y);
                int nextCol = (int) (curCol - input.x);
                if(inbounds(nextRow, nextCol) && map[nextRow][nextCol] == '.') {
                    StartCoroutine(Move());
                    curRow = nextRow;
                    curCol = nextCol;
                }
            }
        }
    }

    public IEnumerator Move() {
        isMoving = true;
        t = 0;
        endPos = new Vector3(curPos.x + System.Math.Sign(input.x), curPos.y + System.Math.Sign(input.y), curPos.z);
        while(t < 1f) {
            t += Time.deltaTime * walkSpeed;
            movePos = Vector3.Lerp(curPos, endPos, t);
            curPos = movePos;
            yield return null;
        }
        isMoving = false;
        yield return 0;
    }

    private GameObject spawnTile(int row, int col, int tileType) {
        if(tileType == 0) { // Question Tile
            GameObject tile = (GameObject)Instantiate(question_tile, transform);
            return tile;            
        } else if(tileType == 1) { // Block tile
            GameObject tile = (GameObject)Instantiate(block_tile, transform);
            return tile;
        }
        return null; // This should never happen
    }
}
