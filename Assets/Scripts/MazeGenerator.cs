using UnityEngine;

namespace Maze
{
    public class MazeGenerator : MonoBehaviour
    {
        #region Variables
        // public variables
        [Range(10, 250)]
        public int rows, columns;
        public GameObject wall;

        // private variables
        private MazeCell[,] mazeCells;
        #endregion

        #region Start
        private void Start()
        {
            InitializeMaze();
            MazeAlgorithm mazeAlgorithm = new HuntAndKillMazeAlgorithm(mazeCells);
            mazeAlgorithm.CreateMaze();
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

                    mazeCells[r, c].ground = Instantiate(wall, new Vector3(r * 1, -(1 / 2f), c * 1), Quaternion.identity) as GameObject;
                    mazeCells[r, c].ground.transform.Rotate(Vector3.right, 90f);

                    if (c == 0)
                    {
                        mazeCells[r, c].leftWall = Instantiate(wall, new Vector3(r * 1, 0, (c * 1) - (1 / 2f)), Quaternion.identity) as GameObject;
                    }


                    mazeCells[r, c].rightWall = Instantiate(wall, new Vector3(r * 1, 0, (c * 1) + (1 / 2f)), Quaternion.identity) as GameObject;

                    if (r == 0)
                    {
                        mazeCells[r, c].topWall = Instantiate(wall, new Vector3((r * 1) - (1 / 2f), 0, c * 1), Quaternion.identity) as GameObject;
                        mazeCells[r, c].topWall.transform.Rotate(Vector3.up * 90f);
                    }

                    mazeCells[r, c].bottomWall = Instantiate(wall, new Vector3((r * 1) + (1 / 2f), 0, c * 1), Quaternion.identity) as GameObject;
                    mazeCells[r, c].bottomWall.transform.Rotate(Vector3.up * 90f);
                }
            }
        }
        #endregion
        private void DeleteMaze()
        {
            //Seek all object in game to destroy
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Wall");
            foreach (GameObject obj in allObjects)
            {
                Destroy(obj);
            }
        }
        public void GenerateNewMaze()
        {
            DeleteMaze();
            InitializeMaze();
            //Easy to implement new algorithms
            MazeAlgorithm mazeAlgorithm = new HuntAndKillMazeAlgorithm(mazeCells);
            mazeAlgorithm.CreateMaze();
        }
    }
}