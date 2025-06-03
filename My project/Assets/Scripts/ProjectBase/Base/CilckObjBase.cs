using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;




public class ClickObjBase : MonoBehaviour, IPointerClickHandler
{
    //玩家位置
    protected Transform player_Transform;
    protected float distance = 3f;
    //响应开关
    protected bool isOpen = false;

    //private void Start()
    //{
        
    //}


   


    /// <summary>
    /// 点击后要实现的功能事件
    /// </summary>
    public virtual void ClickEvent()
    {
        player_Transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }




    public void OnPointerClick(PointerEventData eventData)
    {
       
            ClickEvent();
       
    }

}
