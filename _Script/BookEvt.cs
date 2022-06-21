﻿using System.Collections;
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
    public Text[] potion_txt, potionName_txt;
    public string[] potion_str, potionName_str;
    // Start is called before the first frame update
    void Start()
    {
        setString();
        setData();
    }

    void setString()
    {
        potionName_str[0] = "스트롱 마인드";
        potion_str[0] = "몸과 마음을 튼튼하게 해주는 포션. 나무를 한 손에 부술 수 있고 그 어떤 욕설에도 버틸 수 있다!";
        potionName_str[1] = "식물 촉진";
        potion_str[1] = "잘 자라지 않는 식물을 빠르게 자랄 수 있도록 해주는 포션. 황폐해진 땅을 풍요롭게 만들 수 있다.";
        potionName_str[2] = "클라우드";
        potion_str[2] = "비나 눈을 내리게 하는 포션. 아무 때나 눈 밭을 만들 수 있고 비를 내려 가뭄을 해결할 수 있다.";
        potionName_str[3] = "샤이닝 골드";
        potion_str[3] = "조금만 부어도 물체를 금으로 만들어버리는 탐욕의 포션. 과연 좋은 걸까?";
        potionName_str[4] = "타임 플러스";
        potion_str[4] = "시간을 절약할 수 있도록 해주는 포션. 1시간을 자도 10시간을 잔 것 같은 효과를 일으킨다.";


    }

    void setData()
    {
        for (int i = 0; i < 4; i++)
        {
            end_i = PlayerPrefs.GetInt("checkend"+i, 2);
            if (end_i == 1)
            {
            }
            else if (end_i == 2)
            {
                bookImg_obj[i].GetComponent<Image>().sprite = potionImg_spr[i];
                potion_txt[i].text = ""+ potion_str[i];
                potionName_txt[i].text = ""+ potionName_str[i];
            }
            else if (end_i == 0)
            {

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
