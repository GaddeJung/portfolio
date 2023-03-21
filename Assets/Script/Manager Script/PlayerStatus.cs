using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    // 스트레스 지수
    public int stress;
    public int maxstress;
    // 돈
    public int money;
    // 음식 갯수
    public int curry;
    public int bibimbap;
    public int friedrice;
    public int porkcutlet;

    // 구매할 때 음식 수량
    public int currynumber = 0;
    public int bibimbapnumber = 0;
    public int friedricenumber = 0;
    public int porkcutletnumber = 0;
    // 구매할 때 음식 금액
    public int curryAmount = 1000;
    public int bibimbapAmount = 2000;
    public int friedriceAmount = 3000;
    public int porkcutletAmount = 4000;

    Work work;

    public Text stresspoint;
    public Text moneyText;
    // 음식 수량 텍스트
    public Text currynumberText;
    public Text bibimbapnumberText;
    public Text friedricenumberText;
    public Text porkcutletnumberText;
    // 음식 금액 텍스트
    public Text curryAmountText;
    public Text bibimbapAmountText;
    public Text friedriceAmountText;
    public Text porkcutletAmountText;
    // 음식 갯수
    public Text curryNo;
    public Text bibimbapNo;
    public Text friedriceNo;
    public Text porkcutletNo;


    private void Update()
    {
        maxstress = 100;

        work = FindObjectOfType<Work>();

        stresspoint.text = (int)stress + "/" + (int)maxstress;

        moneyText.text = (int)money + " 원";

        currynumberText.text = (int)currynumber + "";
        bibimbapnumberText.text = (int)bibimbapnumber + "";
        friedricenumberText.text = (int)friedricenumber + "";
        porkcutletnumberText.text = (int)porkcutletnumber + "";

        curryAmountText.text = (int)curryAmount + " 원";
        bibimbapAmountText.text = (int)bibimbapAmount + " 원";
        friedriceAmountText.text = (int)friedriceAmount + " 원";
        porkcutletAmountText.text = (int)porkcutletAmount + " 원";

        curryNo.text = (int)curry + "";
        bibimbapNo.text = (int)bibimbap + "";
        friedriceNo.text = (int)friedrice + "";
        porkcutletNo.text = (int)porkcutlet + "";

        if (stress < 0)
        {
            stress = 0;
        }

        else if (stress > maxstress)
        {
            stress = maxstress;
        }
    }

    public void NumberClear()
    {
        currynumber = 0;
        bibimbapnumber = 0;
        friedricenumber = 0;
        porkcutletnumber = 0;
    }



}
