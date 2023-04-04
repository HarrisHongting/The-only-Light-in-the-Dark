using UnityEngine;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class MazeLoader : MonoBehaviour {
	public int mazeRows, mazeColumns;
	public GameObject wall;
	public GameObject floor;
	public float size = 5f;
	public GameObject OuterWalls;
	public GameObject portal;
	public GameObject trap;

	
	public int trapsCount;
	//public GameObject Player;

	private MazeCell[,] mazeCells;

	// Use this for initialization
	void Start () {
		
		PlayerPrefs.SetString("LastScene", "Maze0");

		GenerateOuterWalls();
		
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		
		InitializeMaze ();
		//Instantiate(Player,new Vector3(1,1,1),Quaternion.identity);
		int randomX = Random.Range(Mathf.FloorToInt(mazeRows/2), mazeRows);
		int randomZ = Random.Range(Mathf.FloorToInt(mazeColumns/2), mazeColumns);
		Instantiate(portal,new Vector3(randomX * 5,-1.5f,randomZ * 5),Quaternion.identity);

		float trapSize = 1f;
		Vector3 trapOffset = new Vector3(trapSize * 0.5f, 0, trapSize * 0.5f); // 陷阱在中心的偏移量

		for (int i = 0; i < trapsCount; i++)
		{
			int x = Random.Range(4, mazeRows);
			int z = Random.Range(4, mazeColumns);
			Vector3 trapPosition = new Vector3(x * 5, -1.5f, z * 5) + trapOffset;
			
			Instantiate(trap, trapPosition, Quaternion.identity);
		}
		MazeAlgorithm ma = new HuntAndKillMazeAlgorithm (mazeCells);
		ma.CreateMaze ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void InitializeMaze() {
		
		mazeCells = new MazeCell[mazeRows,mazeColumns];

		for (int r = 0; r < mazeRows; r++) {
			for (int c = 0; c < mazeColumns; c++) {
				mazeCells [r, c] = new MazeCell ();

				// For now, use the same wall object for the floor!
				mazeCells [r, c] .floor = Instantiate (floor, new Vector3 (r*size, -(size/2f), c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c] .floor.name = "Floor " + r + "," + c;
				mazeCells [r, c] .floor.transform.Rotate (Vector3.right, 90f);

				if (c == 0) {
					mazeCells[r,c].westWall = Instantiate (wall, new Vector3 (r*size, 0, (c*size) - (size/2f)), Quaternion.identity) as GameObject;
					mazeCells [r, c].westWall.name = "West Wall " + r + "," + c;
				}

				mazeCells [r, c].eastWall = Instantiate (wall, new Vector3 (r*size, 0, (c*size) + (size/2f)), Quaternion.identity) as GameObject;
				mazeCells [r, c].eastWall.name = "East Wall " + r + "," + c;

				if (r == 0) {
					mazeCells [r, c].northWall = Instantiate (wall, new Vector3 ((r*size) - (size/2f), 0, c*size), Quaternion.identity) as GameObject;
					mazeCells [r, c].northWall.name = "North Wall " + r + "," + c;
					mazeCells [r, c].northWall.transform.Rotate (Vector3.up * 90f);
				}

				mazeCells[r,c].southWall = Instantiate (wall, new Vector3 ((r*size) + (size/2f), 0, c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c].southWall.name = "South Wall " + r + "," + c;
				mazeCells [r, c].southWall.transform.Rotate (Vector3.up * 90f);
			}
		}
	}
	void GenerateOuterWalls()
	{
		float xPosition, zPosition; // 墙体位置
		Vector3 position; // 墙体位置向量

		// 生成左右两侧的墙体
		for (int i = 0; i < mazeColumns; i++) 
		{
			// 左侧墙体
			xPosition = (-size / 2) -0.1f;
			zPosition = i * size;
			position = new Vector3(xPosition, 0, zPosition);
			Instantiate(OuterWalls, position, Quaternion.Euler(0,90,0));

			// 右侧墙体
			xPosition = mazeRows * size - (size / 2) + 0.1f;
			zPosition =  i * size;
			position = new Vector3(xPosition, 0, zPosition);
			Instantiate(OuterWalls, position, Quaternion.Euler(0,90,0));
		}

		// 生成上下两侧的墙体
		for (int i = 0; i < mazeRows; i++) 
		{
			// 上侧墙体
			xPosition = i * size;
			zPosition = mazeColumns * size - (size / 2) + 0.1f;
			position = new Vector3(xPosition, 0, zPosition);
			Instantiate(OuterWalls, position, Quaternion.identity);

			// 下侧墙体
			xPosition = i * size;
			zPosition = (-size / 2) - 0.1f;
			position = new Vector3(xPosition, 0, zPosition);
			Instantiate(OuterWalls, position, Quaternion.identity);
		}
	}
}
