using System;

namespace Geekbrains.NewDirectory1
{
    internal interface IUser
    {
        event Action<float> OnHpChange;
    }
}
