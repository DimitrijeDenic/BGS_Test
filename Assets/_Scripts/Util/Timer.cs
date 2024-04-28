using UnityEngine;

namespace BGS.Util
{
    public class Timer
    {
        private float duration;
        private float elapsedTime;
        private bool isRunning;

        public delegate void TimerCallback();

        public TimerCallback OnTimerStart;
        public TimerCallback OnTimerUpdate;
        public TimerCallback OnTimerEnd;

        public Timer(float duration)
        {
            this.duration = duration;
            elapsedTime = 0f;
            isRunning = false;
        }

        public void Start()
        {
            elapsedTime = 0f;
            isRunning = true;
            OnTimerStart?.Invoke();
            
        }

        public void Stop()
        {
            isRunning = false;
        }

        public void Tick(float deltaTime)
        {
            if (isRunning)
            {
                elapsedTime += deltaTime;

                OnTimerUpdate?.Invoke();

                if (elapsedTime >= duration)
                {
                    isRunning = false;
                    OnTimerEnd?.Invoke();
                }
            }
        }

        public float GetElapsedTime()
        {
            return elapsedTime;
        }

        public float GetRemainingTime()
        {
            return Mathf.Max(0f, duration - elapsedTime);
        }

        public float GetDuration()
        {
            return duration;
        }

        public bool IsRunning()
        {
            return isRunning;
        }
    }

}