using System;
using DG.Tweening;
using Hole.Runtime.Features.Game;
using UnityEngine;
using Zenject;

namespace Hole.Runtime.Services.Timer
{
    public class LifeTimer : ITimerService
    {
        private int currentSeconds;

        private bool isExecuting;

        private GameData data;

        private Sequence timerSequence = null;

        public event Action<int> OnTimeChanged;
        public event Action OnTimeEnd;

        [Inject]
        public LifeTimer(GameData data) => 
            this.data = data;

        public void AddTime() => 
            currentSeconds += data.TimeBusterValue;

        public void StartTimer()
        {
            if (timerSequence != null)
            {
                Debug.LogWarning("Timer is Already Starting");
                return;
            }
            isExecuting = true;
            currentSeconds = data.GameplayTime;
            
            ChangeTime();
        }

        public void StopTimer()
        {
            timerSequence?.Kill();
            timerSequence = null;
            currentSeconds = data.GameplayTime;
        }

        public void ResumeTimer() =>
            isExecuting = true;

        public void PauseTimer() =>
            isExecuting = false;

        public void ResetTimer()
        {
            currentSeconds = data.GameplayTime;
            ChangeTime();
        }

        private void ChangeTime()
        {
            if (!isExecuting)
                return;

            if (currentSeconds == 0)
            {
                OnTimeEnd?.Invoke();
                return;
            }

            timerSequence = DOTween.Sequence()
                .Append(DOVirtual.DelayedCall(1f, OnNewSecondLeft))
                .Play();
        }

        private void OnNewSecondLeft()
        {
            currentSeconds--;
            
            ChangeTime();
            
            OnTimeChanged?.Invoke(currentSeconds);
        }
    }
}