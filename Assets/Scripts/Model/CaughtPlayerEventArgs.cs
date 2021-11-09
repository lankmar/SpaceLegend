using System;
using UnityEngine;

namespace SpaceLegend
{
    public sealed class CaughtPlayerEventArgs : EventArgs
    {
        public Color Color { get; }
        // Можем дописать сколько угодно свойств
        public CaughtPlayerEventArgs(Color Color)
        {
            Color = Color;
        }
        public float Count { get; }
        // Можем дописать сколько угодно свойств
        public CaughtPlayerEventArgs(float Count)
        {
            Count = Count;
        }

    }
}