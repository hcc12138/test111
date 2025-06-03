using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : BasePanel
{
    private float fgWidth;

    public override void ShowMe()
    {
        base.ShowMe();

        //fgWidth = GetControl<Image>("imgfg_N").GetComponent<RectTransform>().sizeDelta.x;
        //GetControl<Text>("txtPrg_N").text = "0";
        //GetControl<Image>("imgfg_N").fillAmount = 0;
        //GetControl<Image>("imgPoint_N").transform.localPosition = new Vector3(-660f, 0, 0);

        //EventCenter.GetInstance().EventTrigger<LoadingPanel>("进度设置", this);


        //GetControl<Slider>("LoadingSlider_N").value = fgWidth;



    }

    //设置进度
    public void SetProgress(float prg)
    {
        GetControl<Text>("Loadingtxt_N").text = (int)(prg * 100) + "%";

        GetControl<Slider>("LoadingSlider_N").value = prg;


        //Debug.Log(prg);
        //GetControl<Image>("imgfg_N").fillAmount = prg;
        //Debug.Log("prg:" + prg);
        //float posX = prg * fgWidth - 660;

        //GetControl<Image>("imgPoint_N").GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, 0);

    }


    public void SetSlider()
    {

         GetControl<Slider>("LoadingSlider_N").value = 1;

    }




}
