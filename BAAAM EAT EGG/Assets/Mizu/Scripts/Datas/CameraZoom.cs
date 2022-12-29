using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        float[] cameraSize = new float[6] { 2.5f, 3.1f, 3.8f, 4.5f, 5.2f, 6f };
        int index = 0;

        private void Start()
        {
            _camera.orthographicSize = cameraSize[index];
        }

        public void SetCameraSize()
        {
            index++;
            _camera.orthographicSize = cameraSize[index];
        }
    }
}