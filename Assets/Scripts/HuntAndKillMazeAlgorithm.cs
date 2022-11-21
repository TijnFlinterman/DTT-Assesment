using UnityEngine;

namespace Maze
{
    public class HuntAndKillMazeAlgorithm : MazeAlgorithm
    {
        #region Variables
        // private variables
        private int currentRow = 0;
        private int currentColumn = 0;
        private bool courseComplete = false;
        #endregion

        public HuntAndKillMazeAlgorithm(MazeCell[,] mazeCells) : base(mazeCells)
        {
        }

        #region MazeCreation
        public override void CreateMaze()
        {
            HuntAndKill();
        }

        private void HuntAndKill()
        {
            mazeCells[currentRow, currentColumn].visited = true;

            while (!courseComplete)
            {
                Kill();
                Hunt();
            }
        }
        #endregion

        #region Hunt&Kill

        private void Hunt()
        {
            courseComplete = true;

            for (int r = 0; r < mazeRows; r++)
            {
                for (int c = 0; c < mazeColumns; c++)
                {
                    if (!mazeCells[r, c].visited && CellHasAnAdjacentVisitedCell(r, c))
                    {
                        courseComplete = false;
                        currentRow = r;
                        currentColumn = c;
                        DestroyAdjacentWall(currentRow, currentColumn);
                        mazeCells[currentRow, currentColumn].visited = true;
                        return;
                    }
                }
            }
        }
        private void Kill()
        {
            while (RouteStillAvailable(currentRow, currentColumn))
            {
                int direction = ProceduralNumberGenerator.GetNextNumber();

                if (direction == 1 && CellIsAvailable(currentRow - 1, currentColumn))
                {
                    DestroyWallIfItExists(mazeCells[currentRow, currentColumn].topWall);
                    DestroyWallIfItExists(mazeCells[currentRow - 1, currentColumn].bottomWall);
                    currentRow--;
                }
                else if (direction == 2 && CellIsAvailable(currentRow + 1, currentColumn))
                {
                    DestroyWallIfItExists(mazeCells[currentRow, currentColumn].bottomWall);
                    DestroyWallIfItExists(mazeCells[currentRow + 1, currentColumn].topWall);
                    currentRow++;
                }
                else if (direction == 3 && CellIsAvailable(currentRow, currentColumn + 1))
                {
                    DestroyWallIfItExists(mazeCells[currentRow, currentColumn].rightWall);
                    DestroyWallIfItExists(mazeCells[currentRow, currentColumn + 1].leftWall);
                    currentColumn++;
                }
                else if (direction == 4 && CellIsAvailable(currentRow, currentColumn - 1))
                {
                    DestroyWallIfItExists(mazeCells[currentRow, currentColumn].leftWall);
                    DestroyWallIfItExists(mazeCells[currentRow, currentColumn - 1].rightWall);
                    currentColumn--;
                }

                mazeCells[currentRow, currentColumn].visited = true;
            }
        }
        #endregion

        #region AvailabilityCheck

        private bool RouteStillAvailable(int row, int column)
        {
            int availableRoutes = 0;

            if (row > 0 && !mazeCells[row - 1, column].visited)
            {
                availableRoutes++;
            }

            if (row < mazeRows - 1 && !mazeCells[row + 1, column].visited)
            {
                availableRoutes++;
            }

            if (column > 0 && !mazeCells[row, column - 1].visited)
            {
                availableRoutes++;
            }

            if (column < mazeColumns - 1 && !mazeCells[row, column + 1].visited)
            {
                availableRoutes++;
            }

            return availableRoutes > 0;
        }

        private bool CellIsAvailable(int row, int column)
        {
            if (row >= 0 && row < mazeRows && column >= 0 && column < mazeColumns && !mazeCells[row, column].visited)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool CellHasAnAdjacentVisitedCell(int row, int column)
        {
            int visitedCells = 0;

            if (row > 0 && mazeCells[row - 1, column].visited)
            {
                visitedCells++;
            }

            if (row < (mazeRows - 2) && mazeCells[row + 1, column].visited)
            {
                visitedCells++;
            }

            if (column > 0 && mazeCells[row, column - 1].visited)
            {
                visitedCells++;
            }

            if (column < (mazeColumns - 2) && mazeCells[row, column + 1].visited)
            {
                visitedCells++;
            }

            return visitedCells > 0;
        }
        #endregion

        #region DestroyWalls
        private void DestroyAdjacentWall(int row, int column)
        {
            bool wallDestroyed = false;

            while (!wallDestroyed)
            {
                int direction = ProceduralNumberGenerator.GetNextNumber();

                if (direction == 1 && row > 0 && mazeCells[row - 1, column].visited)
                {
                    DestroyWallIfItExists(mazeCells[row, column].topWall);
                    DestroyWallIfItExists(mazeCells[row - 1, column].bottomWall);
                    wallDestroyed = true;
                }
                else if (direction == 2 && row < (mazeRows - 2) && mazeCells[row + 1, column].visited)
                {
                    DestroyWallIfItExists(mazeCells[row, column].bottomWall);
                    DestroyWallIfItExists(mazeCells[row + 1, column].topWall);
                    wallDestroyed = true;
                }
                else if (direction == 3 && column > 0 && mazeCells[row, column - 1].visited)
                {
                    DestroyWallIfItExists(mazeCells[row, column].leftWall);
                    DestroyWallIfItExists(mazeCells[row, column - 1].rightWall);
                    wallDestroyed = true;
                }
                else if (direction == 4 && column < (mazeColumns - 2) && mazeCells[row, column + 1].visited)
                {
                    DestroyWallIfItExists(mazeCells[row, column].rightWall);
                    DestroyWallIfItExists(mazeCells[row, column + 1].leftWall);
                    wallDestroyed = true;
                }
            }
        }
        private void DestroyWallIfItExists(GameObject wall)
        {
            if (wall != null)
            {
                GameObject.Destroy(wall);
            }
        }
        #endregion
    }
}