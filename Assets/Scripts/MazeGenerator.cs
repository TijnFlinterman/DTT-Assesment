using UnityEngine;
using System.Collections.Generic;

namespace Maze
{
    public class MazeGenerator : MonoBehaviour
    {
        #region variables
        // public variables
        [Range(10, 250)]
        public int rows, columns;
        public GameObject wall;
        public float scale = 1f;

        // private variables
        private MazeCell[,] mazeCells;
        #endregion

        #region Start
        private void Start()
        {
            InitializeMaze();
        }
        #endregion

        #region InitializeMaze
        private void InitializeMaze()
        {
            mazeCells = new MazeCell[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    mazeCells[r, c] = new MazeCell();

                    mazeCells[r, c].ground = Instantiate(wall, new Vector3(r * scale, -(scale / 2f), c * scale), Quaternion.identity) as GameObject;
                    mazeCells[r, c].ground.transform.Rotate(Vector3.right, 90f);

                    if (c == 0)
                    {
                        mazeCells[r, c].leftWall = Instantiate(wall, new Vector3(r * scale, 0, (c * scale) - (scale / 2f)), Quaternion.identity) as GameObject;
                    }


                    mazeCells[r, c].rightWall = Instantiate(wall, new Vector3(r * scale, 0, (c * scale) + (scale / 2f)), Quaternion.identity) as GameObject;

                    if (r == 0)
                    {
                        mazeCells[r, c].topWall = Instantiate(wall, new Vector3((r * scale) - (scale / 2f), 0, c * scale), Quaternion.identity) as GameObject;
                        mazeCells[r, c].topWall.transform.Rotate(Vector3.up * 90f);
                    }

                    mazeCells[r, c].bottomWall = Instantiate(wall, new Vector3((r * scale) + (scale / 2f), 0, c * scale), Quaternion.identity) as GameObject;
                    mazeCells[r, c].bottomWall.transform.Rotate(Vector3.up * 90f);
                }
            }
        }
        #endregion
        private void DeleteMaze()
        {
            for (int x = 0; x < mazeCells.GetLength(0); x++)
            {
                for (int y = 0; y < mazeCells.GetLength(1); y++)
                {
                    mazeCells[x, y].DestroyCell();
                }
            }
        }
        public void GenerateNewMaze()
        {
            DeleteMaze();
            InitializeMaze();
        }
    }
}