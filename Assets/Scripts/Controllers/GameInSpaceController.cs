using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceLegend
{

    public sealed class GameInSpaceController : MonoBehaviour, IDisposable
    {
        private InterctibleObjList _interactiveObject;
        private PlayerData _playerData;

        private void Awake()
        {
            _playerData = new PlayerData();
            _playerData.PlayerStat.Hp = 200;
            _interactiveObject = new InterctibleObjList();
            foreach (var o in _interactiveObject)
            {
                if (o is Trap trap)
                {
                    trap.CaughtPlayer += CaughtPlayer;
                    //trap.CaughtPlayer += delegate (object sender, CaughtPlayerEventArgs args)
                    //{ Debug.Log($"Урон"); };
                }
                if (o is Gas gas)
                {
                    gas.CaughtPlayer += CaughtPlayer;
                    gas.CaughtPlayer += delegate (object sender, CaughtPlayerEventArgs args)
                    { Debug.Log($"gas " + args.Count); };
                }
                if (o is Ore ore)
                {
                    ore.CaughtPlayer += CaughtPlayer;
                }
            }
        }

        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
        {
            Debug.Log("object value  - " + value + ", CaughtPlayerEventArgs args - " + args.Count);
            if (value is Trap trap)
            {
                _playerData.PlayerStat.Hp -= trap._Damege;
                Debug.Log("PlayerResourse.GasCount  - " + _playerData.PlayerResourse.GasCount);
            }
            if (value is Gas gas)
            {
                _playerData.PlayerResourse.GasCount += gas._GasCount;
                Debug.Log("GasCount  - " + args.Count);
                Debug.Log("PlayerResourse.GasCount  - " + _playerData.PlayerResourse.GasCount);
            }
            if (value is Ore ore)
            {
                _playerData.PlayerResourse.OreCount += ore._GasCount;
                Debug.Log("PlayerResourse.OreCount  - " + _playerData.PlayerResourse.OreCount);
            }
            //Time.timeScale = 0.0f;
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFlay flay)
                {
                    flay.Flay();
                }
            }
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is InteractiveObject interactiveObject)
                {
                    if (o is Trap trap)
                    {
                        trap.CaughtPlayer -= CaughtPlayer;
                    }
                    if (o is Gas gas)
                    {
                        gas.CaughtPlayer -= CaughtPlayer;
                    }
                    if (o is Ore ore)
                    {
                        ore.CaughtPlayer -= CaughtPlayer;
                    }
                    Destroy(interactiveObject.gameObject);
                }
            }

        }
    }
}