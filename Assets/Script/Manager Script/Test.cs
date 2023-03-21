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

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

        // 대사 분기 사이에 원하는 행동을 추가할 수 있다.
        // 캐릭터를 움직이거나 아이템을 획득하는 등의... 현재는 5-4-3-2-1 카운트다운 실행

        int count = 5;
        while (count > 0)
        {
            count--;

            yield return new WaitForSeconds(1);
        }




    }

}
