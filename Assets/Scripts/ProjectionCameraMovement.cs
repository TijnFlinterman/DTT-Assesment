using UnityEngine;

namespace Maze
{
    public class ProjectionCameraMovement : MonoBehaviour
    {
        private void Update()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = Camera.main.transform.position.y + Camera.main.nearClipPlane;
            transform.position = mousePosition;
        }
    }
}