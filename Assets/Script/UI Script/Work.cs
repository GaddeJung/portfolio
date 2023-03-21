using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Work : MonoBehaviour
{

    [SerializeField] private DialogSystem healthdialog1;
    [SerializeField] private DialogSystem pcdialog1;
    [SerializeField] private DialogSystem healthdialog2;
    [SerializeField] private DialogSystem pcdialog2;
    [SerializeField] private DialogSystem sleep;
    [SerializeField] private DialogSystem pocketMoney;
    [SerializeField] private DialogSystem firststart; 
    [SerializeField] private DialogSystem firstend;


    public GameObject gameManager;
    public GameObject calendar;
    public GameObject player;
    public GameObject birthButton;
    public GameObject birth;
    public GameObject eventdialog;
    public GameObject panel;


    public bool healthwork = false;
    public bool pcdwork = false;
    public bool sleepdwork = false;

    public GameObject Button;

    private void Start()
    {
        gameManager.GetComponent<MapMove>();
        calendar.GetComponent<Calendar>();
        player.GetComponent<PlayerStatus>();
    }

    public void SleepButton()
    {
        panel.SetActive(true);
        StartCoroutine(Sleep());
    }

    public void HealthButton()
    {
        if (player.GetComponent<PlayerStatus>().stress < player.GetComponent<PlayerStatus>().maxstress && calendar.GetComponent<Calendar>().time < 3)
        {
            panel.SetActive(true);
            healthwork = true;
            StartCoroutine(Health());

        }
    }
    public void PcroomButton()
    {
        if (player.GetComponent<PlayerStatus>().stress < player.GetComponent<PlayerStatus>().maxstress && calendar.GetComponent<Calendar>().time < 3)
        {
            panel.SetActive(true);
            StartCoroutine(Pcroom());

        }
    }
    private IEnumerator Sleep()
    {

        sleepdwork = true;

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => sleep.UpdateDialog());

        // 대사 분기 사이에 원하는 행동을 추가할 수 있다.
        // 캐릭터를 움직이거나 아이템을 획득하는 등의... 현재는 5-4-3-2-1 카운트다운 실행

        int count = 1;
        while (count > 0)
        {
            count--;

            yield return new WaitForSeconds(1);
        }

        Button.SetActive(true);

    }

    private IEnumerator Health()
    {

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => healthdialog1.UpdateDialog());

        // 대사 분기 사이에 원하는 행동을 추가할 수 있다.
        // 캐릭터를 움직이거나 아이템을 획득하는 등의... 현재는 5-4-3-2-1 카운트다운 실행

        int count = 1;
        while (count > 0)
        {
            count--;

            yield return new WaitForSeconds(1);
        }

        Button.SetActive(true);
    }
    private IEnumerator EndHealth()
    {


        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => healthdialog2.UpdateDialog());


    }

    private IEnumerator Pcroom()
    {

        pcdwork = true;

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => pcdialog1.UpdateDialog());

        // 대사 분기 사이에 원하는 행동을 추가할 수 있다.
        // 캐릭터를 움직이거나 아이템을 획득하는 등의... 현재는 5-4-3-2-1 카운트다운 실행

        int count = 1;
        while (count > 0)
        {
            count--;

            yield return new WaitForSeconds(1);
        }


        Button.SetActive(true);

    }
    private IEnumerator EndPcroom()
    {

        pcdwork = false;

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => pcdialog2.UpdateDialog());


    }
    public IEnumerator PocketMoney()
    {
        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => pocketMoney.UpdateDialog());

    }
    public IEnumerator FirstStart()
    {

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => firststart.UpdateDialog());
        birth.GetComponent<BirthDay>().buttonImage.SetActive(false);
    }

    public IEnumerator FirstEnd()
    {
        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => firstend.UpdateDialog());
        
        birthButton.SetActive(true);
    }

    public void NoButton()
    {
        Button.SetActive(false);
        panel.SetActive(false);
        healthwork = false;
        pcdwork = false;
        sleepdwork = false;
    }
    public void YesButton()
    {
        Button.SetActive(false);

        if (pcdwork == true )
        {
            StartCoroutine(EndPcroom());
            player.GetComponent<PlayerStatus>().money += 1000;
            calendar.GetComponent<Calendar>().time ++;
            player.GetComponent<PlayerStatus>().stress += 30;
        }

        else if (healthwork == true)
        {
            int eventrandom;

            eventrandom = Random.Range(1, 5);

            if (eventrandom == 1)
            {
                StartCoroutine(eventdialog.GetComponent<EventDialog>().gymEvent());
            }

            else
            {
                StartCoroutine(EndHealth());
            }
            player.GetComponent<PlayerStatus>().money += 1000;
            calendar.GetComponent<Calendar>().time++;
            player.GetComponent<PlayerStatus>().stress += 30;
            healthwork = false;
        }

        else if (sleepdwork == true)
        {
            gameManager.GetComponent<MapMove>().Sleep();
            player.GetComponent<PlayerStatus>().stress -= 30;
            calendar.GetComponent<Calendar>().day++;
            calendar.GetComponent<Calendar>().week++;
            calendar.GetComponent<Calendar>().time = 0;
        }

        panel.SetActive(false);

    }

}


