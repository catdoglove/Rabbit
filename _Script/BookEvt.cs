using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookEvt : MonoBehaviour
{
    public GameObject page1_obj, page2_obj, page3_obj, page4_obj, page5_obj;
    public GameObject Lbtn_obj, Rbtn_obj;
    public int page_i, end_i;

    public GameObject[] bookImg_obj, potionIngImg_obj;
    public Sprite[] potionImg_spr, potionIngImg_spr;
    public Text[] potion_txt, potionName_txt;
    public string[] potion_str, potionName_str;
    public GameObject[] q_obj, h_obj;
    // Start is called before the first frame update
    void Start()
    {
        setString();
        setData();
    }

    void setString()
    {
        potionName_str[0] = "식물 촉진";
        potion_str[0] = "잘 자라지 않는 식물을 빠르게 자랄 수 있도록 해주는 포션. 황폐해진 땅을 풍요롭게 만들 수 있다.";
        potionName_str[1] = "스트롱 마인드";
        potion_str[1] = "몸과 마음을 튼튼하게 해주는 포션. 나무를 한 손에 부술 수 있고 그 어떤 욕설에도 버틸 수 있다!";
        potionName_str[2] = "샤이닝 골드";
        potion_str[2] = "조금만 부어도 물체를 금으로 만들어버리는 탐욕의 포션. 과연 좋은 걸까?";
        potionName_str[3] = "클라우드";
        potion_str[3] = "비나 눈을 내리게 하는 포션. 아무 때나 눈 밭을 만들 수 있고 비를 내려 가뭄을 해결할 수 있다.";
        potionName_str[4] = "복슬 복슬";
        potion_str[4] = "온 몸에 털이 자라는 포션. 겨울에 사용 하면 따듯한 털을 가질 수 있다. 이제 추위는 안녕!";
        potionName_str[5] = "새벽의 달빛";
        potion_str[5] = "새벽의 빛을 품은 포션. 밤에 완성되는 신비한 약으로 불면증을 없앨 수 있다. 모두 좋은 꿈을 꾸길!";
        potionName_str[6] = "수중 호흡";
        potion_str[6] = "물 속에서 숨을 쉴 수 있도록 해주는 포션. 자유롭게 오랫동안 헤엄을 칠 수 있다.";
        potionName_str[7] = "타임 플러스";
        potion_str[7] = "시간을 절약할 수 있도록 해주는 포션. 1시간을 자도 10시간을 잔 것 같은 효과를 일으킨다.";
        potionName_str[8] = "플라윙";
        potion_str[8] = "날 수 있도록 날개를 만들어주는 포션. 사라질 때까지 마음껏 날 수 있다.";
        potionName_str[9] = "나비의 축복";
        potion_str[9] = "처음부터 원했던 포션. 각진 몸을 동그랗게 만들어 준다. 하지만 효과는 짧다.";
    }

    void setData()
    {
        for (int i = 0; i < 10; i++)
        {
            end_i = PlayerPrefs.GetInt("checkend"+i, 1);
            if (end_i == 1)
            {
                q_obj[i].SetActive(true);
                h_obj[i].SetActive(true);
            }
            else if (end_i == 2)
            {
                bookImg_obj[i].GetComponent<Image>().sprite = potionImg_spr[i];
                potionIngImg_obj[i].GetComponent<Image>().sprite = potionIngImg_spr[i];
                potion_txt[i].text = ""+ potion_str[i];
                potionName_txt[i].text = ""+ potionName_str[i];
                q_obj[i].SetActive(false);
                h_obj[i].SetActive(false);
            }
            else if (end_i == 0)
            {
                q_obj[i].SetActive(true);
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
                Lbtn_obj.SetActive(true);
                page2_obj.SetActive(false);
                page3_obj.SetActive(true);
                page_i++;
                break;
            case 2:
                Lbtn_obj.SetActive(true);
                page3_obj.SetActive(false);
                page4_obj.SetActive(true);
                page_i++;
                break;
            case 3:
                Lbtn_obj.SetActive(true);
                Rbtn_obj.SetActive(false);
                page4_obj.SetActive(false);
                page5_obj.SetActive(true);
                page_i++;
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
                Rbtn_obj.SetActive(true);
                break;
            case 2:
                page2_obj.SetActive(true);
                page3_obj.SetActive(false);
                page_i--;
                Rbtn_obj.SetActive(true);
                break;
            case 3:
                page3_obj.SetActive(true);
                page4_obj.SetActive(false);
                page_i--;
                Rbtn_obj.SetActive(true);
                break;
            case 4:
                page4_obj.SetActive(true);
                page5_obj.SetActive(false);
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
