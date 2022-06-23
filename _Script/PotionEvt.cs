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
    public GameObject end1_obj, end2_obj;
    public Sprite[] potion_spr, potionEnd1_spr, potionEnd2_spr;
    public Text end_txt, end2_txt;

    List<Dictionary<string, object>> data_end; //csv파일

    public Text dDay_txt;

    public int end_i;
    
    // Start is called before the first frame update
    void Start()
    {
        data_end = CSVReader.Read("CSV/ending");
        dDay_txt.text = "" + PlayerPrefs.GetInt("dayint", 1);
    }
    
    //빨초파노
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
        PlayerPrefs.SetInt("ingn1", PlayerPrefs.GetInt("ing1", 0));
        PlayerPrefs.SetInt("ingn2", PlayerPrefs.GetInt("ing2", 0));
        PlayerPrefs.SetInt("ingn3", PlayerPrefs.GetInt("ing3", 0));
        PlayerPrefs.SetInt("ingn4", PlayerPrefs.GetInt("ing4", 0));
    }

    //포션에 넣어서 값을 저장한상태
    public void PutIng()
    {
        PlayerPrefs.SetInt("useding1", PlayerPrefs.GetInt("useding1", 0) + PlayerPrefs.GetInt("ing1", 0) - PlayerPrefs.GetInt("ingn1", 0));
        PlayerPrefs.SetInt("useding2", PlayerPrefs.GetInt("useding2", 0) + PlayerPrefs.GetInt("ing2", 0) - PlayerPrefs.GetInt("ingn2", 0));
        PlayerPrefs.SetInt("useding3", PlayerPrefs.GetInt("useding3", 0) + PlayerPrefs.GetInt("ing3", 0) - PlayerPrefs.GetInt("ingn3", 0));
        PlayerPrefs.SetInt("useding4", PlayerPrefs.GetInt("useding4", 0) + PlayerPrefs.GetInt("ing4", 0) - PlayerPrefs.GetInt("ingn4", 0));


        PlayerPrefs.SetInt("ing1", PlayerPrefs.GetInt("ingn1", 0));
        PlayerPrefs.SetInt("ing2", PlayerPrefs.GetInt("ingn2", 0));
        PlayerPrefs.SetInt("ing3", PlayerPrefs.GetInt("ingn3", 0));
        PlayerPrefs.SetInt("ing4", PlayerPrefs.GetInt("ingn4", 0));
        GM.GetComponent<MainBtnEvt>().CloseBox();
        DayEnd();
    }

    //하루가 지날때
    public void DayEnd()
    {
        if(PlayerPrefs.GetInt("dayint", 1) == 7)
        {
            Ending();
        }
        else
        {
            PlayerPrefs.SetInt("dayint", PlayerPrefs.GetInt("dayint", 1) + 1);
            DayEnd_obj.SetActive(true);
            dDay_txt.text = "" + PlayerPrefs.GetInt("dayint", 1);
        }
    }

    public void OKDayEnd()
    {
        DayEnd_obj.SetActive(false);
    }

    public void Ending()
    {
        PlayerPrefs.SetInt("dayint", 1);
        int c = 0;
        int b = 0;
        int num = 1;

        c = PlayerPrefs.GetInt("useding1", 0);
        b= PlayerPrefs.GetInt("useding2", 0);
        if (b > c)
        {
            c = 0 + b;
            num = 2;
        }

        b = PlayerPrefs.GetInt("useding3", 0);
        if (b > c)
        {
            c = 0 + b;
            num = 3;
        }

        b = PlayerPrefs.GetInt("useding4", 0);
        if (b > c)
        {
            c = 0 + b;
            num = 4;
        }

        if (c > 10)
        {
            switch (num)
            {
                case 0:
                    break;
                case 1:
                    end1_obj.GetComponent<Image>().sprite = potion_spr[1];
                    end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[1];
                    end_i = 1;
                    end_txt.text = "" + data_end[0]["potion" + 2];
                    end2_txt.text = "" + data_end[1]["potion" + 2];
                    PlayerPrefs.SetInt("checkend" + 1, 2);
                    break;
                case 2:
                    end1_obj.GetComponent<Image>().sprite = potion_spr[0];
                    end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[0];
                    end_i = 0;
                    end_txt.text = "" + data_end[0]["potion" + 1];
                    end2_txt.text = "" + data_end[1]["potion" + 1];
                    PlayerPrefs.SetInt("checkend" + 0, 2);
                    break;
                case 3:
                    end1_obj.GetComponent<Image>().sprite = potion_spr[3];
                    end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[3];
                    end_i = 3;
                    end_txt.text = "" + data_end[0]["potion" + 4];
                    end2_txt.text = "" + data_end[1]["potion" + 4];
                    break;
                case 4:
                    end1_obj.GetComponent<Image>().sprite = potion_spr[2];
                    end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[2];
                    end_i = 2;
                    end_txt.text = "" + data_end[0]["potion" + 3];
                    end2_txt.text = "" + data_end[1]["potion" + 3];
                    break;
                default:
                    break;
            }
        }

        DayEnding_obj.SetActive(true);
        StopCoroutine("updateSec");
        StartCoroutine("updateSec");

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
                DayEnding_obj.SetActive(false);
                StopCoroutine("updateSec");
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




    IEnumerator updateSec()
    {
        int a = 0;
        int k = 0;
        while (a == 0)
        {

            switch (k)
            {
                case 0:
                    end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[end_i];
                    k++;
                    break;
                case 1:
                    end2_obj.GetComponent<Image>().sprite = potionEnd2_spr[end_i];
                    k++;
                    break;
                case 2:
                    end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[end_i];
                    k++;
                    break;
                case 3:
                    end2_obj.GetComponent<Image>().sprite = potionEnd2_spr[end_i];
                    k = 0;
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
