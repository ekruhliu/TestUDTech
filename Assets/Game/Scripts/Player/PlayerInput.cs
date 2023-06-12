using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public PlayerInputActions Actions
        {
            get { return actions; }
        }
        private PlayerInputActions actions;
        private void Awake()
        {
            actions = new PlayerInputActions();
        }
        protected virtual void OnEnable()
        {
            actions.Player.Enable();
        }
        protected virtual void OnDisable()
        {
            actions.Player.Disable();
        }
    }
}