using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvt : MonoBehaviour
{
    public AudioSource se_button, se_day, se_get, se_help;
    public AudioClip sp_button, sp_day, sp_get, sp_help;

    public AudioSource BGM, BGS,se_put;
    public AudioClip sp_end, sp_ori, sp_put;
    float BGMVol_f, BGSVol_f;
    // Use this for initialization
    void Start()
    {
    }
    
    //버튼
    public void buttonSound()
    {
        se_button = gameObject.GetComponent<AudioSource>();
        se_button.clip = sp_button;
        se_button.loop = false;
        se_button.Play();
    }

    //하루지남
    public void daySound()
    {
        se_day = gameObject.GetComponent<AudioSource>();
        se_day.clip = sp_day;
        se_day.loop = false;
        se_day.Play();
    }

    //재료얻음
    public void getSound()
    {
        se_get = gameObject.GetComponent<AudioSource>();
        se_get.clip = sp_get;
        se_get.loop = false;
        se_get.Play();
    }


    //재료얻음
    public void helpSound()
    {
        se_help = gameObject.GetComponent<AudioSource>();
        se_help.clip = sp_help;
        se_help.loop = false;
        se_help.Play();
    }
    //포션놓기
    public void PutSound()
    {
        se_put = gameObject.GetComponent<AudioSource>();
        se_put.clip = sp_put;
        se_put.loop = false;
        se_put.Play();
    }

    //엔딩
    public void SetEnd()
    {
        BGM.clip = sp_end;
        BGM.loop = false;
        BGM.Play();
    }

    //엔딩
    public void SetOri()
    {
        BGM.clip = sp_ori;
        BGM.loop = false;
        BGM.Play();
    }
}
