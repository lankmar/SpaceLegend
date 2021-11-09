using System;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains.Test
{
    internal sealed class ExampleDisplay : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private TestCube _testCube;

        private void Start()
        {
            // var testExample = new TestExample();
            // var testDelegate = new TestExample.TestDelegate(TestDelegate);
            // testDelegate += Debug.LogWarning;
            // testExample.GetMoney(testDelegate);
        }

        private void TestDelegate(string value)
        {
            Debug.Log(value);
        }

        public void Init(TestCube testCube)
        {
            _testCube = testCube;
            _testCube.OnTriggerChange += TestCubeOnOnTriggerChange;
        }

        private void TestCubeOnOnTriggerChange(string arg1, Data arg2)
        {
            _text.text = $"{arg1} {arg2}";
        }

        ~ExampleDisplay()
        {
            _testCube.OnTriggerChange -= TestCubeOnOnTriggerChange;
        }
    }
}
