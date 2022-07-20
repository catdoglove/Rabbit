using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainBtnEvt : MonoBehaviour
{

    AsyncOperation async;
    public GameObject title_obj, option_obj, book_obj, goOut_obj, ingBox_obj, rabbit_obj;
    public GameObject[] check_obj;
    public int check_i;
    public GameObject GM;

    public GameObject toast_obj, toast2_obj, ads_obj, adsToast_obj;
    public GameObject gameClose_obj;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        check_i = 0;
        PlayerPrefs.SetInt("whereisit", 5);
        if (PlayerPrefs.GetInt("closetile", 0) == 1)
        {
            title_obj.SetActive(false);
        }
        StartCoroutine("moverabbit");
    }

    IEnumerator moverabbit()
    {
        PlayerPrefs.SetInt("moverabbit", 0);
        y = rabbit_obj.transform.position.y;

        int aa = 0;
        while (aa == 0)
        {

            y = y + 0.05f;
            aa++;
            rabbit_obj.transform.position = new Vector3(rabbit_obj.transform.position.x, y, rabbit_obj.transform.position.z);
            yield return new WaitForSeconds(1f);

            if (aa == 1)
            {
                y = y - 0.05f;
                aa--;
                rabbit_obj.transform.position = new Vector3(rabbit_obj.transform.position.x, y, rabbit_obj.transform.position.z);
                yield return new WaitForSeconds(1f);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameClose_obj.SetActive(true);
        }
    }

    public void closeY()
    {
        Application.Quit();
    }
    public void closeN()
    {
        gameClose_obj.SetActive(false);
    }

    public void showInfoLink()
    {
        Application.OpenURL("https://docs.google.com/document/d/1JFdyCym-5Kxns2xcA-w8W5ir5YiL4J-6JrJeMF8zcuk/edit?usp=sharing");
    }

    public void CloseTitle()
    {
        title_obj.SetActive(false);
        PlayerPrefs.SetInt("closetile",1);
    }
    public void OpenTitle()
    {
        title_obj.SetActive(true);
    }

    public void OpenOption()
    {
        option_obj.SetActive(true);
    }

    public void CloseOption()
    {
        option_obj.SetActive(false);
    }

    public void OpenBook()
    {
        GM.GetComponent<BookEvt>().setData();
        book_obj.SetActive(true);
        GM.GetComponent<BookEvt>().SetPageNum();
    }

    public void CloseBook()
    {
        book_obj.SetActive(false);
    }
    public void OpenGoOut()
    {
        if (PlayerPrefs.GetInt("done", 0) == 1)
        {
            toast_obj.SetActive(true);
        }
        else
        {
            goOut_obj.SetActive(true);

            check_i = 0;
            CheckOff();
            check_obj[0].SetActive(true);
            PlayerPrefs.SetInt("whereisitck", 0);
        }
    }

    public void CloseToast()
    {
        toast_obj.SetActive(false);
        toast2_obj.SetActive(false);
    }

    public void CloseGoOut()
    {
        goOut_obj.SetActive(false);
    }

    public void OpenBox()
    {
        ingBox_obj.SetActive(true);
        PlayerPrefs.SetInt("ingn1", PlayerPrefs.GetInt("ing1", 0));
        PlayerPrefs.SetInt("ingn2", PlayerPrefs.GetInt("ing2", 0));
        PlayerPrefs.SetInt("ingn3", PlayerPrefs.GetInt("ing3", 0));
        PlayerPrefs.SetInt("ingn4", PlayerPrefs.GetInt("ing4", 0));
        GM.GetComponent<PotionEvt>().SetButter();
        GM.GetComponent<PotionEvt>().SetButterin();
        GM.GetComponent<PotionEvt>().SetIng();
    }

    public void CloseBox()
    {
        PlayerPrefs.SetInt("ingn1", PlayerPrefs.GetInt("ing1", 0));
        PlayerPrefs.SetInt("ingn2", PlayerPrefs.GetInt("ing2", 0));
        PlayerPrefs.SetInt("ingn3", PlayerPrefs.GetInt("ing3", 0));
        PlayerPrefs.SetInt("ingn4", PlayerPrefs.GetInt("ing4", 0));
        ingBox_obj.SetActive(false);
        PlayerPrefs.SetInt("checkingput", 0);
    }

    //숲
    public void OutCheck1()
    {
        check_i = 0;
        CheckOff();
        check_obj[0].SetActive(true);
        PlayerPrefs.SetInt("whereisitck", 0);
    }
    //용암
    public void OutCheck2()
    {
        check_i = 3;
        CheckOff();
        check_obj[1].SetActive(true);
        PlayerPrefs.SetInt("whereisitck", 3);
    }
    //동굴
    public void OutCheck3()
    {
        check_i = 2;
        CheckOff();
        check_obj[2].SetActive(true);
        PlayerPrefs.SetInt("whereisitck", 2);
    }
    //폭포
    public void OutCheck4()
    {
        check_i = 1;
        CheckOff();
        check_obj[3].SetActive(true);
        PlayerPrefs.SetInt("whereisitck", 1);
    }

    void CheckOff()
    {
        check_obj[0].SetActive(false);
        check_obj[1].SetActive(false);
        check_obj[2].SetActive(false);
        check_obj[3].SetActive(false);
    }

    public void GoOut()
    {
        //테스트
        if (PlayerPrefs.GetInt("hearti", 3) > 0)
        {
            StartCoroutine("LoadSub");
            PlayerPrefs.SetInt("whereisit", check_i);
            PlayerPrefs.SetInt("hearti", PlayerPrefs.GetInt("hearti", 3) - 1);
        }
        else
        {
            ads_obj.SetActive(true);
        }
    }

    public void CloseAds()
    {
        ads_obj.SetActive(false);
    }

    public void AdToast()
    {
        adsToast_obj.SetActive(true);
    }
    public void AdToastClose()
    {
        adsToast_obj.SetActive(false);
    }

    IEnumerator LoadSub()
    {
        async = SceneManager.LoadSceneAsync("SubLoad");
        while (!async.isDone)
        {
            yield return true;
        }
    }
}
