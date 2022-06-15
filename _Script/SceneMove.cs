using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{

    AsyncOperation async;
    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator LoadMain()
    {
        async = SceneManager.LoadSceneAsync("Main");
        while (!async.isDone)
        {
            yield return true;
        }
    }

    IEnumerator LoadSub()
    {
        async = SceneManager.LoadSceneAsync("Sub");
        while (!async.isDone)
        {
            yield return true;
        }
    }

    public void CheckWhereGo()
    {
        switch (PlayerPrefs.GetInt("whereisit", 0))
        {
            case 0:
                StartCoroutine(LoadMain());
                break;
            case 1:
                StartCoroutine(LoadSub());
                break;
            case 2:
                StartCoroutine(LoadSub());
                break;
            case 3:
                StartCoroutine(LoadSub());
                break;
            default:
                break;
        }
    }
}
