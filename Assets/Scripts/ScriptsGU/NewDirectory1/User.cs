using System;
using UnityEngine;

namespace Geekbrains.NewDirectory1
{
    public sealed class User : MonoBehaviour, IUser
    {
        private float _hp = 100;
        public event Action<float> OnHpChange;

        public void SetDamage()
        {
            _hp--;
            OnHpChange?.Invoke(_hp);
        }
    }
}
