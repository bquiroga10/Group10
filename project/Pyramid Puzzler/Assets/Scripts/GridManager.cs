using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour {

    public Vector2 input;
    public Vector3 endPos, curPos, movePos;
    public float walkSpeed = 3f;
    public string[] map;

    public bool isMoving;
    private float t;
    private GameObject question_tile, block_tile, start_tile, end_tile, blank_tile, powerup_tile;

    // Much more convenient to store the current row and column as integers.
    private Tuple<int, int> position;
    private GameObject[,] tiles;
    public bool[,] hasQuestion;
    public static bool requestQuestion;
    private PlayerMovement helper;
    private int BLANK_ID = 11111111;
    private Dictionary<char, int> getID;
    private Dictionary<char, bool> getQuestionTiles;
    private char[] tilesChars = {'.', '#', 'S', 'E', 'P'};
    private bool[] questionTiles = {true, false, false, false, true};
    private static bool powerupReady;
    // Start is called before the first frame update
    void Start() {

        helper = new PlayerMovement();

        // Load in the testing map
        map = System.IO.File.ReadAllLines("Assets/Resources/MAP.txt");

        // Load in sprites
        question_tile = (GameObject)Instantiate(Resources.Load("QUESTION_TILE"));
        block_tile = (GameObject)Instantiate(Resources.Load("BLOCK_TILE"));
        start_tile = (GameObject)Instantiate(Resources.Load("START_TILE"));
        end_tile = (GameObject)Instantiate(Resources.Load("END_TILE"));
        blank_tile = (GameObject)Instantiate(Resources.Load("BLANK_TILE"));
        powerup_tile = (GameObject)Instantiate(Resources.Load("POWERUP_TILE"));

        hasQuestion = new bool[map.Length, map[0].Length];

        getID = new Dictionary<char, int>();
        getQuestionTiles = new Dictionary<char, bool>();
        for(int i = 0 ; i < tilesChars.Length ; i++) {
            getID.Add(tilesChars[i], i);
            getQuestionTiles.Add(tilesChars[i], questionTiles[i]);
        }

        // This will hold the sprite information for each tile of the map.
        tiles = new GameObject[map.Length, map[0].Length];

        for(int i = 0 ; i < map.Length ; i++) {
            for(int j = 0 ; j < map[i].Length ; j++) {
                tiles[i, j] = (GameObject)Instantiate(block_tile, transform);
                setSprite(i, j, getID[map[i][j]]);
                hasQuestion[i, j] = getQuestionTiles[map[i][j]];
            }
        }
        position = new Tuple<int, int>(0, 0);
        curPos = new Vector3(0, 0, 0);
        movePos = new Vector3(0, 0, 0);
        endPos = new Vector3(0, 0, 0);
        // Find the starting position of the player.
        helper.findStartingPosition(ref position, ref curPos, ref endPos, ref movePos, map);
        requestQuestion = false;

        powerupReady = false;
    }

    // Update is called once per frame
    void Update() {
        showGrid();
        movement();
        if(!isMoving && helper.isEndingPosition(position, map)) SceneManager.LoadScene("Victory");

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
        if(requestQuestion || QuizOpen.busy) return;
        if(!isMoving) {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            input = helper.restrictInput(input);
            // Check to see if the player is attempting to move.
            if(input != Vector2.zero) {
                Tuple<int, int> nextPosition = helper.updatePosition(position, input);

                // Validate that the next position is an okay position to move onto.
                if(helper.validateMovement(nextPosition, map)) {
                    // ensures that the player does not apply another movement while this is occuring.
                    isMoving = true;
                    // Start a coroutine that applys the movement onto the current position of the player smoothly.
                    StartCoroutine(Move());
                    position = nextPosition;
                }
            }
        }
    }

    // Movement Routine that smoothly moves player.
    public IEnumerator Move() {

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
            if(map[position.Item1][position.Item2] == 'P') {
                powerupReady = true;
            }
            hasQuestion[position.Item1, position.Item2] = false;
            setSprite(position.Item1, position.Item2, BLANK_ID);
        }


        // Once this animation is over, the player is free to apply another movement.
        isMoving = false;
        yield return 0;
    }

    private void setSprite(int row, int col, int tileType) {
        if(tileType == 0) { // Question Tile
            tiles[row, col].GetComponent<SpriteRenderer>().sprite = question_tile.GetComponent<SpriteRenderer>().sprite;
        } else if(tileType == 1) { // Block Tile
            tiles[row, col].GetComponent<SpriteRenderer>().sprite = block_tile.GetComponent<SpriteRenderer>().sprite;
        } else if(tileType == 2) { // Start Tile
            tiles[row, col].GetComponent<SpriteRenderer>().sprite = start_tile.GetComponent<SpriteRenderer>().sprite;
        } else if(tileType == 3) { // End Tile
            tiles[row, col].GetComponent<SpriteRenderer>().sprite = end_tile.GetComponent<SpriteRenderer>().sprite;
        } else if(tileType == 4) { // Powerup Tile
            tiles[row, col].GetComponent<SpriteRenderer>().sprite = powerup_tile.GetComponent<SpriteRenderer>().sprite;
        } else if(tileType == BLANK_ID) { // Blank Tile
            tiles[row, col].GetComponent<SpriteRenderer>().sprite = blank_tile.GetComponent<SpriteRenderer>().sprite;
        }
    }

    public static bool isPowerupTile() {
        if(powerupReady) {
            powerupReady = false;
            return true;
        }
        return false;
    }
    
}
