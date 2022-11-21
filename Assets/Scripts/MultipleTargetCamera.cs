using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    [RequireComponent(typeof(Camera))]
    public class MultipleTargetCamera : MonoBehaviour
    {
        #region Variables
        // public variables
        public List<Transform> targets;
        public MazeGenerator mazeGenerator;
        public Vector3 offset;
        // private variables
        private Camera cam;
        private float zoomSize;
        #endregion

        #region ActivationMoments
        private void Start()
        {
            cam = GetComponent<Camera>();
            if (targets.Count == 0)
                return;
            Move();
            Zoom();
        }

        public void GenerateButton()
        {
            Move();
            Zoom();
        }
        #endregion

        #region Move&Zoom
        private void Move()
        {
            targets[1].position = new Vector3(mazeGenerator.rows, 0, mazeGenerator.columns);
            Vector3 centerPoint = GetCenterPoint();
            Vector3 newPosition = centerPoint + offset;
            transform.position = newPosition;
        }
        private void Zoom()
        {

            if (DistanceX() >= DistanceZ())
            {
                zoomSize = DistanceX();
            }
            if (DistanceX() < DistanceZ())
            {
                zoomSize = DistanceZ();
            }

            cam.orthographicSize = zoomSize / 1.7f;
        }

        private float DistanceX()
        {
            Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
            for (int i = 0; i < targets.Count; i++)
            {
                bounds.Encapsulate(targets[i].position);
            }
            return bounds.size.x;
        }
        private float DistanceZ()
        {
            Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
            for (int i = 0; i < targets.Count; i++)
            {
                bounds.Encapsulate(targets[i].position);
            }
            return bounds.size.z;
        }


        private  Vector3 GetCenterPoint()
        {
            if (targets.Count == 1)
            {
                return targets[0].position;
            }

            Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
            for (int i = 0; i < targets.Count; i++)
            {
                bounds.Encapsulate(targets[i].position);
            }

            return bounds.center;
        }
        #endregion
    }
}