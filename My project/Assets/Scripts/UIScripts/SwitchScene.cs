using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : BaseManager<SwitchScene>
{

    public SwitchScene()
    {
        //EventCenter.GetInstance().AddEventListener<LoadingPanel>("进度设置", ProgressShow);

        MonoMgr.GetInstance().AddUpdateListener(() =>
        {

            if (proCB != null)
            {
                proCB();
            }

        });


    }

    //更新数据的回调
    Action proCB = null;

    float val;
    //异步加载场景
    public void AsyncLoadScene(string Name, Action loadend)
    {
        UIManager.GetInstance().ShowPanel<LoadingPanel>("LoadingPanel", E_UI_Layer.Top);

        AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(Name);

        proCB = () =>
        {

            val = sceneAsync.progress;
            UIManager.GetInstance().TackUIPanel<LoadingPanel>("LoadingPanel").SetProgress(val);

            if (val == 1)
            {

                if (loadend != null)
                {
                    loadend();

                }
                proCB = null;
                sceneAsync = null;
                UIManager.GetInstance().DestroyPanle("LoadingPanel");
            }

        };
    }



    //private void ProgressShow(LoadingPanel info)
    //{

    //    (info as LoadingPanel).SetProgress(val);
    //}




}
