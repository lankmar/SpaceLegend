using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Space
{
    public class TriggerOnTarget : MonoBehaviour
    {
        public ShipConrtoller ship;

        private void Start()
        {
            if (!ship) ship = FindObjectOfType<ShipConrtoller>();
        }

        void OnTriggerEnter(Collider onPlace)
        {
            ship.OnPlaceTrue();
        }
    }
}
