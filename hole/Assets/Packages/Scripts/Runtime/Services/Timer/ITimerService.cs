using System;

namespace Hole.Runtime.Services.Timer
{
    public interface ITimerService
    {
        void StartTimer();
        void StopTimer();
        void PauseTimer();
        void ResetTimer();
        void ResumeTimer();
        
        event Action<int> OnTimeChanged; 
        event Action OnTimeEnd;

    }
}