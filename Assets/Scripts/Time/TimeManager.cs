using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    [SerializeField]
    private Color MorningColor, DayColor;

    [SerializeField]
    private float HourInGame = 24.0f, TimeRun = 0 , Hour , Minute , lightValue;

    [SerializeField]
    private float minLight = 0.2f, maxLight = 1.0f;

    [SerializeField]
    private Light2D light2d;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private RectTransform HourClock, MinClock;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        TimeRun += Time.deltaTime;
        Hour = (TimeRun / 60.0f) % HourInGame;
        Minute = TimeRun % 60.0f;

        lightValue = Hour > 12 ? maxLight - ((Hour - 12 ) / (HourInGame / 2)) : Hour / (HourInGame / 2);
        light2d.intensity = minLight + lightValue;

        setClockDisplay();
        setSkyColor();
       

    }

    void setSkyColor()
    {
        Color sky = Hour > 12 ? Color.Lerp(DayColor, MorningColor, ((Hour - 12) / (HourInGame / 2))) : Color.Lerp(MorningColor, DayColor, Hour / (HourInGame / 2));
        light2d.color = sky;
        cam.backgroundColor = sky;

    }

    void setClockDisplay()
    {
        float HRotate = 360.0f * (Hour / (HourInGame / 2));
        HourClock.rotation = Quaternion.Euler(0, 0, -HRotate);

        float MRotate = 360.0f * (Minute / 60);
        MinClock.rotation = Quaternion.Euler(0, 0, -MRotate);

    }

}
