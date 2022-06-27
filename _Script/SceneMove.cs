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
        CheckWhereGo();
    }

    IEnumerator LoadMain()
    {
        yield return new WaitForSeconds(2f);
        async = SceneManager.LoadSceneAsync("Main");
        while (!async.isDone)
        {
            yield return true;
        }
    }

    IEnumerator LoadSub()
    {
        yield return new WaitForSeconds(2f);
        async = SceneManager.LoadSceneAsync("Sub");
        while (!async.isDone)
        {
            yield return true;
        }
    }

    //장소 코드 0:숲, 1:물, 2:동굴, 3:용암
    public void CheckWhereGo()
    {
        switch (PlayerPrefs.GetInt("whereisit", 0))
        {
            case 5:
                StartCoroutine(LoadMain());
                break;
            case 0:
                StartCoroutine(LoadSub());
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
            case 4:
                StartCoroutine(LoadSub());
                break;
            default:
                StartCoroutine(LoadMain());
                break;
        }
    }
}
