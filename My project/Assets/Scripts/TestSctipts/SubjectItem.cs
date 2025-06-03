using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 题目模块
/// </summary>
public class SubjectItem : BasePanel
{
    Image image;
    // Start is called before the first frame update
    public void Start()
    {
       
        
    }
    //public void Inti(int tmp)
    //{
    //    GetControl<Text>("Item_N").text = tmp.ToString();
    //    //GetControl<Image>("SubjectItem_N").sprite = sprite;
    //}

    public void Inti(int tmp, Sprite sprite)
    {
        GetControl<Text>("Item_N").text = tmp.ToString();
        image = GetComponent<Image>();
        //Debug.Log(sprite.name);
        image.sprite = sprite;
    }

    public void SetColor(Color color)
    {
        GetControl<Image>("SubjectItem_N").color = color;
    }


}
