using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{
    [SerializeField] private DialogSystem dialogSystem01;
    [SerializeField] private DialogSystem dialogSystem02;
    public GameObject paly;

    private IEnumerator Start()
    {
        paly.SetActive(true);

        // ù ��° ��� �б� ����
        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

        // ��� �б� ���̿� ���ϴ� �ൿ�� �߰��� �� �ִ�.
        // ĳ���͸� �����̰ų� �������� ȹ���ϴ� ����... ����� 5-4-3-2-1 ī��Ʈ�ٿ� ����

        int count = 5;
        while (count > 0)
        {
            count--;

            yield return new WaitForSeconds(1);
        }




    }

}
