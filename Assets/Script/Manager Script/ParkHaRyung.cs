using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ParkHaRyung : MonoBehaviour
{

    [SerializeField] private DialogSystem dialogSystem01;
    public GameObject paly;
    public GameObject UI;
    public GameObject calendar;
    public GameObject panel;

    private void Update()
    {
        
    }

    public void Button()
    {
        StartCoroutine(Talking());
    }


    IEnumerator Talking()
    {
        panel.SetActive(true);
        paly.SetActive(true);
        UI.SetActive(false);

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

        // 대사 분기 사이에 원하는 행동을 추가할 수 있다.
        // 캐릭터를 움직이거나 아이템을 획득하는 등의... 현재는 5-4-3-2-1 카운트다운 실행

        UI.SetActive(true);
        calendar.GetComponent<Calendar>().time++; 
        panel.SetActive(false);
    }
}
