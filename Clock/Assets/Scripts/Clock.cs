using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hoursTransform;
    public Transform minutesTransform;
    public Transform secondsTransform;
    const float degreesPerHour = 30f;
    const float degreesMinutes = 6f;
    const float degreesSeconds = 6f;
    public bool continuous;

    private void Update()
    {
        if (continuous)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDiscrete();
        }
    }

    void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation = Quaternion.Euler(0f, degreesPerHour * (float)time.TotalHours, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, degreesMinutes * (float)time.TotalMinutes, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, degreesSeconds * (float)time.TotalSeconds, 0f);
    }

    void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;
        int h = time.Hour;
        int m = time.Minute;
        int s = time.Second;
        hoursTransform.localRotation = Quaternion.Euler(0f, degreesPerHour * h + 0.5f * m + (30.0f / 3600.0f) * s, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, degreesMinutes * m + 0.1f * s, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, degreesSeconds * s, 0f);
    }
}