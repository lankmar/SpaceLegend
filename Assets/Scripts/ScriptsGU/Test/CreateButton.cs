using System;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains.Test
{
    internal sealed class CreateButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Transform _root;
        private void Start()
        {
            for (int i = 0; i < 100; i++)
            {
                var instantiate = Instantiate(_button, _root);
                instantiate.GetComponentInChildren<Text>().text = i.ToString();
                var i1 = i;
                instantiate.onClick.AddListener(() => Debug.Log(i1));
            }
        }

        internal class MyClass
        {
            public int i2;
            public void Run()
            {
                Debug.Log(i2);
            }
        }
    }
}
