using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubLoadTime : MonoBehaviour
{
    public GameObject rabbit_obj, Loading_obj, rabbitback_obj;
    public Sprite[] rabbit_spr, Loading_spr;
    // Start is called before the first frame update
    void Start()
    {
        if((PlayerPrefs.GetInt("whereisit", 0) == 5))
        {
            StartCoroutine("updateSec2");
        }
        else
        {
            StartCoroutine("updateSec");
        }

        Debug.Log(PlayerPrefs.GetInt("whereisitck", 0));
    }


    /*
     
                    else if (PlayerPrefs.GetInt("whereisit", 0) == 5)
                    {
                        rabbitback_obj.SetActive(true);
                        rabbit_obj.SetActive(false);
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[0];
                    }
     */






    IEnumerator updateSec2()
    {
        int a = 0;
        int k = 0;
        //PlayerPrefs.GetInt("whereisit", 0) //장소 코드 0:숲, 1:물, 2:동굴, 3:용암

        while (a == 0)
        {
            rabbitback_obj.SetActive(true);
            rabbit_obj.SetActive(false);

            switch (k)
            {
                case 0:
                    if (PlayerPrefs.GetInt("whereisitck", 0) == 0)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[0];
                    }
                    else if (PlayerPrefs.GetInt("whereisitck", 0) == 1)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[4];
                    }
                    else if (PlayerPrefs.GetInt("whereisitck", 0) == 2)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[8];
                    }
                    else if (PlayerPrefs.GetInt("whereisitck", 0) == 3)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[12];
                    }
                    Loading_obj.GetComponent<Image>().sprite = Loading_spr[0];
                    k++;
                    break;
                case 1:
                    if (PlayerPrefs.GetInt("whereisitck", 0) == 0)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[1];
                    }
                    else if (PlayerPrefs.GetInt("whereisitck", 0) == 1)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[5];
                    }
                    else if (PlayerPrefs.GetInt("whereisitck", 0) == 2)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[9];
                    }
                    else if (PlayerPrefs.GetInt("whereisitck", 0) == 3)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[13];
                    }
                    Loading_obj.GetComponent<Image>().sprite = Loading_spr[1];
                    k++;
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("whereisitck", 0) == 0)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[2];
                    }
                    else if (PlayerPrefs.GetInt("whereisitck", 0) == 1)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[6];
                    }
                    else if (PlayerPrefs.GetInt("whereisitck", 0) == 2)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[10];
                    }
                    else if (PlayerPrefs.GetInt("whereisitck", 0) == 3)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[14];
                    }
                    Loading_obj.GetComponent<Image>().sprite = Loading_spr[2];
                    k++;
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("whereisitck", 0) == 0)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[3];
                    }
                    else if (PlayerPrefs.GetInt("whereisitck", 0) == 1)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[7];
                    }
                    else if (PlayerPrefs.GetInt("whereisitck", 0) == 2)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[11];
                    }
                    else if (PlayerPrefs.GetInt("whereisitck", 0) == 3)
                    {
                        rabbitback_obj.GetComponent<Image>().sprite = rabbit_spr[15];
                    }
                    Loading_obj.GetComponent<Image>().sprite = Loading_spr[3];
                    k = 0;
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }










    IEnumerator updateSec()
    {
        int a = 0;
        int k=0;
        //PlayerPrefs.GetInt("whereisit", 0) //장소 코드 0:숲, 1:물, 2:동굴, 3:용암

        while (a == 0)
        {
            rabbitback_obj.SetActive(false);
            rabbit_obj.SetActive(true);

            switch (k)
            {
                case 0:
                    if(PlayerPrefs.GetInt("whereisit", 0) == 0)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[0];
                    }else if(PlayerPrefs.GetInt("whereisit", 0) == 1)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[4];
                    }
                    else if (PlayerPrefs.GetInt("whereisit", 0) == 2)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[8];
                    }
                    else if (PlayerPrefs.GetInt("whereisit", 0) == 3)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[12];
                    }
                    Loading_obj.GetComponent<Image>().sprite = Loading_spr[0];
                    k++;
                    break;
                case 1:
                    if (PlayerPrefs.GetInt("whereisit", 0) == 0)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[1];
                    }
                    else if (PlayerPrefs.GetInt("whereisit", 0) == 1)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[5];
                    }
                    else if (PlayerPrefs.GetInt("whereisit", 0) == 2)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[9];
                    }
                    else if (PlayerPrefs.GetInt("whereisit", 0) == 3)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[13];
                    }
                    Loading_obj.GetComponent<Image>().sprite = Loading_spr[1];
                    k++;
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("whereisit", 0) == 0)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[2];
                    }
                    else if (PlayerPrefs.GetInt("whereisit", 0) == 1)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[6];
                    }
                    else if (PlayerPrefs.GetInt("whereisit", 0) == 2)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[10];
                    }
                    else if (PlayerPrefs.GetInt("whereisit", 0) == 3)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[14];
                    }
                    Loading_obj.GetComponent<Image>().sprite = Loading_spr[2];
                    k++;
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("whereisit", 0) == 0)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[3];
                    }
                    else if (PlayerPrefs.GetInt("whereisit", 0) == 1)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[7];
                    }
                    else if (PlayerPrefs.GetInt("whereisit", 0) == 2)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[11];
                    }
                    else if (PlayerPrefs.GetInt("whereisit", 0) == 3)
                    {
                        rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[15];
                    }
                    Loading_obj.GetComponent<Image>().sprite = Loading_spr[3];
                    k = 0;
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    
}
