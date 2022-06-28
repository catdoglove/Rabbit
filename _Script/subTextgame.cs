using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; //랜덤필
using UnityEngine.SceneManagement;

public class subTextgame : MonoBehaviour
{
    AsyncOperation async;
    List<Dictionary<string, object>> data_talk; //csv파일
    public Text Text_obj; //선언 및 보여질
    string text_str; //실질적 대사출력
    string[] text_cut; //대사 끊기
    int areaCode; //장소 코드 0:숲, 1:물, 2:동굴, 3:용암
    int randArr, nextNum, randNum, martialCount;
    public GameObject areaImg,quesAreaBtn,basicBtn, martialimg, butterflyImg, resultWnd, resultMartial, resultButterfly;
    public Sprite[] areaImgs, martialImgs, butterflyImgs;
    public Text btnTxt1, btnTxt2; //질문버튼 텍스트
    public Text resultTotal; //질문버튼 텍스트



    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("getButterfly", 0);
        PlayerPrefs.SetInt("martialCount", 0);
        data_talk = CSVReader.Read("CSV/subtext");

        areaCode = PlayerPrefs.GetInt("whereisit", 0);

        nextNum = 0;
        randomNum();

    }

    void randomNum()
    {
        switch (areaCode)
        {
            case 0:
                randArr = Random.Range(0, 5); //0~(line_txt-1)
                areaImgSet();
                break;
            case 1:
                randArr = Random.Range(5, 10);
                areaImgSet();
                break;
            case 2:
                randArr = Random.Range(10, 15);
                areaImgSet();
                break;
            case 3:
                randArr = Random.Range(15, 20);
                areaImgSet();
                break;
        }
    }

    void areaImgSet()
    {
        areaImg.GetComponent<Image>().sprite = areaImgs[areaCode];
        martialimg.GetComponent<Image>().sprite = martialImgs[areaCode];
        butterflyImg.GetComponent<Image>().sprite = butterflyImgs[areaCode];
        resultMartial.GetComponent<Image>().sprite = martialImgs[areaCode];
        resultButterfly.GetComponent<Image>().sprite = butterflyImgs[areaCode];
    }

    void cleanTalk() //대화 초기화
    {
        quesAreaBtn.SetActive(false);
        basicBtn.SetActive(false);
        Text_obj.text = "";
        text_str = "";
    }

    void showTalk()
    {
        if (nextNum == 3)
        {
            butterflyEvt();//나비이벤트발동
        }
        text_str = "" + data_talk[randArr]["area"+ nextNum]; //문장넣기 0~9
        text_cut = text_str.Split('/'); //끊기
        
        if (text_cut[0] == "9")
        {
            quesAreaBtn.SetActive(true);
            Text_obj.text = text_cut[1];
            if (text_str.Contains("8"))
            {
                string str, str2;
                str = text_str.Substring(text_str.IndexOf("8") + 1, 5);
                btnTxt1.text = str;
                str2 = text_str.Substring(text_str.IndexOf("7") + 1, 5);
                btnTxt2.text = str2;
            }
        }
        else
        {
            basicBtn.SetActive(true);
            Text_obj.text = text_str;

            nextNum++;
        }
        getMartial();
    }

    //대답영역
    public void answerBtn1()
    {
        text_str = "" + data_talk[randArr]["area" + nextNum]; //문장넣기 0~9
        text_cut = text_str.Split('/'); //끊기

        if (text_cut[4].Contains("재료"))
        {
            Debug.Log("4얻");
            martialimg.SetActive(true);
            martialCount++;
            PlayerPrefs.SetInt("martialCount", martialCount);
        }

        if (text_cut[3] == "6")
        {
            basicBtn.SetActive(true);
            Text_obj.text = text_cut[4];
        }
        quesAreaBtn.SetActive(false);
        nextNum++;

    }
    public void answerBtn2()
    {
        text_str = "" + data_talk[randArr]["area" + nextNum]; //문장넣기 0~9
        text_cut = text_str.Split('/'); //끊기


        if (text_cut[6].Contains("재료"))
        {
            Debug.Log("6얻");
            martialimg.SetActive(true);
            martialCount++;
            PlayerPrefs.SetInt("martialCount", martialCount);
        }

        if (text_cut[5] == "5")
        {
            basicBtn.SetActive(true);
            Text_obj.text = text_cut[6];
        }
        quesAreaBtn.SetActive(false);
        nextNum++;

    }


    public void showText()
    {
        if (nextNum == 5)
        {
            showResultWnd();//모험종료
        }
        else
        {
            randomNum();
            cleanTalk();
            showTalk();
        }
    }

    void getMartial () //재료 얻는 이벤트
    {
        if (text_cut[0] == "9")
        {
            //질문부분은 따로 추가
        }
        else
        {
            if (text_str.Contains("재료"))
            {
                Debug.Log("ㅅㅅㅅ");
                martialimg.SetActive(true);
                martialCount++;
                PlayerPrefs.SetInt("martialCount", martialCount);
            }
        }

    }

    void butterflyEvt()//나비 획득 이벤트
    {
        randNum = Random.Range(0, 3); //0~(line_txt-1)

        int c = 0;
        switch (areaCode)
        {
            case 0:
                c = 2;
                break;
            case 1:
                c = 3;
                break;
            case 2:
                c = 4;
                break;
            case 3:
                c = 1;
                break;
            default:
                break;
        }

        if (PlayerPrefs.GetInt("Butterfly" + c, 0) == 1)
        {
            nextNum++;
        }
        else
        {
            if (randNum == 1)
            {
                butterflyImg.SetActive(true);
                PlayerPrefs.SetInt("getButterfly", 999);
            }
            else
            {
                Debug.Log("넘어감");
                nextNum++;
            }
        }
    }

    void showResultWnd()
    {
        PlayerPrefs.SetInt("done", 1);
        resultWnd.SetActive(true);
        resultTotal.text = PlayerPrefs.GetInt("martialCount", 0).ToString() ;
        if(PlayerPrefs.GetInt("getButterfly", 0) == 999)
        {
            resultButterfly.SetActive(true);
        }
    }
    public void returnHome()
    {
        //장소 코드 0:숲, 1:물, 2:동굴, 3:용암
        //빨초파노
        int c = 0;
        switch (areaCode)
        {
            case 0:
                c = 2;
                break;
            case 1:
                c = 3;
                break;
            case 2:
                c = 4;
                break;
            case 3:
                c = 1;
                break;
            default:
                break;
        }

        PlayerPrefs.SetInt("ing" + c, PlayerPrefs.GetInt("ing" + c, 0)+PlayerPrefs.GetInt("martialCount", 0));
        if (PlayerPrefs.GetInt("getButterfly", 0) == 999)
        {
            PlayerPrefs.SetInt("Butterfly" + c, 1);
        }
        StartCoroutine("LoadMain");
        PlayerPrefs.SetInt("whereisit", 5);
    }
    public void doubleReward()
    {
        Debug.Log("보상두배");
    }


    IEnumerator LoadMain()
    {
        async = SceneManager.LoadSceneAsync("SubLoad");
        while (!async.isDone)
        {
            yield return true;
        }
    }
}
