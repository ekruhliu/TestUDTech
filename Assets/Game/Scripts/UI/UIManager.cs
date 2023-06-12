using System;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _scrollButton;
        [SerializeField] private GameObject _playerModeButton;
        [SerializeField] private GameObject _observerModeButton;

        public void OnUserInterface()
        {
            _moveButton.SetActive(true);
            _scrollButton.SetActive(true);
            _playerModeButton.SetActive(true);
            _observerModeButton.SetActive(false);
        }

        public void OffUserInterface()
        {
            _moveButton.SetActive(false);
            _scrollButton.SetActive(false);
            _playerModeButton.SetActive(false);
            _observerModeButton.SetActive(true);
        }
    }
}