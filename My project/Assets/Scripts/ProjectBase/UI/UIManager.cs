using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// UI层级
/// </summary>
public enum E_UI_Layer
{
    Bot,
    Mid,
    Top,
    System,
}

/// <summary>
/// UI管理器
/// 1.管理所有显示的面板
/// 2.提供给外部 显示和隐藏等等接口
/// </summary>
public class UIManager : BaseManager<UIManager>
{
    public Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();


    //
    public Dictionary<string, GameObject> panelGame = new Dictionary<string, GameObject>();

    private Transform bot;
    private Transform mid;
    private Transform top;
    private Transform system;

    public UIManager()
    {
        //创建Canvas 让其过场景的时候 不被移除
        GameObject obj = ResMgr.GetInstance().Load<GameObject>("UI/Canvas");
        Transform canvas = obj.transform;
        GameObject.DontDestroyOnLoad(obj);

        //找到各层
        bot = canvas.Find("Bot");
        mid = canvas.Find("Mid");
        top = canvas.Find("Top");
        system = canvas.Find("System");

        //创建EventSystem 让其过场景的时候 不被移除
        obj = ResMgr.GetInstance().Load<GameObject>("UI/EventSystem");
        GameObject.DontDestroyOnLoad(obj);
    }

    /// <summary>
    /// 异步显示面板
    /// </summary>
    /// <typeparam name="T">面板脚本类型</typeparam>
    /// <param name="panelName">面板名</param>
    /// <param name="layer">显示在哪一层</param>
    /// <param name="callBack">当面板预设体创建成功后 你想做的事</param>
    public void ShowPanelAsync<T>(string panelName, E_UI_Layer layer = E_UI_Layer.Mid, UnityAction<T> callBack = null) where T:BasePanel
    {
        if (panelDic.ContainsKey(panelName))
        {

            panelDic[panelName].gameObject.SetActive(true);
            panelDic[panelName].ShowMe();
            // 处理面板创建完成后的逻辑
            if (callBack != null)
                callBack(panelDic[panelName] as T);
             return;
        }

        ResMgr.GetInstance().LoadAsync<GameObject>("UI/" + panelName, (obj) =>
        {
            //把他作为 Canvas的子对象
            //并且 要设置它的相对位置
            //找到父对象 你到底显示在哪一层
            Transform father = bot;
            switch(layer)
            {
                case E_UI_Layer.Mid:
                    father = mid;
                    break;
                case E_UI_Layer.Top:
                    father = top;
                    break;
                case E_UI_Layer.System:
                    father = system;
                    break;
            }
            //设置父对象  设置相对位置和大小
            obj.transform.SetParent(father);

            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;

            (obj.transform as RectTransform).offsetMax = Vector2.zero;
            (obj.transform as RectTransform).offsetMin = Vector2.zero;
            //正交相机设置
            //(obj.transform as RectTransform).anchoredPosition3D = new Vector3(0, 0, 500);

            //得到预设体身上的面板脚本
            T panel = obj.GetComponent<T>();

            // 处理面板创建完成后的逻辑
            if (callBack != null)
                callBack(panel);

            panel.ShowMe();

            //把面板存起来
            panelDic.Add(panelName, panel);
        });



    }





    /// <summary>
    /// 同步显示面板
    /// </summary>
    /// <typeparam name="T">面板脚本类型</typeparam>
    /// <param name="panelName">面板名</param>
    /// <param name="layer">显示在哪一层</param>
    /// <param name="callBack">当面板预设体创建成功后 你想做的事</param>
    public void ShowPanel<T>(string panelName, E_UI_Layer layer = E_UI_Layer.Mid, UnityAction<T> callBack = null) where T : BasePanel
    {
        

        if (panelDic.ContainsKey(panelName))
        {

            panelDic[panelName].gameObject.SetActive(true);
            panelDic[panelName].ShowMe();
            // 处理面板创建完成后的逻辑
            if (callBack != null)
                callBack(panelDic[panelName] as T);
            return;
        }


        GameObject tmp = ResMgr.GetInstance().Load<GameObject>(("UI/" + panelName));


        Transform father = bot;
        switch (layer)
        {
            case E_UI_Layer.Mid:
                father = mid;
                break;
            case E_UI_Layer.Top:
                father = top;
                break;
            case E_UI_Layer.System:
                father = system;
                break;
        }

        //设置父对象  设置相对位置和大小
        tmp.transform.SetParent(father);

        tmp.transform.localPosition = Vector3.zero;
        tmp.transform.localScale = Vector3.one;

        (tmp.transform as RectTransform).offsetMax = Vector2.zero;
        (tmp.transform as RectTransform).offsetMin = Vector2.zero;

        //正交相机设置
        //(tmp.transform as RectTransform).anchoredPosition3D = new Vector3(0, 0, 500);

        T panel = tmp.GetComponent<T>();
        // 处理面板创建完成后的逻辑
        if (callBack != null)
            callBack(panel);

        panel.ShowMe();

        panelDic.Add(panelName, panel);
    
    }




    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="panelName"></param>
    public void HidePanle(string panelName)
    {
        if(panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].HideMe();
            panelDic[panelName].gameObject.SetActive(false);
           
            //GameObject.Destroy(panelDic[panelName].gameObject);
            //panelDic.Remove(panelName);
        }
    }


    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="panelName"></param>
    public void DestroyPanle(string panelName)
    {
        if (panelDic.ContainsKey(panelName))
        {
            //panelDic[panelName].HideMe();
            //panelDic[panelName].gameObject.SetActive(false);

            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);
        }
    }

    //给外部获取UIPanel
    public T TackUIPanel<T>(string panelName)where T:BasePanel
    {

        if (panelDic.ContainsKey(panelName))
        {

            return panelDic[panelName]as T;
        }
        else
        {
            Debug.Log("该场景账本里没有");
           
        }

        return null;
    }






}
