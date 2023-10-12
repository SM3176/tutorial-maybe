using System;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject wp;
    public GameObject fp;
    private int[,] maze;

    void Start()
    {
        maze = new int[width, height];

        // Generate the maze
        GenerateMaze();

        // Create the maze game objects
        CreateMazeGameObjects();
    }

    private void GenerateMaze()
    {
        // Initialize the maze
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                maze[i, j] = 1;
            }
        }

        // Create a stack to store the cells that need to be visited
        Stack<Vector2Int> stack = new Stack<Vector2Int>();

        // Start at the top-left corner of the maze
        stack.Push(new Vector2Int(0, 0));

        while (stack.Count > 0)
        {
            // Get the current cell
            Vector2Int currentCell = stack.Pop();

            // If the current cell is a wall, set it to an empty space
            if (maze[currentCell.x, currentCell.y] == 1)
            {
                maze[currentCell.x, currentCell.y] = 0;
            }

            // Get the adjacent cells
            List<Vector2Int> adjacentCells = new List<Vector2Int>();
            adjacentCells.Add(new Vector2Int(currentCell.x - 1, currentCell.y));
            adjacentCells.Add(new Vector2Int(currentCell.x + 1, currentCell.y));
            adjacentCells.Add(new Vector2Int(currentCell.x, currentCell.y - 1));
            adjacentCells.Add(new Vector2Int(currentCell.x, currentCell.y + 1));

            // Shuffle the adjacent cells
            Shuffle(adjacentCells);

            // Add the unvisited adjacent cells to the stack
            foreach (Vector2Int adjacentCell in adjacentCells)
            {
                if (0 <= adjacentCell.x && adjacentCell.x < width && 0 <= adjacentCell.y && adjacentCell.y < height)
                {
                    if (maze[adjacentCell.x, adjacentCell.y] == 1)
                    {
                        stack.Push(adjacentCell);
                    }
                }

            }
        }
    }

    private void Shuffle(List<Vector2Int> list)
    {
        // Create a new list to store the shuffled cells
        List<Vector2Int> shuffledCells = new List<Vector2Int>();

        // Iterate over the original list and add the cells to the shuffled list in a random order
        foreach (Vector2Int cell in list)
        {
            int randomIndex = UnityEngine.Random.Range(0, shuffledCells.Count);
            shuffledCells.Insert(randomIndex, cell);
        }

        // Replace the original list with the shuffled list
        list = shuffledCells;
    }

    private void CreateMazeGameObjects()
    {


        // Iterate over the maze and create game objects for each cell
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                // If the cell is a wall, create a wall game object
                if (maze[i, j] == 1)
                {
                    Instantiate(wp, new Vector3(i, 2, j), Quaternion.identity);
                }
                else
                {
                    // If the cell is an empty space, create a floor game object
                    Instantiate(fp, new Vector3(i, 0, j), Quaternion.identity);
                }
            }
        }
    }
}
