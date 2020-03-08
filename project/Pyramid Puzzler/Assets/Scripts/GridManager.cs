using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public Vector2 input;
    public Vector3 endPos, curPos, movePos;
    public float walkSpeed = 3f;
    public string[] map;

    public bool isMoving;
    private float t;
    private GameObject question_tile, block_tile, start_tile, end_tile;

    // Much more convenient to store the current row and column as integers.
    private Tuple<int, int> position;
    private GameObject[,] tiles;
    public bool [,] hasQuestion;
    public static bool requestQuestion;

    private PlayerMovement helper;
    // Start is called before the first frame update
    void Start() {

        helper = new PlayerMovement();

        // Load in the testing map
        map = System.IO.File.ReadAllLines("Assets/Scripts/MAP.txt");

        // Load in sprites
        question_tile = (GameObject)Instantiate(Resources.Load("QUESTION_TILE"));
        block_tile = (GameObject)Instantiate(Resources.Load("BLOCK_TILE"));
        start_tile = (GameObject)Instantiate(Resources.Load("START_TILE"));
        end_tile = (GameObject)Instantiate(Resources.Load("END_TILE"));

        hasQuestion = new bool[map.Length, map[0].Length];

        // This will hold the sprite information for each tile of the map.
        tiles = new GameObject[map.Length, map[0].Length];

        for(int i = 0 ; i < map.Length ; i++) {
            for(int j = 0 ; j < map[i].Length ; j++) {
                // As of right now, tiles that the player can move on are represented as '.'
                // If this tile is '.', spawn the tile in using the question
                if(map[i][j] == '.') {
                    tiles[i, j] = spawnTile(i, j, 0);
                    hasQuestion[i, j] = true;
                }
                if(map[i][j] == '#') {
                    tiles[i, j] = spawnTile(i, j, 1);
                }
                if(map[i][j] == 'S') {
                    tiles[i, j] = spawnTile(i, j, 2);
                }
                if(map[i][j] == 'E') {
                    tiles[i, j] = spawnTile(i, j, 3);
                }
            }
        }
        position = new Tuple<int, int>(0, 0);
        curPos = new Vector3(0, 0, 0);
        movePos = new Vector3(0, 0, 0);
        endPos = new Vector3(0, 0, 0);
        // Find the starting position of the player.
        helper.findStartingPosition(ref position, ref curPos, ref endPos, ref movePos, map);
        requestQuestion = false;
    }

    // Update is called once per frame
    void Update() {
        
        showGrid();
        if(!requestQuestion && !QuizOpen.busy) movement();
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


    // Handles the movement of the game.
    private void movement() {

        // Only check if the player is currently not moving.
        if(!isMoving) {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            input = helper.restrictInput(input);

            // Check to see if the player is attempting to move.
            if(input != Vector2.zero) {

                // Get what the next position should be when applied to our current position.
                Tuple<int, int> nextPosition = helper.updatePosition(position, input);

                // Validate that the next position is an okay position to move onto.
                if(helper.validateMovement(nextPosition, map)) {

                    // Start a coroutine that applys the movement onto the current position of the player smoothly.
                    StartCoroutine(Move());
                    position = nextPosition;
                }
            }
        }
    }

    // Movement Routine that smoothly moves player.
    public IEnumerator Move() {

        // ensures that the player does not apply another movement while this is occuring.
        isMoving = true;
        t = 0;
        // Get the position of where the player will end up.
        endPos = new Vector3(curPos.x + input.x, curPos.y + input.y, curPos.z);
        while(t < 1f) {
            t += Time.deltaTime * walkSpeed;
            movePos = Vector3.Lerp(curPos, endPos, t);
            curPos = movePos;
            yield return null;
        }

        // This here to ensure that accuracy is not lost when applying the movement.
        curPos = endPos;

        if(hasQuestion[position.Item1, position.Item2]) {
            requestQuestion = true;
            hasQuestion[position.Item1, position.Item2] = false;
        }

        // Once this animation is over, the player is free to apply another movement.
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
        } else if(tileType == 2) {
            GameObject tile = (GameObject)Instantiate(start_tile, transform);
            return tile;
        } else if(tileType == 3) {
            GameObject tile = (GameObject)Instantiate(end_tile, transform);
            return tile;
        }
        return null; // This should never happen
    }
}
