using System;

namespace Geekbrains.Test
{
    internal sealed class TestEvaet
    {
        private float _hp;
        public event Action<float> Test;

        public float Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                Test?.Invoke(_hp);
            }
        }
    }
}
