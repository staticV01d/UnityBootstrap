using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TimerScript : MonoBehaviour
{
    private float timer = 0;
    private bool isTimerRunning = false;

    public PlatformTriggerScript startPlatform;
    public PlatformTriggerScript endPlatform;

    public TextMeshProUGUI timerText;

    public bool isTimerSet = false;

    public UnityEvent onReachedEnd;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (isTimerRunning && isTimerSet)
        {
            timer += Time.deltaTime;
        }

        if (isTimerSet && !startPlatform.PlayerInsideZone())
        {
            StartTimer();
        }
        if (isTimerRunning && endPlatform.PlayerInsideZone())
        {
            StopTimer();
        }
        if (!isTimerSet && startPlatform.PlayerInsideZone())
        {
            ResetTimer();
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        // timerText.text = $"Time: {timer:#.00}";
        timerText.text = string.Format("Time:\n{0:00}:{1:00}:{2:000}", GetMinutes(), GetSeconds(), GetMilliseconds());
    }

    float GetMinutes() { return Mathf.FloorToInt(timer / 60); }
    float GetSeconds() { return Mathf.FloorToInt(timer % 60); }
#pragma warning disable IDE0047
    float GetMilliseconds() { return (timer % 1) * 1000; }

    public float Minutes { get { return GetMinutes(); } }
    public float Seconds { get { return GetSeconds(); } }

    public void ResetTimer()
    {
        timer = 0;
        isTimerSet = true;
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()  // TODO: implement 'Game Over, try again' screen.
    {
        isTimerRunning = false;
        isTimerSet = false;

        onReachedEnd?.Invoke();
    }

    public float CurrentTimer()
    {
        return timer;
    }
}
