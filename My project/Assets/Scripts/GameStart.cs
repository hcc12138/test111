using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //gunTools_Trans = GameObject.FindGameObjectWithTag("GunTools").GetComponent<Transform>();
        //SandParticle = gunTools_Trans.Find("MicroparticleGun/SandParticle").gameObject;
        //SteamParticle= gunTools_Trans.Find("HotSteamGun/SteamParticle").gameObject;
        //Fireline = gunTools_Trans.Find("LaserGun/Fireline").gameObject;

        //SandParticle.SetActive(false);
        //SteamParticle.SetActive(false);
        //Fireline.SetActive(false);


        


        //GameMapManager.GetInstance().Init(this);


        UIManager.GetInstance().ShowPanel<LoginPanel>("LoginPanel", E_UI_Layer.Mid);

        //GameDataMgr.GetInstance().Init();

       // GameMapManager.GetInstance().Init(this);


        DontDestroyOnLoad(this);

    }

 
}
