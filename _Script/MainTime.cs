using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTime : MonoBehaviour
{
    //시간
    public int heart_i;
    public Text talkTime_txt, talkNum;
    string lastTime;

    public GameObject h1_obj, h2_obj, h3_obj;
    public Sprite h0_spr, h1_spr;

    
    // Use this for initialization
    void Start()
    {
        //대화
        StartCoroutine("talkTimeFlow");
        

        if (PlayerPrefs.GetInt("timefirst", 0)==0)
        {
            PlayerPrefs.SetString("TalkLastTime", System.DateTime.Now.ToString());
            PlayerPrefs.SetInt("timefirst", 1);
        }

    }

    
    //대화시간코루틴
    IEnumerator talkTimeFlow()
    {
        int minute;
        int sec;
        int a = 0;
        while (a == 0)
        {
            heart_i = PlayerPrefs.GetInt("hearti", 3);
            lastTime = PlayerPrefs.GetString("TalkLastTime", System.DateTime.Now.ToString());
            System.DateTime lastDateTime = System.DateTime.Parse(lastTime);
            System.TimeSpan compareTime = System.DateTime.Now - lastDateTime;
            if ((int)compareTime.TotalSeconds < 0)
            {
                compareTime = System.DateTime.Now - System.DateTime.Now;
            }
            minute = (int)compareTime.TotalMinutes;
            sec = (int)compareTime.TotalSeconds;
            sec = sec - (sec / 60) * 60;
            sec = 59 - sec;
            minute = 9 - minute;

            if (minute < 0)
            {
                while (minute < 0)
                {
                    minute = minute + 10;
                    if (heart_i >= 3)
                    {
                    }
                    else
                    {
                        heart_i++;
                    }
                }
                //시간을 중간부터 하기위해
                //PlayerPrefs.SetInt("timeminhelp", 4-minute);
                //PlayerPrefs.SetInt("timesechelp", 59-sec);
                //Debug.Log("minute" + minute+ "sec" + sec);
                //Debug.Log(""+System.DateTime.Now.ToString());
                PlayerPrefs.SetString("TalkLastTime", System.DateTime.Now.ToString());
                //talkTime_txt.text = "04:59";
            }
            else
            {
                string str = string.Format(@"{0:00}" + ":", minute) + string.Format(@"{0:00}", sec);
                talkTime_txt.text = "" + str;
            }

            //talkNum.text = heart_i.ToString();
            if (heart_i >= 3)
            {
                talkTime_txt.text = "00:00";
                //talkNum.text = heart_i.ToString();
            }
            PlayerPrefs.SetInt("hearti", heart_i);
            PlayerPrefs.Save();
            SetHeart();

            yield return new WaitForSeconds(0.1f);
        }
    }

    void SetHeart()
    {

        switch (heart_i)
        {
            case 0:
                h1_obj.GetComponent<Image>().sprite = h0_spr;
                h2_obj.GetComponent<Image>().sprite = h0_spr;
                h3_obj.GetComponent<Image>().sprite = h0_spr;
                break;
            case 1:
                h1_obj.GetComponent<Image>().sprite = h1_spr;
                h2_obj.GetComponent<Image>().sprite = h0_spr;
                h3_obj.GetComponent<Image>().sprite = h0_spr;
                break;
            case 2:
                h1_obj.GetComponent<Image>().sprite = h1_spr;
                h2_obj.GetComponent<Image>().sprite = h1_spr;
                h3_obj.GetComponent<Image>().sprite = h0_spr;
                break;
            case 3:
                h1_obj.GetComponent<Image>().sprite = h1_spr;
                h2_obj.GetComponent<Image>().sprite = h1_spr;
                h3_obj.GetComponent<Image>().sprite = h1_spr;
                break;
            default:
                break;
        }
    }
}
