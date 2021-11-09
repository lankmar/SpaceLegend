using System;

namespace SpaceLegend
{
    internal interface ISetHp 
    {
        event Action<float> OnHpChange;
    }
}