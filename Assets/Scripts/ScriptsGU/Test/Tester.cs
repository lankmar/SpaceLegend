using System;
using UnityEngine;

namespace Geekbrains.Test
{
    internal class Tester : MonoBehaviour, IDisposable
    {
        //но не от MonoBehaviour
        public Tester()
        {
            // +
        }

        public void Init()
        {
            // +
        }
        
        private void OnEnable()
        {
            // +
        }

        private void OnDisable()
        {
            //-
        }

        private void OnDestroy()
        {
            //-
        }

        ~Tester()
        {
            //-
        }

        public void Dispose()
        {
            //-
        }
    }
}
