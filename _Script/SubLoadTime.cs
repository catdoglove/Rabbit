using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubLoadTime : MonoBehaviour
{
    public GameObject rabbit_obj, Loading_obj;
    public Sprite[] rabbit_spr, Loading_spr;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("updateSec");
    }
    
    
    IEnumerator updateSec()
    {
        int a = 0;
        int k=0;
        while (a == 0)
        {

            switch (k)
            {
                case 0:
                    rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[0];
                    Loading_obj.GetComponent<Image>().sprite = Loading_spr[0];
                    k++;
                    break;
                case 1:
                    rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[1];
                    Loading_obj.GetComponent<Image>().sprite = Loading_spr[1];
                    k++;
                    break;
                case 2:
                    rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[2];
                    Loading_obj.GetComponent<Image>().sprite = Loading_spr[2];
                    k++;
                    break;
                case 3:
                    rabbit_obj.GetComponent<Image>().sprite = rabbit_spr[3];
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
