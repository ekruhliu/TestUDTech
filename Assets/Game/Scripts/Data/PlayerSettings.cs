using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/Create Player Settings", order = 1)]
    public class PlayerSettings : ScriptableObject
    {
        public float MouseSensivity;
        public float MovementSpeed;
        public float GravityForce;
    }
}