using Hole.Runtime.Features.Score;
using Zenject;

namespace Hole.Runtime.Features.UI
{
    public class ScoreShower : TextSetter
    {
        private ScoreContainer scoreContainer;

        [Inject]
        public void Construct(ScoreContainer scoreContainer) => 
            this.scoreContainer = scoreContainer;

        private void Awake()
        {
            scoreContainer.OnScoreChanged += SetScore;
            
            SetTextValue("0");
        }

        private void OnDestroy() => 
            scoreContainer.OnScoreChanged -= SetScore;
        
        private void SetScore(int score) => 
            SetTextValue(score.ToString());
    }
}