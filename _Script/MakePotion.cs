using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePotion : MonoBehaviour
{

    public bool check;
    Vector2 pos;
    public Vector2 wldObjectPos;

    public GameObject ing_obj1, ing_obj2, ing_obj3, ing_obj4, ing_obj5, ing_obj6, ing_obj7, ing_obj8;
    public string name_str, num_str;
    public GameObject[] butter_obj;

    public GameObject GM;

    // Start is called before the first frame update
    void Start()
    {

        name_str = this.gameObject.name;
        num_str = "1";

        if (name_str.Substring(2, 1) == "2")
        {
            ing_obj1 = ing_obj2;
            num_str = "2";
        }
        if (name_str.Substring(2, 1) == "3")
        {
            ing_obj1 = ing_obj3;
            num_str = "3";
        }
        if (name_str.Substring(2, 1) == "4")
        {
            ing_obj1 = ing_obj4;
            num_str = "4";
        }
        if (name_str.Substring(2, 1) == "5")
        {
            ing_obj1 = ing_obj5;
            num_str = "5";
        }
        if (name_str.Substring(2, 1) == "6")
        {
            ing_obj1 = ing_obj6;
            num_str = "6";
        }
        if (name_str.Substring(2, 1) == "7")
        {
            ing_obj1 = ing_obj7;
            num_str = "7";
        }
        if (name_str.Substring(2, 1) == "8")
        {
            ing_obj1 = ing_obj8;
            num_str = "8";
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (check)
        {//카드를 드래그 하고있을때
            Vector2 mouseDragPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            wldObjectPos = Camera.main.ScreenToWorldPoint(mouseDragPos);
            transform.position = Vector2.MoveTowards(transform.position, wldObjectPos, 0.9f);
        }
        else
        {//EndOfIf
            transform.position = new Vector2(ing_obj1.transform.position.x, ing_obj1.transform.position.y);

            if (int.Parse(num_str) >= 5)
            {
                //transform.position = new Vector2(0f, 0f);
            }
        }
    }


    void OnMouseDown()
    {
        if (check)
        {

        }
        else
        {
        }
        if (int.Parse(num_str) >= 5)
        {

        }
        else if (PlayerPrefs.GetInt("ingn" + num_str, 0) > 0)
        {
            check = true;
        }

    }//EndOfOnMouseDown

    public void OnMouseUp()
    {
        //소리를 불러오는 부분 나중에 할것
        //audio_obj = GameObject.Find("AudioSound");
        //audio_obj.GetComponent<SoundEvt>().stickerSound();
        if (PlayerPrefs.GetInt("ing" + num_str, 0) != 0)
        {
            if (wldObjectPos.x > -1 && wldObjectPos.x < 1.1)
            {
                if (wldObjectPos.y < 0.4 && wldObjectPos.y > -3)
                {

                    if (int.Parse(num_str) >= 5)
                    {
                        PlayerPrefs.SetInt("butterin"+ num_str, 1);
                        GM.GetComponent<PotionEvt>().SetButterin();
                    }
                    else if (PlayerPrefs.GetInt("ingn" + num_str, 0) > 0)
                    {
                        PlayerPrefs.SetInt("ingn" + num_str, PlayerPrefs.GetInt("ingn" + num_str, 0) - 1);
                        GM.GetComponent<PotionEvt>().SetIng();
                        GM.GetComponent<PotionEvt>().SetIngColor(int.Parse(num_str)-1);
                    }
                }
            }
        }
        check = false;
    }
    
    void SetNum()
    {
        PlayerPrefs.SetInt("ing1", PlayerPrefs.GetInt("ingn1", 0));
        PlayerPrefs.SetInt("ing2", PlayerPrefs.GetInt("ingn2", 0));
        PlayerPrefs.SetInt("ing3", PlayerPrefs.GetInt("ingn3", 0));
        PlayerPrefs.SetInt("ing4", PlayerPrefs.GetInt("ingn4", 0));
    }



    void SetPotionColor()
    {
    }
}
