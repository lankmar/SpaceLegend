using Space;
using System;
using UnityEngine;
namespace SpaceLegend
{
    public sealed class PlayerShip : Player
    {
        private float _hp = 100;
        public event Action<float> OnHpChange;
        MouseCamera mouseCamera;
        CameraController cameraController;


        void Start()
        {
            mouseCamera = FindObjectOfType<MouseCamera>();
            cameraController = FindObjectOfType<CameraController>();
        }

        public void SetDamage()
        {
            _hp--;
            OnHpChange?.Invoke(_hp);
        }

        private void FixedUpdate()
        {
            mouseCamera.SpaceUpdate();
            ShipMove();
            cameraController.SpaceUpdate();
        }
    }
}