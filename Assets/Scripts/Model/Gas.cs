using System;
using Random = UnityEngine.Random;

namespace SpaceLegend
{
    public sealed class Gas : InteractiveObject
    {
        private float _gasCount;

        public float _GasCount{ get; }

        private event EventHandler<CaughtPlayerEventArgs> _caughtPlayer;
        public event EventHandler<CaughtPlayerEventArgs> CaughtPlayer
        {
            add { _caughtPlayer += value; }
            remove { _caughtPlayer -= value; }
        }

        private void Awake()
        {
            _gasCount = Random.Range(100.0f, 500.0f);            
        }

        protected override void Interaction()
        {
            _caughtPlayer?.Invoke(this, new CaughtPlayerEventArgs(_gasCount));
        }
    }
}