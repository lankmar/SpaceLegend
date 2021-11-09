using System;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Test
{
    internal sealed class ExampleDelegate
    {
        private MyDelegate _myDelegate;
        
        private Action<int> _action;
        private Func<int, double> _func;
        private Predicate<int> _predicate;
        
        public ExampleDelegate()
        {
            _action = Action;
            _func = Func;
            _predicate = Predicate;
        }

        private bool Predicate(int obj)
        {
            throw new NotImplementedException();
        }

        private double Func(int arg)
        {
            throw new NotImplementedException();
        }

        private void Action(int obj)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            Debug.Log("*****************");
            _myDelegate?.Invoke();
        }

        private void MyDelegate()
        {
            Debug.Log(1);
        }

        private Dictionary<string, Action> _actions;
        
        public void NameMethod(string value)
        {
            _actions = new Dictionary<string, Action>
            {
                ["Move"] = Move,
                ["Attack"] = Attack,
            };

            var beginInvoke = _actions[value].BeginInvoke(null, null);
            
            if (beginInvoke.IsCompleted)
            {
                
            }
            
            
            
            _actions[value]?.Invoke();

            
            switch (value)
            {
                case "Move":
                    Move();
                    break;
                case "Attack":
                    Attack();
                    break;
            }
        }

        private void Callback(IAsyncResult ar)
        {
        }

        private void Attack()
        {
            Debug.Log("----------------------------");
        }

        private void Move()
        {
            Debug.Log("*****************");
        }
    }
}
