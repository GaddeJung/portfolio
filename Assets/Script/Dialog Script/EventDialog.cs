using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventDialog : MonoBehaviour
{
    // 스크립트
    public GameObject gameManager;
    public GameObject calendar;
    public GameObject schooling;
    public GameObject events;
    public GameObject player;

    // 버튼
    public GameObject yesNoButton;
    public GameObject exam1dayButton;
    public GameObject exam2dayButton;
    public GameObject exam3dayButton;
    public GameObject towndownbuyButton;

    // 이미지
    public GameObject schoolImage;
    public GameObject gymImage;
    public GameObject birthDayImage;
    public GameObject towndownImage;
    public GameObject nighttowndownImage;

    // 이벤트 다이얼로그
    public GameObject exam;
    public GameObject gym;
    public GameObject birth;
    public GameObject towndown;
    public GameObject nighttowndown;
    // 시험기간 이벤트
    [SerializeField] private DialogSystem examDialog1day;
    [SerializeField] private DialogSystem examDialog2day;
    [SerializeField] private DialogSystem examDialog3day;
    [SerializeField] private DialogSystem examDialogSuccess; 
    [SerializeField] private DialogSystem examDialogFail;
    [SerializeField] private DialogSystem examDialog4dayIfGood;
    [SerializeField] private DialogSystem examDialog4dayIfNormal;
    [SerializeField] private DialogSystem examDialog4dayIfbad;
    // 헬스장 이벤트
    [SerializeField] private DialogSystem gymDialog;
    [SerializeField] private DialogSystem gymDialogYes;
    [SerializeField] private DialogSystem gymDialogNo;
    // 생일 파티 이벤트
    [SerializeField] private DialogSystem birthDayDialog1;
    [SerializeField] private DialogSystem birthDayDialog2;
    // 낮 상점가 이벤트
    [SerializeField] private DialogSystem towndownDialog;
    [SerializeField] private DialogSystem towndownDialogNo;
    [SerializeField] private DialogSystem towndownDialogYes1;
    [SerializeField] private DialogSystem towndownDialogYes2;

    // 저녁 상점가 이벤트
    [SerializeField] private DialogSystem nighttowndownDialog1;
    [SerializeField] private DialogSystem nighttowndownDialog2;


    // 시험 랜덤

    // 시험기간 이벤트
    public IEnumerator Exam1day()
    {
        schoolImage.SetActive(true);
        exam.SetActive(true);

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => examDialog1day.UpdateDialog());

        exam1dayButton.SetActive(true);
    }
    public IEnumerator Exam2day()
    {
        schoolImage.SetActive(true);
        exam.SetActive(true);

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => examDialog2day.UpdateDialog());

        exam2dayButton.SetActive(true);
    }
    public IEnumerator Exam3day()
    {
        schoolImage.SetActive(true); 
        exam.SetActive(true);

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => examDialog3day.UpdateDialog());

        exam3dayButton.SetActive(true);
    }
    public IEnumerator Exam4day()
    {
        schoolImage.SetActive(true);
        exam.SetActive(true);
        int examrandom;

        examrandom = Random.Range(1, 3);

        switch (examrandom)
        {
            case 1 :
                yield return new WaitUntil(() => examDialog4dayIfGood.UpdateDialog());
                schooling.GetComponent<Schooling>().schoolpoint += 70;
                schoolImage.SetActive(false);
                break;
            case 2 :
                yield return new WaitUntil(() => examDialog4dayIfNormal.UpdateDialog());
                schooling.GetComponent<Schooling>().schoolpoint += 50;
                schoolImage.SetActive(false);
                break; 
            case 3 :
                yield return new WaitUntil(() => examDialog4dayIfbad.UpdateDialog());
                schooling.GetComponent<Schooling>().schoolpoint += 30;
                schoolImage.SetActive(false);
                break;
        }


    }
    
    // 생일 이벤트
    public IEnumerator BirthDay()
    {
        birth.SetActive(true);
        schoolImage.SetActive(true);
        yield return new WaitUntil(() => birthDayDialog1.UpdateDialog());
        schoolImage.SetActive(false);

        int count = 1;
        while (count > 0)
        {
            count--;

            yield return new WaitForSeconds(1);
        }


        birthDayImage.SetActive(true);
        yield return new WaitUntil(() => birthDayDialog2.UpdateDialog());
        birthDayImage.SetActive(false);

        calendar.GetComponent<Calendar>().time += 1;
        events.GetComponent<Event>().eventing = false;
        count = 2;
        while (count > 0)
        {
            count--;

            yield return new WaitForSeconds(1);
        }
        birth.SetActive(false);
    }

    // 시험중 버튼 누른 후 이벤트
    public IEnumerator ExamSuccess()
    {
        yield return new WaitUntil(() => examDialogSuccess.UpdateDialog());
        calendar.GetComponent<Calendar>().time += 2;
        schoolImage.SetActive(false);
        schooling.GetComponent<Schooling>().schoolpoint += 10;
        exam1dayButton.SetActive(false);
        exam2dayButton.SetActive(false);
        exam3dayButton.SetActive(false);
        exam.SetActive(false);
        events.GetComponent<Event>().eventing = false;
    }
    public IEnumerator ExamFail()
    {
        yield return new WaitUntil(() => examDialogFail.UpdateDialog());
        calendar.GetComponent<Calendar>().time += 2;
        schoolImage.SetActive(false);
        exam1dayButton.SetActive(false);
        exam2dayButton.SetActive(false);
        exam3dayButton.SetActive(false);
        exam.SetActive(false);
        events.GetComponent<Event>().eventing = false;

    }

    public IEnumerator gymEvent()
    {
        gym.SetActive(true);
        gymImage.SetActive(true);
        events.GetComponent<Event>().gyms = true;
        yield return new WaitUntil(() => gymDialog.UpdateDialog());
        yesNoButton.SetActive(true);
    }

    public IEnumerator GymYes()
    {
        yield return new WaitUntil(() => gymDialogYes.UpdateDialog());
        events.GetComponent<Event>().gyms = false;
        gym.SetActive(false);
        gymImage.SetActive(false);
    }
    public IEnumerator GymNo()
    {
        yield return new WaitUntil(() => gymDialogNo.UpdateDialog());
        events.GetComponent<Event>().gyms = false; 
        gym.SetActive(false); 
        gymImage.SetActive(false);
    }

    public IEnumerator Starttowndown()
    {
        towndown.SetActive(true);
        events.GetComponent<Event>().towndowns = true;
        yield return new WaitUntil(() => towndownDialog.UpdateDialog());
        yesNoButton.SetActive(true);

    }

    public IEnumerator Yestowndown1()
    {
        towndownImage.SetActive(true);
        yield return new WaitUntil(() => towndownDialogYes1.UpdateDialog());
        towndownbuyButton.SetActive(true);
    }
    public IEnumerator Yestowndown2()
    {
        yield return new WaitUntil(() => towndownDialogYes2.UpdateDialog());
        towndown.SetActive(false);
        events.GetComponent<Event>().towndowns = false;
        events.GetComponent<Event>().eventing = false;
        calendar.GetComponent<Calendar>().time++;
        towndownImage.SetActive(false);
        player.GetComponent<PlayerStatus>().NumberClear();
    }
    public IEnumerator Notowndown()
    {
        yield return new WaitUntil(() => towndownDialogNo.UpdateDialog());
        towndown.SetActive(false); 
        events.GetComponent<Event>().towndowns = false;
        events.GetComponent<Event>().eventing = false;
    }
    public IEnumerator Nighttowndown1()
    {
        nighttowndown.SetActive(true);
        events.GetComponent<Event>().nighttowndowns = true;
        nighttowndownImage.SetActive(true);
        yield return new WaitUntil(() => nighttowndownDialog1.UpdateDialog());
        towndownbuyButton.SetActive(true);
    }
    public IEnumerator Nighttowndown2()
    {
        yield return new WaitUntil(() => nighttowndownDialog2.UpdateDialog());
        nighttowndown.SetActive(false);
        events.GetComponent<Event>().nighttowndowns = false;
        events.GetComponent<Event>().eventing = false;
        nighttowndownImage.SetActive(false);
        player.GetComponent<PlayerStatus>().NumberClear();
    }

}
