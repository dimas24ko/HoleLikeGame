using UnityEngine;

namespace Hole.Runtime.Features.Game
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Game", order = 0)]
    public class GameData : ScriptableObject
    {
        public int GameplayTime;

        public int WinScore;

        public int TimeBusterValue;

        public float BiggerSpeedTime;
    }
}