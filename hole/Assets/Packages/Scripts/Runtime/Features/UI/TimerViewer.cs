using Hole.Runtime.Services.TimeFormatter;
using Hole.Runtime.Services.Timer;
using Zenject;

namespace Hole.Runtime.Features.UI
{
    public class TimerViewer : TextSetter
    {
        private ITimerService timer;
        private TimeFormatter timeFormatter;

        [Inject]
        public void Construct(ITimerService timer, TimeFormatter timeFormatter)
        {
            this.timer = timer;
            this.timeFormatter = timeFormatter;
        }

        private void Awake() => 
            SubscribeOnTimer();

        private void OnDestroy() => 
            UnSubscribeOnTimer();

        private void ShowTime(int seconds)
        {
            var timeValue = timeFormatter.FromSecondsToMinuteAndSeconds(seconds);
            SetTextValue(timeValue);
        }

        private void SubscribeOnTimer() => 
            timer.OnTimeChanged +=  ShowTime;
        
        private void UnSubscribeOnTimer() => 
            timer.OnTimeChanged -= ShowTime;
    }
}
