using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvt : MonoBehaviour
{
    public AudioSource se_book, se_window, se_cat, se_cook, se_food, se_light, se_button, se_TV, se_sticker, se_bed, se_star, se_switch, se_spider, se_turn, se_ball, se_airplane, se_water, se_cancle, se_box, se_foods, se_talk, se_pencil;
    public AudioClip sp_book, sp_window, sp_cat, sp_cook, sp_food, sp_light, sp_button, sp_TV, sp_sticker, sp_bed, sp_star, sp_switch, sp_spider, sp_turn, sp_ball, sp_airplane, sp_water, sp_cancle, sp_box, sp_foods, sp_talk, sp_pencil;

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
    //티비
    public void TVSound()
    {
        se_TV = gameObject.GetComponent<AudioSource>();
        se_TV.clip = sp_TV;
        se_TV.loop = false;
        se_TV.Play();
    }
    //취소
    public void cancleSound()
    {
        se_cancle = gameObject.GetComponent<AudioSource>();
        se_cancle.clip = sp_cancle;
        se_cancle.loop = false;
        se_cancle.Play();
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
