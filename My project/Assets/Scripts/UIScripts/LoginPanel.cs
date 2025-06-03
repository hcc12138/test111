using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    // Start is called before the first frame update
    void Start()
    {
        GetControl<Button>("Login_N").onClick.AddListener(()=> {

            SwitchScene.GetInstance().AsyncLoadScene("Main",null);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
