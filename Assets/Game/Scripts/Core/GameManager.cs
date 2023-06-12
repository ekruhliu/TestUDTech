using System;
using Game.Scripts.ObserverMode;
using Game.Scripts.Player;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        private enum GameModes
        {
            Observer,
            Player
        }

        private GameModes _gameMode;

        [SerializeField] private GameObject _playerCamera;
        [SerializeField] private GameObject _observerCamera;
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private ObserverCameraController _observerCameraController;

        private void Start()
        {
            _gameMode = GameModes.Observer;
            _uiManager.OnUserInterface();
        }

        private void Update()
        {
            if (_gameMode == GameModes.Player)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    OnObserverMode();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    OnPlayerMode();
                }
            }
        }

        private void OnPlayerMode()
        {
            _gameMode = GameModes.Player;
            _observerCamera.SetActive(false);
            _playerCamera.SetActive(true);
            _uiManager.OffUserInterface();
            _playerController.SetInputStatus(true);
            _observerCameraController.enabled = false;
        }

        private void OnObserverMode()
        {
            _gameMode = GameModes.Observer;
            _observerCamera.SetActive(true);
            _playerCamera.SetActive(false);
            _uiManager.OnUserInterface();
            _playerController.SetInputStatus(false);
            _observerCameraController.enabled = true;
        }
    }
}