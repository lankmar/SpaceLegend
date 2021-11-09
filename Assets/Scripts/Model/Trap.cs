using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceLegend
{
    public sealed class Trap : InteractiveObject, IFlay
    {
        private float _lengthFlay;
        private float _damage;

        public float _Damege { get; }

        private event EventHandler<CaughtPlayerEventArgs> _caughtPlayer;
        public event EventHandler<CaughtPlayerEventArgs> CaughtPlayer
        {
            add { _caughtPlayer += value; }
            remove { _caughtPlayer -= value; }
        }

        private void Awake()
        {
            _lengthFlay = Random.Range(5.0f, 10.0f);
            _damage = Random.Range(10.0f, 50.0f);
        }

        protected override void Interaction()
        {
            _caughtPlayer?.Invoke(this, new CaughtPlayerEventArgs(_damage));
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.y, Mathf.PingPong(Time.time, _lengthFlay));
        }
    }
}