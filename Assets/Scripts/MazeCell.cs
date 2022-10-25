using UnityEngine;
using System.Collections.Generic;

public class MazeCell
{
    public bool visited;
    public GameObject topWall, bottomWall, rightWall, leftWall, ground;

    public void DestroyCell()
    {
        GameObject.Destroy(topWall);
        GameObject.Destroy(topWall);
        GameObject.Destroy(topWall);
        GameObject.Destroy(topWall);
    }
}