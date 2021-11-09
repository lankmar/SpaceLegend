using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpaceLegend
{
    public class PlayerResourse
    {
        float gasCount;
        float oreCount;

        public float GasCount { get => gasCount; set => gasCount = value; }
        public float OreCount { get => oreCount; set => oreCount = value; }
    }
}