using UnityEngine;

namespace Maze
{
    public class ResolutionDropdown : MonoBehaviour
    {
        #region ChangeResolution
        public void ChangeResolution(int _resolutionIndex)
        {
            if (_resolutionIndex == 0)
            {
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
            }
            if (_resolutionIndex == 1)
            {
                Screen.SetResolution(1440, 1080, Screen.fullScreen);
            }
            if (_resolutionIndex == 2)
            {
                Screen.SetResolution(1920, 886, Screen.fullScreen);
            }
        }
        #endregion
    }
}