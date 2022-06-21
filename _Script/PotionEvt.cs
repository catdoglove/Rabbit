using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionEvt : MonoBehaviour
{
    public Text ing1_txt, ing2_txt, ing3_txt, ing4_txt;
    public GameObject DayEnd_obj, DayEnding_obj;
    public GameObject endingBtnR_obj, endingBtnL_obj;
    public Text day_txt;
    public int pageNum_i;
    public GameObject page1_obj, page2_obj;
    public GameObject GM;
    
    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    public void SetText()
    {
    }
    
    //현재 넣어서 줄어든 재료 상태
    public void SetIng()
    {
        ing1_txt.text = "" + PlayerPrefs.GetInt("ingn1", 0);
        ing2_txt.text = "" + PlayerPrefs.GetInt("ingn2", 0);
        ing3_txt.text = "" + PlayerPrefs.GetInt("ingn3", 0);
        ing4_txt.text = "" + PlayerPrefs.GetInt("ingn4", 0);
    }

    //초기화해서 원래갯수로 돌아온 재료 상태
    public void ReIng()
    {
        ing1_txt.text = "" + PlayerPrefs.GetInt("ing1", 0);
        ing2_txt.text = "" + PlayerPrefs.GetInt("ing2", 0);
        ing3_txt.text = "" + PlayerPrefs.GetInt("ing3", 0);
        ing4_txt.text = "" + PlayerPrefs.GetInt("ing4", 0);
        PlayerPrefs.SetInt("ingn1", PlayerPrefs.GetInt("ing1", 6));
        PlayerPrefs.SetInt("ingn2", PlayerPrefs.GetInt("ing2", 6));
        PlayerPrefs.SetInt("ingn3", PlayerPrefs.GetInt("ing3", 6));
        PlayerPrefs.SetInt("ingn4", PlayerPrefs.GetInt("ing4", 6));
    }

    //포션에 넣어서 값을 저장한상태
    public void PutIng()
    {
        PlayerPrefs.SetInt("ing1", PlayerPrefs.GetInt("ingn1", 0));
        PlayerPrefs.SetInt("ing2", PlayerPrefs.GetInt("ingn2", 0));
        PlayerPrefs.SetInt("ing3", PlayerPrefs.GetInt("ingn3", 0));
        PlayerPrefs.SetInt("ing4", PlayerPrefs.GetInt("ingn4", 0));
        GM.GetComponent<MainBtnEvt>().CloseBox();
    }

    //하루가 지날때
    public void DayEnd()
    {
        if(PlayerPrefs.GetInt("dayint", 1) == 7)
        {

        }
        else
        {
            PlayerPrefs.SetInt("dayint", PlayerPrefs.GetInt("dayint", 1) + 1);
            DayEnd_obj.SetActive(true);
            day_txt.text = "" + PlayerPrefs.GetInt("dayint", 1);
        }
    }

    public void OKDayEnd()
    {
        DayEnd_obj.SetActive(false);
    }

    public void Ending()
    {
        DayEnding_obj.SetActive(true);
    }


    public void NextPage()
    {
        switch (pageNum_i)
        {
            case 0:
                endingBtnL_obj.SetActive(true);
                page1_obj.SetActive(false);
                page2_obj.SetActive(true);
                pageNum_i++;
                break;
            case 1:
                break;
            default:
                break;
        }
    }
    public void BackPage()
    {
        switch (pageNum_i)
        {
            case 0:
                break;
            case 1:
                endingBtnL_obj.SetActive(false);
                page1_obj.SetActive(true);
                page2_obj.SetActive(false);
                pageNum_i--;
                break;
            case 2:
                break;
            default:
                break;
        }

    }
}
