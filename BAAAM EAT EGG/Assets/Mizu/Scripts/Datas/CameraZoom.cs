using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private float[] cameraSize = new float[6] { 2.5f, 3.1f, 3.8f, 4.5f, 5.2f, 6f };
        private int index = 0;

        private bool isChanging = false;
        private float elapsedTime = 0f;

        private void Start()
        {
            _camera.orthographicSize = cameraSize[index];
        }

        private void Update()
        {
            if (!isChanging) return;
            ZoomOut();
        }

        private void ZoomOut()
        {
            elapsedTime += Time.unscaledDeltaTime;
            _camera.orthographicSize = Mathf.Lerp(cameraSize[index - 1], cameraSize[index], 1 * elapsedTime);

            if (Mathf.Abs(cameraSize[index] - _camera.orthographicSize) < 0.1f)
            {
                isChanging = false;
                elapsedTime = 0f;
            }
        }

        public void SetCameraSize()
        {
            index++;
            isChanging = true;
        }
    }
}