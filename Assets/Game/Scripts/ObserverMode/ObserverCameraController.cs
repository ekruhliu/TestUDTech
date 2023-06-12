using System;
using Cinemachine;
using Game.Scripts.Core;
using Game.Scripts.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts.ObserverMode
{
    public class ObserverCameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private ObserverCameraSettings _observerCameraSettings;

        private bool _canRotate = false;
        private Vector3 _lastMousePosition;
        

        private void Update()
        {
            Rotate();
            Zoom();
        }

        private void Rotate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _canRotate = true;
                _lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _canRotate = false;
            }
            
            if (_canRotate)
            {
                Vector3 currentMousePosition = Input.mousePosition;
                float rotationAmount = (currentMousePosition.x - _lastMousePosition.x) * _observerCameraSettings.RotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, rotationAmount, Space.World);
                _lastMousePosition = currentMousePosition;
            }
        }

        private void Zoom()
        {
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");

            float targetZoom = _virtualCamera.m_Lens.FieldOfView - scrollDelta * _observerCameraSettings.ZoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, _observerCameraSettings.MinZoom, _observerCameraSettings.MaxZoom);

            _virtualCamera.m_Lens.FieldOfView = targetZoom;
        }
    }
}