using Hole.Runtime.Features.Score;
using Hole.Runtime.Services.Timer;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Hole.Runtime.Features.Game
{
    public class GameEventSpectator : MonoBehaviour
    {
        private ScoreContainer scoreContainer;
        private GameData gameData;
        private ITimerService timerService;

        [Inject]
        public void Construct(ScoreContainer scoreContainer, GameData gameData, ITimerService timerService)
        {
            this.scoreContainer = scoreContainer;
            this.gameData = gameData;
            this.timerService = timerService;
        }

        private void Awake()
        {
            scoreContainer.OnScoreChanged += CheckWin;
            timerService.OnTimeEnd += CheckLose;
            
            timerService.StartTimer();
        }

        private void CheckLose() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        private void CheckWin(int score)
        {
            if (gameData.WinScore == score)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnDestroy()
        {
            scoreContainer.OnScoreChanged -= CheckWin;
            timerService.OnTimeEnd -= CheckLose;
            
            timerService.StopTimer();
        }
    }
}