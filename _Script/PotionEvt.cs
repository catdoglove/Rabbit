using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionEvt : MonoBehaviour
{
    public Text ing1_txt, ing2_txt, ing3_txt, ing4_txt;
    public GameObject DayEnd_obj, DayEnding_obj;
    public GameObject endingBtnR_obj, endingBtnL_obj;
    public Text day_txt;
    public int pageNum_i;
    public GameObject page1_obj, page2_obj;
    public GameObject GM, GMS;
    public GameObject end1_obj, end2_obj;
    public Sprite[] potion_spr, potionEnd1_spr, potionEnd2_spr;
    public Text end_txt, end2_txt;

    public GameObject potionColor_obj, potionColorIng_obj;
    public Sprite[] potionColorIng_spr, potionColorIng2_spr;

    public Color color;

    public GameObject[] butterfly_obj, butterfly2_obj;
    public Sprite[] butterfly_spr, butterfly2_spr;

    public GameObject potionTaost_obj;

    List<Dictionary<string, object>> data_end; //csv파일

    public Text dDay_txt;

    public int end_i;

    public GameObject putingYN_obj;
    
    // Start is called before the first frame update
    void Start()
    {
        SetButter();
        StartCoroutine("updateImage");

        data_end = CSVReader.Read("CSV/ending");
        dDay_txt.text = "" + PlayerPrefs.GetInt("dayint", 1);
        SetColor();
    }
    
    //빨초파노
    //현재 넣어서 줄어든 재료 상태
    public void SetIng()
    {
        ing1_txt.text = "" + PlayerPrefs.GetInt("ingn1", 0);
        ing2_txt.text = "" + PlayerPrefs.GetInt("ingn2", 0);
        ing3_txt.text = "" + PlayerPrefs.GetInt("ingn3", 0);
        ing4_txt.text = "" + PlayerPrefs.GetInt("ingn4", 0);
        for (int i = 0; i < 4; i++)
        {
            if (PlayerPrefs.GetInt("butterin" + (i + 5), 0)==0)
            {
                butterfly2_obj[i].SetActive(false);
            }
            else
            {
                butterfly2_obj[i].SetActive(true);
            }
        }
    }

    //초기화해서 원래갯수로 돌아온 재료 상태
    public void ReIng()
    {
        ing1_txt.text = "" + PlayerPrefs.GetInt("ing1", 0);
        ing2_txt.text = "" + PlayerPrefs.GetInt("ing2", 0);
        ing3_txt.text = "" + PlayerPrefs.GetInt("ing3", 0);
        ing4_txt.text = "" + PlayerPrefs.GetInt("ing4", 0);
        PlayerPrefs.SetInt("ingn1", PlayerPrefs.GetInt("ing1", 0));
        PlayerPrefs.SetInt("ingn2", PlayerPrefs.GetInt("ing2", 0));
        PlayerPrefs.SetInt("ingn3", PlayerPrefs.GetInt("ing3", 0));
        PlayerPrefs.SetInt("ingn4", PlayerPrefs.GetInt("ing4", 0));
        PlayerPrefs.SetInt("checkingput", 0);
    }

    //포션에 넣어서 값을 저장한상태
    public void PutIng()
    {
        if (PlayerPrefs.GetInt("checkingput", 0) ==0)
        {
            potionTaost_obj.SetActive(true);
        }
        else
        {
            putingYN_obj.SetActive(true);
        }
    }


    public void SetButterin()
    {
        if (PlayerPrefs.GetInt("butterin5", 0)==1)
        {
            butterfly_obj[0].SetActive(false);
            butterfly2_obj[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt("butterin6", 0) == 1)
        {
            butterfly_obj[1].SetActive(false);
            butterfly2_obj[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("butterin7", 0) == 1)
        {
            butterfly_obj[2].SetActive(false);
            butterfly2_obj[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("butterin8", 0) == 1)
        {
            butterfly_obj[3].SetActive(false);
            butterfly2_obj[3].SetActive(true);
        }
    }

    public void ClosePoionToast()
    {
        potionTaost_obj.SetActive(false);
    }

    public void PutY()
    {
        putingYN_obj.SetActive(false);
        PlayerPrefs.SetInt("useding1", PlayerPrefs.GetInt("useding1", 0) + PlayerPrefs.GetInt("ing1", 0) - PlayerPrefs.GetInt("ingn1", 0));
        PlayerPrefs.SetInt("useding2", PlayerPrefs.GetInt("useding2", 0) + PlayerPrefs.GetInt("ing2", 0) - PlayerPrefs.GetInt("ingn2", 0));
        PlayerPrefs.SetInt("useding3", PlayerPrefs.GetInt("useding3", 0) + PlayerPrefs.GetInt("ing3", 0) - PlayerPrefs.GetInt("ingn3", 0));
        PlayerPrefs.SetInt("useding4", PlayerPrefs.GetInt("useding4", 0) + PlayerPrefs.GetInt("ing4", 0) - PlayerPrefs.GetInt("ingn4", 0));
        PlayerPrefs.SetInt("ing1", PlayerPrefs.GetInt("ingn1", 0));
        PlayerPrefs.SetInt("ing2", PlayerPrefs.GetInt("ingn2", 0));
        PlayerPrefs.SetInt("ing3", PlayerPrefs.GetInt("ingn3", 0));
        PlayerPrefs.SetInt("ing4", PlayerPrefs.GetInt("ingn4", 0));
        GM.GetComponent<MainBtnEvt>().CloseBox();
        SetColor();
        DayEnd();
        PlayerPrefs.SetInt("done", 0);
        PlayerPrefs.SetInt("checkingput", 0);
    }

    public void PutN()
    {
        putingYN_obj.SetActive(false);
    }


    //하루가 지날때
    public void DayEnd()
    {
        if(PlayerPrefs.GetInt("dayint", 1) == 7)
        {
            Ending();
            dDay_txt.text = "1";
        }
        else
        {
            PlayerPrefs.SetInt("dayint", PlayerPrefs.GetInt("dayint", 1) + 1);
            DayEnd_obj.SetActive(true);
            dDay_txt.text = "" + PlayerPrefs.GetInt("dayint", 1);
        }
    }

    public void OKDayEnd()
    {
        DayEnd_obj.SetActive(false);
    }

    public void Ending()
    {
        PlayerPrefs.SetInt("dayint", 1);
        int c = 0;
        int b = 0;
        int num = 1;
        int num2 = 1;
        int i1 = 0;
        int i2 = 0;

        c = PlayerPrefs.GetInt("useding1", 0);
        b= PlayerPrefs.GetInt("useding2", 0);
        if (b > c)
        {
            c = 0 + b;
            num = 2;
        }

        b = PlayerPrefs.GetInt("useding3", 0);
        if (b > c)
        {
            c = 0 + b;
            num = 3;
        }

        b = PlayerPrefs.GetInt("useding4", 0);
        if (b > c)
        {
            c = 0 + b;
            num = 4;
        }

        i1 = 0 + c;


        switch (num)
        {
            case 1:
                num2 = 2;
                c =  PlayerPrefs.GetInt("useding2", 0);
                b = PlayerPrefs.GetInt("useding3", 0);
                if (b > c)
                {
                    c = 0 + b;
                    num2 = 3;
                }

                b = PlayerPrefs.GetInt("useding4", 0);
                if (b > c)
                {
                    c = 0 + b;
                    num2 = 4;
                }
                i2 = 0 + c;
                break;
            case 2:
                num2 = 1;
                c = PlayerPrefs.GetInt("useding1", 0);
                b = PlayerPrefs.GetInt("useding3", 0);
                if (b > c)
                {
                    c = 0 + b;
                    num2 = 3;
                }

                b = PlayerPrefs.GetInt("useding4", 0);
                if (b > c)
                {
                    c = 0 + b;
                    num2 = 4;
                }
                i2 = 0 + c;
                break;
            case 3:
                num2 = 1;
                c = PlayerPrefs.GetInt("useding1", 0);
                b = PlayerPrefs.GetInt("useding2", 0);
                if (b > c)
                {
                    c = 0 + b;
                    num2 = 2;
                }

                b = PlayerPrefs.GetInt("useding4", 0);
                if (b > c)
                {
                    c = 0 + b;
                    num2 = 4;
                }
                i2 = 0 + c;
                break;
            case 4:
                num2 = 1;
                c = PlayerPrefs.GetInt("useding1", 0);
                b = PlayerPrefs.GetInt("useding2", 0);
                if (b > c)
                {
                    c = 0 + b;
                    num2 = 2;
                }

                b = PlayerPrefs.GetInt("useding3", 0);
                if (b > c)
                {
                    c = 0 + b;
                    num2 = 3;
                }
                i2 = 0 + c;
                break;
            default:
                break;
        }
        int numsave = num;
        if (num2 < num)
        {
            b = 0 + num;
            num = 0 + num2;
            num2 = 0 + b;
        }
        if (i2<4|| i2 < 4)
        {
            num2 = 0;
        }
        int endhelp_i = 0;

        if (PlayerPrefs.GetInt("butterin5", 0) == 1)
        {
            endhelp_i++;
        }
        if (PlayerPrefs.GetInt("butterin6", 0) == 1)
        {
            endhelp_i++;
        }
        if (PlayerPrefs.GetInt("butterin7", 0) == 1)
        {
            endhelp_i++;
        }
        if (PlayerPrefs.GetInt("butterin8", 0) == 1)
        {
            endhelp_i++;
        }
        if (PlayerPrefs.GetInt("useding1", 0) > 1)
        {
            endhelp_i++;
        }
        if (PlayerPrefs.GetInt("useding2", 0) > 1)
        {
            endhelp_i++;
        }
        if (PlayerPrefs.GetInt("useding3", 0) > 1)
        {
            endhelp_i++;
        }
        if (PlayerPrefs.GetInt("useding4", 0) > 1)
        {
            endhelp_i++;
        }

        if (endhelp_i == 8)
        {
            end1_obj.GetComponent<Image>().sprite = potion_spr[9];
            end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[9];
            end_i = 9;
            end_txt.text = "" + data_end[0]["potion" + 10];
            end2_txt.text = "" + data_end[1]["potion" + 10];
            PlayerPrefs.SetInt("checkend" + 9, 2);
        }
        else
        {


            //빨초파노
            if (num == 1 && num2 == 4)
            {
                end1_obj.GetComponent<Image>().sprite = potion_spr[4];
                end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[4];
                end_i = 4;
                end_txt.text = "" + data_end[0]["potion" + 5];
                end2_txt.text = "" + data_end[1]["potion" + 5];
                PlayerPrefs.SetInt("checkend" + 4, 2);
            }
            else if (num == 3 && num2 == 4)
            {
                end1_obj.GetComponent<Image>().sprite = potion_spr[5];
                end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[5];
                end_i = 5;
                end_txt.text = "" + data_end[0]["potion" + 6];
                end2_txt.text = "" + data_end[1]["potion" + 6];
                PlayerPrefs.SetInt("checkend" + 5, 2);
            }
            else if (num == 1 && num2 == 3)
            {
                end1_obj.GetComponent<Image>().sprite = potion_spr[6];
                end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[6];
                end_i = 6;
                end_txt.text = "" + data_end[0]["potion" + 7];
                end2_txt.text = "" + data_end[1]["potion" + 7];
                PlayerPrefs.SetInt("checkend" + 6, 2);
            }
            else if (num == 2 && num2 == 3)
            {
                end1_obj.GetComponent<Image>().sprite = potion_spr[7];
                end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[7];
                end_i = 7;
                end_txt.text = "" + data_end[0]["potion" + 8];
                end2_txt.text = "" + data_end[1]["potion" + 8];
                PlayerPrefs.SetInt("checkend" + 7, 2);
            }
            else if (num == 2 && num2 == 4)
            {
                end1_obj.GetComponent<Image>().sprite = potion_spr[8];
                end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[8];
                end_i = 8;
                end_txt.text = "" + data_end[0]["potion" + 9];
                end2_txt.text = "" + data_end[1]["potion" + 9];
                PlayerPrefs.SetInt("checkend" + 8, 2);
            }
            else
            {
                switch (numsave)
                {
                    case 0:
                        break;
                    case 1:
                        end1_obj.GetComponent<Image>().sprite = potion_spr[1];
                        end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[1];
                        end_i = 1;
                        end_txt.text = "" + data_end[0]["potion" + 2];
                        end2_txt.text = "" + data_end[1]["potion" + 2];
                        PlayerPrefs.SetInt("checkend" + 1, 2);
                        break;
                    case 2:
                        end1_obj.GetComponent<Image>().sprite = potion_spr[0];
                        end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[0];
                        end_i = 0;
                        end_txt.text = "" + data_end[0]["potion" + 1];
                        end2_txt.text = "" + data_end[1]["potion" + 1];
                        PlayerPrefs.SetInt("checkend" + 0, 2);
                        break;
                    case 3:
                        end1_obj.GetComponent<Image>().sprite = potion_spr[3];
                        end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[3];
                        end_i = 3;
                        end_txt.text = "" + data_end[0]["potion" + 4];
                        end2_txt.text = "" + data_end[1]["potion" + 4];
                        PlayerPrefs.SetInt("checkend" + 3, 2);
                        break;
                    case 4:
                        end1_obj.GetComponent<Image>().sprite = potion_spr[2];
                        end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[2];
                        end_i = 2;
                        end_txt.text = "" + data_end[0]["potion" + 3];
                        end2_txt.text = "" + data_end[1]["potion" + 3];
                        PlayerPrefs.SetInt("checkend" + 2, 2);
                        break;
                    default:
                        break;
                }
            }
        }

        DayEnding_obj.SetActive(true);
        endingBtnL_obj.SetActive(false);
        page1_obj.SetActive(true);
        page2_obj.SetActive(false);
        pageNum_i = 0;

        GMS.GetComponent<SoundEvt>().SetEnd();

        StopCoroutine("updateSec");
        StartCoroutine("updateSec");
        SetReSet();
    }

    void SetReSet()
    {
        for (int i = 1; i < 5; i++)
        {
            PlayerPrefs.SetInt("useding"+i, 0);
            PlayerPrefs.SetInt("ing" + i, 0);
            PlayerPrefs.SetInt("ingn" + i, 0);
            PlayerPrefs.SetInt("Butterfly" + i, 0);
            PlayerPrefs.SetInt("butterin" + (i+4), 0);
        }
        PlayerPrefs.SetInt("ingcolor", 0);
        PlayerPrefs.SetInt("done", 0);
        potionColor_obj.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
        potionColorIng_obj.SetActive(false);
        PlayerPrefs.Save();
    }

    public void SetButter()
    {
        //장소 코드 0:숲, 1:물, 2:동굴, 3:용암
        for (int i = 1; i < 5; i++)
        {
            if (PlayerPrefs.GetInt("Butterfly"+i, 0) == 1)
            {
                butterfly_obj[i-1].SetActive(true);
            }
            else
            {
                butterfly_obj[i-1].SetActive(false);
            }
        }
    }


    //빨초파노

    /// <summary>
    /// 포션색깔
    /// </summary>
    public void SetColor()
    {
        int cp = 0;
        int bp = 0;
        int nump = 1;

        cp = PlayerPrefs.GetInt("useding1", 0);
        if (cp == 0)
        {
            nump = 0;
        }
        bp= PlayerPrefs.GetInt("useding2", 0);
        if (bp > cp)
        {
            cp = 0 + bp;
            nump = 2;
        }
        bp = PlayerPrefs.GetInt("useding3", 0);
        if (bp > cp)
        {
            cp = 0 + bp;
            nump = 3;
        }
        bp = PlayerPrefs.GetInt("useding4", 0);
        if (bp > cp)
        {
            cp = 0 + bp;
            nump = 4;
        }
        switch (nump)
        {
            case 1:
                potionColor_obj.GetComponent<Image>().color = new Color(255f / 255f, 92f / 255f, 90f / 255f);
                break;
            case 2:
                potionColor_obj.GetComponent<Image>().color = new Color(181f / 255f, 235f / 255f, 41f / 255f);
                break;
            case 3:
                potionColor_obj.GetComponent<Image>().color = new Color(41f / 255f, 196f / 255f, 233f / 255f);
                break;
            case 4:
                potionColor_obj.GetComponent<Image>().color = new Color(233f / 255f, 170f / 255f, 41f / 255f);
                break;
            default:
                potionColor_obj.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
                break;
        }
    }

    public void SetIngColor(int nump)
    {
        potionColorIng_obj.SetActive(true);
        potionColorIng_obj.GetComponent<Image>().sprite = potionColorIng_spr[nump];
        PlayerPrefs.SetInt("ingcolor", nump);
    }


    public void NextPage()
    {
        switch (pageNum_i)
        {
            case 0:
                endingBtnL_obj.SetActive(true);
                page1_obj.SetActive(false);
                page2_obj.SetActive(true);
                pageNum_i++;
                break;
            case 1:
                DayEnding_obj.SetActive(false);
                GM.GetComponent<MainBtnEvt>().OpenTitle();
                StopCoroutine("updateSec");
                GMS.GetComponent<SoundEvt>().SetOri();
                break;
            default:
                break;
        }
    }
    public void BackPage()
    {
        switch (pageNum_i)
        {
            case 0:
                break;
            case 1:
                endingBtnL_obj.SetActive(false);
                page1_obj.SetActive(true);
                page2_obj.SetActive(false);
                pageNum_i--;
                break;
            case 2:
                break;
            default:
                break;
        }

    }




    IEnumerator updateSec()
    {
        int a = 0;
        int k = 0;
        while (a == 0)
        {

            switch (k)
            {
                case 0:
                    end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[end_i];
                    k++;
                    break;
                case 1:
                    end2_obj.GetComponent<Image>().sprite = potionEnd2_spr[end_i];
                    k++;
                    break;
                case 2:
                    end2_obj.GetComponent<Image>().sprite = potionEnd1_spr[end_i];
                    k++;
                    break;
                case 3:
                    end2_obj.GetComponent<Image>().sprite = potionEnd2_spr[end_i];
                    k = 0;
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }


    IEnumerator updateImage()
    {
        int a = 0;
        int k = 0;
        while (a == 0)
        {

            switch (k)
            {
                case 0:
                    potionColorIng_obj.GetComponent<Image>().sprite = potionColorIng_spr[PlayerPrefs.GetInt("ingcolor", 0)];
                    butterfly_obj[0].GetComponent<Image>().sprite = butterfly_spr[0];
                    butterfly_obj[1].GetComponent<Image>().sprite = butterfly_spr[1];
                    butterfly_obj[2].GetComponent<Image>().sprite = butterfly_spr[2];
                    butterfly_obj[3].GetComponent<Image>().sprite = butterfly_spr[3];
                    k++;
                    break;
                case 1:
                    potionColorIng_obj.GetComponent<Image>().sprite = potionColorIng2_spr[PlayerPrefs.GetInt("ingcolor", 0)];
                    butterfly_obj[0].GetComponent<Image>().sprite = butterfly2_spr[0];
                    butterfly_obj[1].GetComponent<Image>().sprite = butterfly2_spr[1];
                    butterfly_obj[2].GetComponent<Image>().sprite = butterfly2_spr[2];
                    butterfly_obj[3].GetComponent<Image>().sprite = butterfly2_spr[3];
                    k = 0;
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
