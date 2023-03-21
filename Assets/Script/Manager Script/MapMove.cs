using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMove : MonoBehaviour
{
    public GameObject map;
    public GameObject School;
    public GameObject House;
    public GameObject TalkWindow;
    public GameObject calendar;
    public GameObject player;
    public GameObject work;
    public GameObject panel;
    public GameObject option;

    int talk;
    public bool pocketmoney = true;


    public Text movetext;

    void Start()
    {

        School.SetActive(false);
        House.SetActive(false);
        map.SetActive(true);
    }

    void Update()
    {

        if (talk != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (talk)
                {
                    case 1:
                        TalkWindow.SetActive(false);
                        movetext.text = null;
                        School.SetActive(true);
                        map.SetActive(false);
                        talk = 0;
                        panel.SetActive(false);
                        break;
                    case 2:
                        TalkWindow.SetActive(false);
                        movetext.text = null;
                        House.SetActive(true);
                        map.SetActive(false);
                        talk = 0; 
                        panel.SetActive(false);
                        break;

                }

            }
        }


        if (pocketmoney == true)
        {
            if (calendar.GetComponent<Calendar>().week == 7)
            {
                panel.SetActive(true);
                player.GetComponent<PlayerStatus>().money += 5000;
                StartCoroutine(work.GetComponent<Work>().PocketMoney());
                pocketmoney = false;
                panel.SetActive(false);
            }
        }

        if (calendar.GetComponent<Calendar>().week == 1)
        {
            pocketmoney = true;
        }
    }

    public void Option()
    {
        option.SetActive(true);
    }

    public void ExitOption()
    {
        option.SetActive(false);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    void Talking()
    {
        switch (talk)
        {
            case 1:
                movetext.text = "학교를 간다.";
                break;
            case 2:
                movetext.text = "집을 간다.";
                break;

            case 3:
                movetext.text = "헬스에서 뭘할까";
                break;

            case 4:
                movetext.text = "PC방에서 뭘할까";
                break;
            case 5:
                movetext.text = "학교를 나간다.";
                break;
            case 6:
                movetext.text = "집을 나간다.";
                break;

        }
    }

    public void Sleep()
    {
        TalkWindow.SetActive(true);
        talk = 2;
        movetext.text = "아침이 되었다";
        panel.SetActive(false);
    }

    public void GoSchool()
    {
        panel.SetActive(true);
        TalkWindow.SetActive(true);
            talk = 1;
            Talking();
    }

    public void ExitSchool()
    {
        //TalkWindow.SetActive(true);
        School.SetActive(false);
        map.SetActive(true);
        talk = 0;
    }

    public void GoHouse()
    {
        panel.SetActive(true);
        TalkWindow.SetActive(true);
        talk = 2;
        Talking();

    }

    public void ExitHouse()
    {
        //TalkWindow.SetActive(true);
        House.SetActive(false);
        map.SetActive(true);
        talk = 0;
    }


}
