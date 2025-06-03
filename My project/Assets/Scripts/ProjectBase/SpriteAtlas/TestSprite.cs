using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSprite : MonoBehaviour
{
    public Image image0;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
    //图片账本
    List<Image> imageList = new List<Image>();
    //图片账本
    List<string> imageName = new List<string>();
    // Start is called before the first frame update
    void Start()
    {

        imageName.Add("beijing09_a");
        imageName.Add("beijing09_b");
        imageName.Add("beijing09_c");
        imageName.Add("beijing09_d");
        imageName.Add("beijing09_e");
        imageName.Add("beijing09_f");


        imageList.Add(image0);
        imageList.Add(image1);
        imageList.Add(image2);
        imageList.Add(image3);
        imageList.Add(image4);
        imageList.Add(image5);





        //image.sprite = SpriteAtlas.LoadSprite("ResImage/UIImages/UIImage", "StartGamebtn");
        for (int i = 0; i < imageName.Count; i++)
        {
            imageList[i].sprite = SpriteAtlas.LoadSprite("ResImage/UIImages/UIImage", imageName[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
