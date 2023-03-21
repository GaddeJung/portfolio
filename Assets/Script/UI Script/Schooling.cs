using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schooling : MonoBehaviour
{
    public GameObject parkButton;
    public GameObject kimButton;

    public GameObject calendar;

    public int schoolpoint = 0;

    private void Update()
    {
        if (calendar.GetComponent<Calendar>().time == 3)
        {
            parkButton.SetActive(false);
            kimButton.SetActive(false);
        }

        else if (calendar.GetComponent<Calendar>().time != 3)
        {
            parkButton.SetActive(true);
            kimButton.SetActive(true);
        }
    }

}
