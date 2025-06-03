using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayPush : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnEnable()
    {
       Invoke("Push", 1f);
    }

    
    void Push()
    {
        PoolMgr.GetInstance().PushObj(this.gameObject.name, this.gameObject);
    }


    private void Start()
    {
        this.transform.DOLocalMove(new Vector3(0, 0, 3f),0.12f);
    
    }
}
