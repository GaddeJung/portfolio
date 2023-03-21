using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirthDay : MonoBehaviour
{
    public int month = 3;
    public int day = 1;
    bool firstStart = false;

    public Text monthText;
    public Text dayText;

    public GameObject work;
    public GameObject birthdayimage;
    public GameObject buttonImage;
    public GameObject Button;
    public GameObject gameStart;

    private void Start()
    {
        if (firstStart == false)
        {
            Firststart();
        }

    }

    void Firststart()
    {
        birthdayimage.SetActive(true);
        buttonImage.SetActive(true);
        StartCoroutine(work.GetComponent<Work>().FirstStart());

    }

    private void Update()
    {
        monthText.text = "" + month;
        dayText.text = "" + day;
    }

    public void MonthUp()
    {
        if (month < 12)
        {
            month++;
        }
        else if (month == 12)
        {
            month = 1;
        }
    }

    public void MonthDown()
    {
        if (month > 1) 
        { month--; }

        else if (month == 1)
        {
            month = 12;
        }
    }

    public void DayUp()
    {
        if (day < 31) 
        {
            day++;
        }
        else
        {
            day = 1;
        }
    }

    public void DayDown()
    {
        if (day > 1)
        {
            day--;
        }

        else
        {
            day = 31;
        }
    }

    public void BirthSuccess()
    {
        buttonImage.SetActive(true);
        StartCoroutine(work.GetComponent<Work>().FirstEnd());
    }

    public void YesButton()
    {
        buttonImage.SetActive(false);
        Button.SetActive(false);
        birthdayimage.SetActive(false);
        firstStart = true;

    }
    public void NoButton()
    {
        buttonImage.SetActive(false);
        Button.SetActive(false);
    }

}
