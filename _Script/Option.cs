using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public GameObject help_obj;
    public Sprite[] help_spr;
    public int h_i;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("firsthelp", 0)==0)
        {
            help_obj.SetActive(true);
            PlayerPrefs.SetInt("firsthelp", 1);
        }
        
    }


    public void ShowHelp()
    {

        help_obj.SetActive(true);

    }

    public void SetHelp()
    {

        if (h_i >= 4)
        {
            help_obj.SetActive(false);
            h_i = 0;
            help_obj.GetComponent<Image>().sprite = help_spr[0];
        }
        else
        {
            h_i++;
            help_obj.GetComponent<Image>().sprite = help_spr[h_i];
        }

    }

    public void showLink()
    {
        Application.OpenURL("https://forms.gle/7sHFXnCpbCDptaVD7");
    }
}
