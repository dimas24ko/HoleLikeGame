using System;

namespace Hole.Runtime.Features.Score
{
    public class ScoreContainer
    {
        private int score;

        public int Score => score;

        public Action<int> OnScoreChanged;

        public void IncreaseScore()
        {
            score++;
            OnScoreChanged?.Invoke(score);
        }

        public void DecreaseScore()
        {
            score--;
            OnScoreChanged?.Invoke(score);
        }
    }
}