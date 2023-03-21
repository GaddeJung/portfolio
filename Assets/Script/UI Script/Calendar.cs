using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    public int month;
    public int day = 1;
    public int week;
    public string Aweek;
    public int time = 0;
    public string Atime;

    public GameObject daytime;
    public GameObject nighttime;
    public Text atime;
    public Text days;
    public Text aweek;

    public GameObject work;


    void Start()
    {
        month = 1;
        day = 1;
        week = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Week();
        Time();
        days.text =(int)month + "월  " + (int)day + "일";
        atime.text = Atime;
        aweek.text = Aweek;

        if (time <= 2 && time >= 0)
        {
            daytime.SetActive(true);
            nighttime.SetActive(false);
        }

        else if (time == 3)
        {
            nighttime.SetActive(true);
            daytime.SetActive(false);
        }

        if (day == 32)
        {
            day = 1;
            month++;
        }

        if (month == 13)
        {
            month = 1;
        }

       // if (week == 7)
       // {
       //     work.GetComponent<Work>().PocketMoney();
       // }

    }

    public void TimeUp()
    {
        if (time <= 3)
        {
            time++;
        }
        
    }


    void Week()
    {
        switch (week)
        {
            case 1:
                Aweek = "월요일";
                break;
            case 2:
                Aweek = "화요일";
                break;
            case 3:
                Aweek = "수요일";
                break;
            case 4:
                Aweek = "목요일";
                break;
            case 5:
                Aweek = "금요일";
                break;
            case 6:
                Aweek = "토요일";
                break;
            case 7:
                Aweek = "일요일";
                break;

        }
        if (week > 7)
        {
            week = 1;
        }

    }
    void Time()
    {
        switch (time)
        {
            case 0: Atime = "오전";
                break;
            case 1: Atime = "점심";
                break;
            case 2: Atime = "오후";
                break;
            case 3: Atime = "저녁";
                break;
        }
    }

}
