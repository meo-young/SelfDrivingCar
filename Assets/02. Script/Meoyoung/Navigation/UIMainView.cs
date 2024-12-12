using System;
using UnityEngine;
using UnityEngine.UI;

public class UIMainView : MonoBehaviour
{
    [SerializeField] GameObject navigationUI;
    [SerializeField] Text distanceText;
    [SerializeField] Text timeText;

    [SerializeField] Person[] ps;
    public void OnClickHandler()
    {
        if (navigationUI.activeSelf)
            navigationUI.SetActive(false);

        for (int i = 0; i < ps.Length; i++)
            ps[i].bStart = true;
    }

    public void UpdateDistance(float _distance)
    {

        distanceText.text = _distance.ToString("F0") + "m";
    }

    public void UpdateTimeUI(float _time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(_time);
        string formattedTime = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        timeText.text = formattedTime;
    }
}
