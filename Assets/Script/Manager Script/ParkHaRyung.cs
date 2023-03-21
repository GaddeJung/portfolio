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

        // ù ��° ��� �б� ����
        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

        // ��� �б� ���̿� ���ϴ� �ൿ�� �߰��� �� �ִ�.
        // ĳ���͸� �����̰ų� �������� ȹ���ϴ� ����... ����� 5-4-3-2-1 ī��Ʈ�ٿ� ����

        UI.SetActive(true);
        calendar.GetComponent<Calendar>().time++; 
        panel.SetActive(false);
    }
}
