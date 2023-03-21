using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject player;

    public GameObject currybutton;
    public GameObject bibimbapbutton;
    public GameObject friedricebutton;
    public GameObject porkcutletbutton;
    public GameObject fridge;

    [SerializeField] private DialogSystem eattingDialog1day;

    private void Update()
    {
        if (player.GetComponent<PlayerStatus>().curry > 0)
        {
            currybutton.SetActive(true);
        }
        else if (player.GetComponent<PlayerStatus>().curry == 0)
        {
            currybutton.SetActive(false);
        }

        if (player.GetComponent<PlayerStatus>().bibimbap > 0)
        {
            bibimbapbutton.SetActive(true);
        }
        else if (player.GetComponent<PlayerStatus>().bibimbap == 0)
        {
            bibimbapbutton.SetActive(false);
        }

        if (player.GetComponent<PlayerStatus>().friedrice > 0)
        {
            friedricebutton.SetActive(true);
        }
        else if (player.GetComponent<PlayerStatus>().friedrice == 0)
        {
            friedricebutton.SetActive(false);
        }

        if (player.GetComponent<PlayerStatus>().porkcutlet > 0)
        {
            porkcutletbutton.SetActive(true);
        }
        else if (player.GetComponent<PlayerStatus>().porkcutlet == 0)
        {
            porkcutletbutton.SetActive(false);
        }

        if (player.GetComponent<PlayerStatus>().money < player.GetComponent<PlayerStatus>().curryAmount)
        {
            player.GetComponent<PlayerStatus>().currynumber = 0;
        }
        else if (player.GetComponent<PlayerStatus>().money < player.GetComponent<PlayerStatus>().bibimbapAmount)
        {
            player.GetComponent<PlayerStatus>().bibimbapnumber = 0;
        }
        else if (player.GetComponent<PlayerStatus>().money < player.GetComponent<PlayerStatus>().friedriceAmount)
        {
            player.GetComponent<PlayerStatus>().friedricenumber = 0;
        }
        else if (player.GetComponent<PlayerStatus>().money < player.GetComponent<PlayerStatus>().porkcutletAmount)
        {
            player.GetComponent<PlayerStatus>().porkcutletnumber = 0;
        }

    }

    public void FridgeButton()
    {
        fridge.SetActive(true);
    }
    public void ExitFridgeButton()
    {
        fridge.SetActive(false);
    }

    public void EattingCurry()
    {
        player.GetComponent<PlayerStatus>().curry--;
        player.GetComponent<PlayerStatus>().stress -= 20;
        StartCoroutine(Eatting());
    }
    public void Eattingbibimbap()
    {
        player.GetComponent<PlayerStatus>().bibimbap--;
        player.GetComponent<PlayerStatus>().stress -= 30;
        StartCoroutine(Eatting());
    }
    public void Eattingfriedrice()
    {
        player.GetComponent<PlayerStatus>().friedrice--;
        player.GetComponent<PlayerStatus>().stress -= 40;
        StartCoroutine(Eatting());
    }
    public void Eattingporkcutlet()
    {
        player.GetComponent<PlayerStatus>().porkcutlet--;
        player.GetComponent<PlayerStatus>().stress -= 50;
        StartCoroutine(Eatting());
    }

    public IEnumerator Eatting()
    {

        yield return new WaitUntil(() => eattingDialog1day.UpdateDialog());

    }

    // 상점버튼
    public void CurryPlus()
    {
        if (player.GetComponent<PlayerStatus>().money >= ((player.GetComponent<PlayerStatus>().currynumber + 1) * player.GetComponent<PlayerStatus>().curryAmount))
        {
            if (player.GetComponent<PlayerStatus>().currynumber < 9)
            {
                player.GetComponent<PlayerStatus>().currynumber++;
            }
        }

    }
    public void CurryMinus()
    {
        if (player.GetComponent<PlayerStatus>().currynumber > 0)
        {
            player.GetComponent<PlayerStatus>().currynumber--;
        }
    }
    public void CurryBuy()
    {
        player.GetComponent<PlayerStatus>().curry = player.GetComponent<PlayerStatus>().currynumber;
        player.GetComponent<PlayerStatus>().money = player.GetComponent<PlayerStatus>().money - (player.GetComponent<PlayerStatus>().currynumber * player.GetComponent<PlayerStatus>().curryAmount);
    }

    public void BibimbapPlus()
    {
        if (player.GetComponent<PlayerStatus>().money >= ((player.GetComponent<PlayerStatus>().bibimbapnumber + 1) * player.GetComponent<PlayerStatus>().bibimbapAmount))
        {
            if (player.GetComponent<PlayerStatus>().bibimbapnumber < 9)
            {
                player.GetComponent<PlayerStatus>().bibimbapnumber++;
            }
        }

    }
    public void BibimbapMinus()
    {
        if (player.GetComponent<PlayerStatus>().bibimbapnumber > 0)
        {
            player.GetComponent<PlayerStatus>().bibimbapnumber--;
        }
    }
    public void BibimbapBuy()
    {
        player.GetComponent<PlayerStatus>().bibimbap = player.GetComponent<PlayerStatus>().bibimbapnumber;
        player.GetComponent<PlayerStatus>().money = player.GetComponent<PlayerStatus>().money - (player.GetComponent<PlayerStatus>().bibimbapnumber * player.GetComponent<PlayerStatus>().bibimbapAmount);
    }

    public void FriedricePlus()
    {
        if (player.GetComponent<PlayerStatus>().money >= ((player.GetComponent<PlayerStatus>().friedricenumber + 1) * player.GetComponent<PlayerStatus>().friedriceAmount))
        {
            if (player.GetComponent<PlayerStatus>().friedricenumber < 9)
            {
                player.GetComponent<PlayerStatus>().friedricenumber++;
            }
        }
    }
    public void FriedriceMinus()
    {
        if (player.GetComponent<PlayerStatus>().friedricenumber > 0)
        {
            player.GetComponent<PlayerStatus>().friedricenumber--;
        }
    }
    public void FriedriceBuy()
    {
        player.GetComponent<PlayerStatus>().friedrice = player.GetComponent<PlayerStatus>().friedricenumber;
        player.GetComponent<PlayerStatus>().money = player.GetComponent<PlayerStatus>().money - (player.GetComponent<PlayerStatus>().friedricenumber * player.GetComponent<PlayerStatus>().friedriceAmount);
    }

    public void PorkcutletPlus()
    {
        if (player.GetComponent<PlayerStatus>().money >= ((player.GetComponent<PlayerStatus>().porkcutletnumber + 1) * player.GetComponent<PlayerStatus>().porkcutletAmount))
        {
            if (player.GetComponent<PlayerStatus>().porkcutletnumber < 9)
            {
                player.GetComponent<PlayerStatus>().porkcutletnumber++;
            }
        }
    }
    public void PorkcutletMinus()
    {
        if (player.GetComponent<PlayerStatus>().porkcutletnumber > 0)
        {
            player.GetComponent<PlayerStatus>().porkcutletnumber--;
        }
    }
    public void PorkcutletBuy()
    {
        player.GetComponent<PlayerStatus>().porkcutlet = player.GetComponent<PlayerStatus>().porkcutletnumber;
        player.GetComponent<PlayerStatus>().money = player.GetComponent<PlayerStatus>().money - (player.GetComponent<PlayerStatus>().porkcutletnumber * player.GetComponent<PlayerStatus>().porkcutletAmount);
    }

    
}
