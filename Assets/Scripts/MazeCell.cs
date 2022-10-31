using UnityEngine;

namespace Maze
{
    public class MazeCell
    {
        #region Variables
        public bool visited;
        public GameObject topWall, bottomWall, rightWall, leftWall, ground;
        #endregion
    }
}