using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [HideInInspector]
    public Transform m_Transform;
    private CharacterController controlMove;

    public Transform camera_Transform;

    //private Canvas WorldCanvas;


    //方向灵敏度
    public float sensitivityX = 6f;
    public float sensitivityY = 6f;

    //上下的最大视角
    public float minY = -60f;
    public float maxY = 60f;

    float rotationY = 0f;
    float rotationX = 0f;

    public float speed=3f;

    private Vector3 moveDirection = Vector3.zero;

   // public bool isOpen = true;
    
    // Start is called before the first frame update
    void Start()
    {

        //WorldCanvas = GameObject.FindGameObjectWithTag("WorldCanvas").GetComponent<Canvas>();
        //m_Transform = gameObject.GetComponent<Transform>();
        //controlMove = m_Transform.GetComponent<CharacterController>();
        //camera_Transform = m_Transform.Find("PlayerCamera").transform;
        //Debug.Log("PTransfor" + camera_Transform.position);

        //WorldCanvas.worldCamera = camera_Transform.GetComponent<Camera>();


        
        ////开启输入检测
        InputMgr.GetInstance().StartOrEndCheck(true);

        //EventCenter.GetInstance().AddEventListener<KeyCode>("某键按着", CheckInput);
        EventCenter.GetInstance().AddEventListener<int>("按着鼠标", CheckMouseButton);
    }

    /// <summary>
    /// 相机角度限制
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public float Clam(float value, float min, float max)
    {
        if (value < min) { return min; }
        if (value > max) { return max; }
        return value;
    }


    #region W,A,S,D 逻辑
    Vector3 forward;
    void PlayerForwardMove()
    {
        forward = camera_Transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controlMove.SimpleMove(forward * curSpeed);
    }
    void PlayerRight()
    {
        controlMove.SimpleMove(camera_Transform.right * speed);
    }
    void PlayerLeft()
    {    
        controlMove.SimpleMove(camera_Transform.right * -speed);

    }
    void PlayerBackMove()
    {
        controlMove.SimpleMove(camera_Transform.forward * -speed);
    }
    #endregion


    /// <summary>
    /// 按键按下
    /// </summary>
    /// <param name="key"></param>
    private void CheckInputDown(KeyCode key)
    {
        KeyCode code = (KeyCode)key;
        switch (code)
        {
            case KeyCode.W:
                //Debug.Log("前进");
              
                break;
            case KeyCode.A:
                //Debug.Log("左进");
             
                break;
            case KeyCode.S:
                //Debug.Log("后退");
              
                break;
            case KeyCode.D:
               // Debug.Log("右转");
              
                break;
        }
    }

    /// <summary>
    /// 按键抬起
    /// </summary>
    /// <param name="key"></param>
    private void CheckInputUp(KeyCode key)
    {
        KeyCode code = (KeyCode)key;
        switch (code)
        {
            case KeyCode.W:
                //Debug.Log("停止前进");
                break;
            case KeyCode.A:
              //  Debug.Log("停止左转");
                break;
            case KeyCode.S:
              //  Debug.Log("停止后退");
                break;
            case KeyCode.D:
              //  Debug.Log("停止右转");
                break;
        }
    }


    /// <summary>
    /// 持续按下某键
    /// </summary>
    /// <param name="key"></param>
    private void CheckInput(KeyCode key)
    {
        KeyCode code = (KeyCode)key;
        switch (code)
        {
            case KeyCode.W:
               // Debug.Log("前进");
                PlayerForwardMove();
                break;
            case KeyCode.A:
               // Debug.Log("左进");
                PlayerLeft();
                break;
            case KeyCode.S:
                //Debug.Log("后退");
                PlayerBackMove();
                break;
            case KeyCode.D:
                //Debug.Log("右转");
                PlayerRight();
                break;
        }
    }



    private void CheckMouseButton(int index)
    {
       
        switch (index)
        {
            case 0:
                
                break;
            case 1:
                Debug.Log("鼠标按下1");
                ChangeCameraAngles();
              
                break;
    
        }


    }



    /// <summary>
    /// 相机角度旋转
    /// </summary>
    private void ChangeCameraAngles()
    {

        //获取鼠标左右旋转的角度
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;

        //获取鼠标上下旋转的角度
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

        //角度限制，如果rorationY小于min返回min，大于max返回max
        rotationY = Clam(rotationY, minY, maxY);

        //设置摄像机的角度
        camera_Transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

    }


    private void OnDestroy()
    {
        //EventCenter.GetInstance().RemoveEventListener<KeyCode>("某键按着", CheckInput);


        EventCenter.GetInstance().RemoveEventListener<int>("按着鼠标", CheckMouseButton);

    }


}
