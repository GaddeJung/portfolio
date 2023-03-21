using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public GameObject calendar;
    public GameObject birthDay;
    public GameObject eventDialog;

    public bool eventing = false;
    public bool gyms = false;
    public bool towndowns = false;
    public bool nighttowndowns = false;
    public int clear = 0;

    private void Update()
    {

        if (calendar.GetComponent<Calendar>().month == 1 && calendar.GetComponent<Calendar>().day == 15 && calendar.GetComponent<Calendar>().time == 0 && eventing == false)
        {
            eventing = true;
            StartCoroutine(eventDialog.GetComponent<EventDialog>().Exam1day());
        }

        else if (calendar.GetComponent<Calendar>().month == 1 && calendar.GetComponent<Calendar>().day == 16 && calendar.GetComponent<Calendar>().time == 0 && eventing == false)
        {
            eventing = true;
            StartCoroutine(eventDialog.GetComponent<EventDialog>().Exam2day());
        }

        else if (calendar.GetComponent<Calendar>().month == 1 && calendar.GetComponent<Calendar>().day == 17 && calendar.GetComponent<Calendar>().time == 0 && eventing == false)
        {
            eventing = true;
            StartCoroutine(eventDialog.GetComponent<EventDialog>().Exam3day());
        }

        else if (calendar.GetComponent<Calendar>().month == 1 && calendar.GetComponent<Calendar>().day == 18 && calendar.GetComponent<Calendar>().time == 0 && eventing == false)
        {
            eventing = true;
            StartCoroutine(eventDialog.GetComponent<EventDialog>().Exam4day());
        }

        if (birthDay.GetComponent<BirthDay>().month == calendar.GetComponent<Calendar>().month && birthDay.GetComponent<BirthDay>().day == calendar.GetComponent<Calendar>().day && calendar.GetComponent<Calendar>().time == 2 && eventing == false )
        {
            eventing = true;
            StartCoroutine(eventDialog.GetComponent<EventDialog>().BirthDay());
        }

        if (calendar.GetComponent<Calendar>().week == 6 && calendar.GetComponent<Calendar>().time == 0 && eventing == false && clear != calendar.GetComponent<Calendar>().day)
        {
            eventing = true;
            StartCoroutine(eventDialog.GetComponent<EventDialog>().Starttowndown());
            clear = calendar.GetComponent<Calendar>().day;
        }

        if (calendar.GetComponent<Calendar>().week <= 5 && calendar.GetComponent<Calendar>().time == 3 && clear != calendar.GetComponent<Calendar>().day)
        {
            int random;
            random = Random.Range(1, 10);
            Debug.Log(random);
            if (random == 6)
            {
                Debug.Log("µÇ³Ä?");
                StartCoroutine(eventDialog.GetComponent<EventDialog>().Nighttowndown1());
            }

            clear = calendar.GetComponent<Calendar>().day;
        }

    }

    public void ExamSuccess()
    {
        StartCoroutine(eventDialog.GetComponent<EventDialog>().ExamSuccess());

    }

    public void ExamFail()
    {
        StartCoroutine(eventDialog.GetComponent<EventDialog>().ExamFail());
    }

    public void YesButton()
    {
        if (gyms == true)
        {
            eventDialog.GetComponent<EventDialog>().yesNoButton.SetActive(false);
            StartCoroutine(eventDialog.GetComponent<EventDialog>().GymYes());
        }

        else if (towndowns == true)
        {
            eventDialog.GetComponent<EventDialog>().yesNoButton.SetActive(false);
            StartCoroutine(eventDialog.GetComponent<EventDialog>().Yestowndown1());
        }

    }

    public void NoButton()
    {
        if (gyms == true)
        {
            eventDialog.GetComponent<EventDialog>().yesNoButton.SetActive(false);
            StartCoroutine(eventDialog.GetComponent<EventDialog>().GymNo());

        }

        else if (towndowns == true)
        {
            eventDialog.GetComponent<EventDialog>().yesNoButton.SetActive(false);
            StartCoroutine(eventDialog.GetComponent<EventDialog>().Notowndown());
        }

    }

    public void towndownExitButton()
    {
        if (towndowns == true)
        {
            eventDialog.GetComponent<EventDialog>().towndownbuyButton.SetActive(false);
            StartCoroutine(eventDialog.GetComponent<EventDialog>().Yestowndown2());
        }

        else if (nighttowndowns == true)
        {
            eventDialog.GetComponent<EventDialog>().towndownbuyButton.SetActive(false);
            StartCoroutine(eventDialog.GetComponent<EventDialog>().Nighttowndown2());
        }
    }

}
