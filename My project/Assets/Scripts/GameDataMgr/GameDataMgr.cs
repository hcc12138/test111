using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 考核的题目
/// </summary>
[System.Serializable]
public class Subject
{
    public int id;
    public string name;
    public string subject;//损坏描述
    public string icon;//损坏的图片
    public string step;

}
/// <summary>
/// 临时结构，表示考题的数据结构
/// </summary>
public class Subjects
{
    public List<Subject> info;
}



/// <summary>
/// 玩家数据
/// </summary>
public class Player
{
    public string name;
    public List<int> tmpStep;//玩家的操作步骤

    public Player()
    {
        name = "XX";
        tmpStep =new List<int>();
    }

}

/// <summary>
/// 修复步骤
/// </summary>
public class Step
{
    public List<int> tmpList;
}



public class GameDataMgr : BaseManager<GameDataMgr>
{
    public Dictionary<int, Subject> subjectDic = new Dictionary<int, Subject>();

    
    private static string PlayerPath = Application.streamingAssetsPath + "/PlayerData.txt";


    public Player playerData;



    /// <summary>
    /// 初始化数据
    /// </summary>
    public void Init()
    {

        //string info = ResMgr.GetInstance().Load<TextAsset>("GameData/GameData").text;

        //Subjects tmps = JsonUtility.FromJson<Subjects>(info);

        ////存进账本
        //for (int i = 0; i < tmps.info.Count; i++)
        //{
        //    subjectDic.Add(tmps.info[i].id, tmps.info[i]);
        //}

       

        ResMgr.GetInstance().LoadAsync<TextAsset>("GameData/GameData", (obj)=> {


            //Debug.Log(obj);
            //获取内容
            Subjects tmps = JsonUtility.FromJson<Subjects>(obj.ToString());


            //存进账本
            for (int i = 0; i < tmps.info.Count; i++)
            {
                subjectDic.Add(tmps.info[i].id, tmps.info[i]);
            }

        });
        
       

       



        ReadText();

        Debug.Log("初始化数据");
    }




    /// <summary>
    /// 写入玩家数据
    /// </summary>
    public void WriteText(Player tmpData)
    {
        
        StreamWriter tmpWrite = new StreamWriter(PlayerPath);
        //tmpWrite.Write(tmpData.name + ":");
        tmpWrite.Write(tmpData.name );

        tmpWrite.Close();
    }

    /// <summary>
    /// 读取玩家数据
    /// </summary>
    public void ReadText()
    {
        //string tmpPath = Application.streamingAssetsPath + "/PlayData.txt";

        StreamReader readerS = new StreamReader(PlayerPath);

        string tmpStr = readerS.ReadLine();
        //Debug.Log(tmpStr);
        string[] strObj = tmpStr.Split(':');

        for (int i = 0; i < strObj.Length; i++)
        {
            Debug.Log("*****" + strObj[i] + "********");
        }


        readerS.Close();
    }



    ///// <summary>
    ///// 读取考题步骤数据
    ///// </summary>
    //public void ReadStepText()
    //{
    //    //string tmpPath = Application.streamingAssetsPath + "/PlayData.txt";

    //    StreamReader readerS = new StreamReader(PlayerPath);

    //    string tmpStr = readerS.ReadLine();
    //    //Debug.Log(tmpStr);
    //    string[] strObj = tmpStr.Split(':');

    //    for (int i = 0; i < strObj.Length; i++)
    //    {
    //        Debug.Log("*****" + strObj[i] + "********");
    //    }


    //    readerS.Close();
    //}






    /// <summary>
    /// 根据ID获取考题数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Subject GetSubject(int id)
    {
        if (subjectDic.ContainsKey(id))
            return subjectDic[id];

        return null;
    }






}
