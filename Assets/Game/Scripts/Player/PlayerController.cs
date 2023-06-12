using System;
using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private Transform _cameraPoint;
        [SerializeField] private LayerMask GroundLayers;
        private PlayerInput _playerInput;
        private CharacterController _controller;
        private MeshRenderer _renderer;

        private Vector2 _mouseLook;
        private Vector2 _move;
        private float _xRotation = 0f;

        private bool _grounded = true;
        private float _groundedOffset = -0.14f;
        private float _groundedRadius = 0.5f;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _controller = GetComponent<CharacterController>();
            _renderer = GetComponent<MeshRenderer>();
            _playerInput.enabled = false;
            _renderer.enabled = false;
        }

        private void Update()
        {
            Move();
            Look();
            GroundedCheck();
            Gravity();
        }

        private void Move()
        {
            _move = _playerInput.Actions.Player.Move.ReadValue<Vector2>();
            
            if(_move == Vector2.zero)
                return;
            
            Vector3 inputDirection = new Vector3(_move.x, 0.0f, _move.y).normalized;
            inputDirection = transform.right * _move.x + transform.forward * _move.y;
            _controller.Move(inputDirection.normalized * (_playerSettings.MovementSpeed * Time.deltaTime));
        }

        private void Look()
        {
            _mouseLook = _playerInput.Actions.Player.Look.ReadValue<Vector2>();

            float mouseX = _mouseLook.x * _playerSettings.MouseSensivity * Time.deltaTime;
            float mouseY = _mouseLook.y * _playerSettings.MouseSensivity * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90);

            _cameraPoint.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
        
        private void GroundedCheck()
        {
            Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - _groundedOffset, transform.position.z);
            _grounded = Physics.CheckSphere(spherePosition, _groundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
        }

        private void Gravity()
        {
            if (!_grounded)
                _controller.Move(new Vector3(0f, _playerSettings.GravityForce, 0f) * Time.deltaTime);
        }

        public void SetInputStatus(bool status)
        {
            _playerInput.enabled = status;
            _renderer.enabled = status;
        }
    }
}