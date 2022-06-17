using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainBtnEvt : MonoBehaviour
{

    AsyncOperation async;
    public GameObject title_obj, option_obj, book_obj, goOut_obj, ingBox_obj;

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
    }

    public void CloseBox()
    {
        ingBox_obj.SetActive(false);
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
