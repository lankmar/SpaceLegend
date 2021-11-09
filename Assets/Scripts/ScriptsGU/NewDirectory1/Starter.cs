using System;
using UnityEngine;

namespace Geekbrains.NewDirectory1
{
    internal sealed class Starter : MonoBehaviour
    {
        private User _user;

        private void Start()
        {
            _user = FindObjectOfType<User>();
            new Display(_user);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _user.SetDamage();
            }
        }
    }
}
