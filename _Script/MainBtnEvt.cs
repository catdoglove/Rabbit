using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainBtnEvt : MonoBehaviour
{

    AsyncOperation async;
    public GameObject title_obj, option_obj, book_obj, goOut_obj, ingBox_obj;
    public GameObject[] check_obj;
    public int check_i=0;
    public GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
    }
    


    public void CloseTitle()
    {
        title_obj.SetActive(false);
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
        book_obj.SetActive(true);
    }

    public void CloseBook()
    {
        book_obj.SetActive(false);
    }
    public void OpenGoOut()
    {
        goOut_obj.SetActive(true);
    }

    public void CloseGoOut()
    {
        goOut_obj.SetActive(false);
    }

    public void OpenBox()
    {
        ingBox_obj.SetActive(true);
        PlayerPrefs.SetInt("ingn1", PlayerPrefs.GetInt("ing1", 6));
        PlayerPrefs.SetInt("ingn2", PlayerPrefs.GetInt("ing2", 6));
        PlayerPrefs.SetInt("ingn3", PlayerPrefs.GetInt("ing3", 6));
        PlayerPrefs.SetInt("ingn4", PlayerPrefs.GetInt("ing4", 6));
        GM.GetComponent<PotionEvt>().SetIng();
    }

    public void CloseBox()
    {
        ingBox_obj.SetActive(false);
    }

    //숲
    public void OutCheck1()
    {
        check_i = 0;
        CheckOff();
        check_obj[0].SetActive(true);
    }
    //용암
    public void OutCheck2()
    {
        check_i = 1;
        CheckOff();
        check_obj[1].SetActive(true);
    }
    //동굴
    public void OutCheck3()
    {
        check_i = 2;
        CheckOff();
        check_obj[2].SetActive(true);
    }
    //폭포
    public void OutCheck4()
    {
        check_i = 3;
        CheckOff();
        check_obj[3].SetActive(true);
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
        StartCoroutine(LoadSub());
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
