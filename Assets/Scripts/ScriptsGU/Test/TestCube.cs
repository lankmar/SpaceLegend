using System;
using UnityEngine;

namespace Geekbrains.Test
{
    internal sealed class TestCube : MonoBehaviour
    {
        private int _hp = 100;
        public event Action<string, Data> OnTriggerChange;
        
        private void OnTriggerEnter(Collider other)
        {
            OnTriggerChange?.Invoke(other.gameObject.name, new Data(--_hp, name));
        }
    }
}
