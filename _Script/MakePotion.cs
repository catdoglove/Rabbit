using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePotion : MonoBehaviour
{

    public bool check;
    Vector2 pos;
    public Vector2 wldObjectPos;

    public GameObject ing_obj1, ing_obj2, ing_obj3, ing_obj4;
    public string name_str, num_str;

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
            transform.position = new Vector2(ing_obj1.transform.position.x,ing_obj1.transform.position.y);
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
        check = true;
        if (PlayerPrefs.GetInt("ing" + num_str, 0) != 0)
        {
            //check = true;
        }

    }//EndOfOnMouseDown

    public void OnMouseUp()
    {
        //소리를 불러오는 부분 나중에 할것
        //audio_obj = GameObject.Find("AudioSound");
        //audio_obj.GetComponent<SoundEvt>().stickerSound();

        if (PlayerPrefs.GetInt("ing" + num_str, 0) != 0)
        {
            if (wldObjectPos.x > -2.5 && wldObjectPos.x < 2.5)
            {
                if (wldObjectPos.y < 3.64 && wldObjectPos.y > -3.97)
                {

                    //PlayerPrefs.SetInt("ingn" + num_str, PlayerPrefs.GetInt("ing" + num_str, 0) - 1);
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
}
