namespace Maze
{
    public abstract class MazeAlgorithm
    {
        #region Variables
        protected MazeCell[,] mazeCells;
        protected int mazeRows, mazeColumns;
        #endregion
        protected MazeAlgorithm(MazeCell[,] mazeCells) : base()
        {
            this.mazeCells = mazeCells;
            mazeRows = mazeCells.GetLength(0);
            mazeColumns = mazeCells.GetLength(1);
        }

        public abstract void CreateMaze();
    }
}