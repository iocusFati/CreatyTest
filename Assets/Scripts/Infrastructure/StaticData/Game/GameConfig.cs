using UnityEngine;

namespace Infrastructure.StaticData.Game
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private int _levelTime;

        public int LevelTime => _levelTime;
    }
}