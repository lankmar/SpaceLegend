using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Geekbrains.Test
{
    internal sealed class TestExample
    {
        public delegate void TestDelegate(string value); // 1

        private TestDelegate _testDelegate;   // 2
        private MyDelegate _r;   // 2
        private int _i;   // 2

        private string _money ="9999999999999999999 рублей";

        private Button _button;
        private InputField _inputField;

        public void NameMethod()
        {
            _i = 2;
            _i += 3;
            _i -= 3;
            _testDelegate = TestDelegateMethod; // 3
            
            _r += GetOne;// 3
            _r += GetTwo;// 3
            _r += GetTwo;// 3
            _r += GetTwo;// 3
            _r += GetTwo;// 3
            _r += GetTwo;// 3
            _r += GetTwo;// 3
            _r += GetTwo;// 3
            _r += GetTwo;// 3
            _r -= GetTwo;
            
            #region MyRegion

            _testDelegate += t =>
            {
                Debug.Log(t);
                Debug.LogWarning(22);
            };
            _testDelegate += delegate(string value) { Debug.Log(value); };

            #endregion

            #region Button
            
            _button.onClick.AddListener(() => Debug.Log(3));
            _button.onClick.AddListener(OnClickButton);
            _button.onClick.RemoveAllListeners();
            _button.onClick.RemoveListener(OnClickButton);
            _inputField.onValueChanged.AddListener(arg0 => Debug.Log(arg0));

            #endregion

            if (_testDelegate != null)
            {
                _testDelegate("Hello world"); // 4
                TestDelegateMethod("Hello world");
            }

            #region MyRegion

            _testDelegate?.Invoke("454"); // 4

            #endregion
        }

        public void GetMoney(TestDelegate testDelegate) => testDelegate?.Invoke(_money);

        private void TestDelegateMethod(string value3)
        {
            Debug.Log(value3);
        }

        private void TeseMethod(string y)
        {
            throw new System.NotImplementedException();
        }

        private int GetOne() => 1;

        private int GetTwo()
        {
            return 2;
        }

        private void OnClickButton()
        {
           Debug.LogWarning(2352);
        }
        
        void Start()
        {
            // EventTrigger trigger = GetComponent<EventTrigger>();
            // EventTrigger.Entry entry = new EventTrigger.Entry();
            // entry.eventID = EventTriggerType.PointerDown;
            // entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
            // trigger.triggers.Add(entry);
        }

        public void OnPointerDownDelegate(PointerEventData data)
        {
            Debug.Log("OnPointerDownDelegate called.");
        }
    }
}
