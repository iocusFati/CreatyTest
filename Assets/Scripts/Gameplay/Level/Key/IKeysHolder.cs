using UniRx;

namespace Gameplay.Level
{
    public interface IKeysHolder
    {
        ReactiveProperty<int> UncollectedKeysCount { get; }
    }
}