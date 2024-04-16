using System;
using UniRx;

namespace Gameplay.Level
{
    public interface IKeysHolder
    {
        ReactiveProperty<int> UncollectedKeysCount { get; }
        event Action OnKeysSpawned;
    }
}