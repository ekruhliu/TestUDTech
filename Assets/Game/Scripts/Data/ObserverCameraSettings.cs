using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "ObserverCameraSettings", menuName = "ScriptableObjects/Create Observer Camera Settings", order = 2)]
    public class ObserverCameraSettings : ScriptableObject
    {
        public float ZoomSpeed;
        public float MinZoom;
        public float MaxZoom;
        public float RotationSpeed;
    }
}