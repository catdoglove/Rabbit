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
    
    
    // Use this for initialization
    void Start()
    {
        //대화
        StartCoroutine("talkTimeFlow");

        /*
        if (talk >= 5)
        {
            PlayerPrefs.SetString("TalkLastTime", System.DateTime.Now.ToString());
        }
        */

    }

    
    //대화시간코루틴
    IEnumerator talkTimeFlow()
    {
        int minute;
        int sec;
        int a = 0;
        while (a == 0)
        {
            heart_i = PlayerPrefs.GetInt("hearti", 0);
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
            minute = 29 - minute;

            if (minute < 0)
            {
                while (minute < 0)
                {
                    minute = minute + 30;
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
            PlayerPrefs.SetInt("talk", heart_i);
            PlayerPrefs.Save();

            yield return new WaitForSeconds(0.1f);
        }
    }
}
