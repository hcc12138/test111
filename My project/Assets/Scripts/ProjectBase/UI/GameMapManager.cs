using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMapManager : BaseManager<GameMapManager>
{

    #region
    /*
    //加载场景完成回调
    public Action LoadSceneOverCallBack;

    //加载场景开始回调
    public Action LoadSceneEnterCallBack;


    //当前场景
    public string CurrenMapName { get; set; }


    //场景加载是否完成
    public bool AlreadyLoadScene { get; set; }

    //切换场景的进度条
    public static int LoadingProgress = 0;

    MonoBehaviour m_Mono;
    /// <summary>
    /// 场景管理初始化
    /// </summary>
    /// <param name="mono"></param>
    public void Init(MonoBehaviour mono)
    {
        m_Mono = mono;
    }



    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="name">场景名</param>
    public void LoadScene(string name)
    {
        LoadingProgress = 0;
        m_Mono.StartCoroutine(LoadSceneAsyne(name));
    }


    /// <summary>
    /// 设置场景环境（相机位置，物体设置，参数改变）
    /// </summary>
    /// <param name="name"></param>
    private void SetSceneSetting(string name)
    {

        //设置各种场景环境，根据配表来
    }

    IEnumerator LoadSceneAsyne(string name)
    {

        if (LoadSceneEnterCallBack!=null)
        {
            LoadSceneEnterCallBack();
        }



        ClearCache();
        AlreadyLoadScene = false;
        //卸载
        AsyncOperation unloafScene=SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);//单个场景加载模式
        while (unloafScene!=null && !unloafScene.isDone)
        {
            yield return new WaitForEndOfFrame();//每帧都等
        }
        LoadingProgress = 0;
        int targetProgress = 0;
        //加载
        AsyncOperation asyncScene = SceneManager.LoadSceneAsync(name);
        if (asyncScene!=null && !asyncScene.isDone)
        {
            asyncScene.allowSceneActivation = false;//没加载完，不允许显示出来
            while (asyncScene.progress < 0.9f)
            {

                targetProgress = (int)asyncScene.progress * 100;
                yield return new WaitForEndOfFrame();
                //平滑过渡
                while (LoadingProgress< targetProgress)
                {
                    ++LoadingProgress;
                    yield return new WaitForEndOfFrame();
                }

            }


            CurrenMapName = name;
            SetSceneSetting(name);

            //自行加载剩余的10%
            targetProgress = 100;


            while (LoadingProgress < targetProgress -2)
            {
                ++LoadingProgress;
                yield return new WaitForEndOfFrame();
            }


            LoadingProgress = 100;
            asyncScene.allowSceneActivation = true;//加载完，显示出来
            AlreadyLoadScene = true;

            if (LoadSceneOverCallBack != null)
            {
                LoadSceneOverCallBack();
            }

        }



    }


    //条场景需要清除的东西
    private void ClearCache()
    {
        //ObjectManager.Instance.ClearCache();
        //ResourceManager.Instance.ClearCache();


    }



    */
    #endregion

    public Slider slider;
    public Text text;


    //加载场景完成回调
    //public Action LoadSceneEnterCallBack = null;

    MonoBehaviour m_Mono;
    /// <summary>
    /// 场景管理初始化
    /// </summary>
    /// <param name="mono"></param>
    public void Init(MonoBehaviour mono)
    {
        m_Mono = mono;
    }

    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="name">场景名</param>
    public void LoadScene(string name,UnityAction fun)
    {
       
        m_Mono.StartCoroutine(LoadSceneAsyne(name, fun));
    }


    IEnumerator LoadSceneAsyne(string name, UnityAction fun)
    {


        //if (LoadSceneEnterCallBack != null)
        //{
        //    LoadSceneEnterCallBack();
        //}

        //打开LoadingPanel
        UIManager.GetInstance().ShowPanel<LoadingPanel>("LoadingPanel", E_UI_Layer.Top);
        AsyncOperation asyncScene = SceneManager.LoadSceneAsync(name);

        asyncScene.allowSceneActivation = false;//没加载完，不允许显示出来


        while (asyncScene != null && !asyncScene.isDone)
        {

            UIManager.GetInstance().TackUIPanel<LoadingPanel>("LoadingPanel").SetProgress(asyncScene.progress);

            //Debug.Log(asyncScene.progress);
            //slider.value = asyncScene.progress;
            //text.text = asyncScene.progress * 100 + "%";

            if (asyncScene.progress>=0.9f)
            {
                UIManager.GetInstance().TackUIPanel<LoadingPanel>("LoadingPanel").SetSlider();
                asyncScene.allowSceneActivation = true;

               
            }


            yield return new WaitForEndOfFrame();//每帧都等
        }

        if (fun != null)
        {
            fun();
        }



        UIManager.GetInstance().HidePanle("LoadingPanel");


        yield return null;
    }




}
