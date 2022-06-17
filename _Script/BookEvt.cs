using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookEvt : MonoBehaviour
{
    public GameObject page1_obj, page2_obj, page3_obj;
    public GameObject Lbtn_obj, Rbtn_obj;
    public int page_i, end_i;

    public GameObject[] bookImg_obj, potionIngImg_obj;
    public Sprite[] potionImg_spr;
    public Text[] potion_txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setData()
    {
        for (int i = 0; i < 5; i++)
        {
            end_i = PlayerPrefs.GetInt("checkend"+i, 0);
            if (end_i == 1)
            {
                bookImg_obj[i].GetComponent<Image>().sprite = potionImg_spr[1];
                potion_txt[i].text = "";
            }
            else if (end_i == 2)
            {
                bookImg_obj[i].GetComponent<Image>().sprite = potionImg_spr[2];
                potion_txt[i].text = "";
            }
        }
        
    }
    
    public void NextPage()
    {
        switch (page_i)
        {
            case 0:
                Lbtn_obj.SetActive(true);
                page1_obj.SetActive(false);
                page2_obj.SetActive(true);
                page_i++;
                break;
            case 1:
                Rbtn_obj.SetActive(false);
                page2_obj.SetActive(false);
                page3_obj.SetActive(true);
                page_i++;
                break;
            case 2:
                break;
            default:
                break;
        }
    }
    public void BackPage()
    {
        switch (page_i)
        {
            case 0:
                break;
            case 1:
                Lbtn_obj.SetActive(false);
                page1_obj.SetActive(true);
                page2_obj.SetActive(false);
                page_i--;
                break;
            case 2:
                page2_obj.SetActive(true);
                page3_obj.SetActive(false);
                page_i--;
                Rbtn_obj.SetActive(true);
                break;
            default:
                break;
        }

    }


    public void ShowHint()
    {

    }
}
