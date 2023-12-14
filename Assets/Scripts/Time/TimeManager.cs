using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    [SerializeField]
    private Color NightColor, DayColor , skyColor;

    [SerializeField]
    private float HourInGame = 24.0f, TimeRun = 0 , Hour , Minute;

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

        setClockDisplay();
        setSkyColor();
       

    }

    void setSkyColor()
    {
        Color sky = Hour > 12 ? Color.Lerp(skyColor, NightColor, ((Hour - 12) / (HourInGame / 2))) : Color.Lerp(NightColor, skyColor, Hour / (HourInGame / 2));
        Color light = Hour > 12 ? Color.Lerp(DayColor, NightColor, ((Hour - 12) / (HourInGame / 2))) : Color.Lerp(NightColor, DayColor, Hour / (HourInGame / 2));
        light2d.color = light;
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
