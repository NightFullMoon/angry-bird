using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Bird> birds;

    public List<Pig> pigs;

    // 小鸟在发射前，会被放置到这个位置
    Vector3 birdReadyposition;

    int aliveBirdCount = 0;


    public static GameManager Instance;

    private void Awake()
    {
        if (null == Instance)
        {
            Instance = this;

        }
        else
        {
            Debug.LogWarning("GameManager应该是一个单例，但是却被初始化了两次");
        }


    }

    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init()
    {
        Debug.Log("GameManager Init");
        if (null != birds && 0 < birds.Count)
        {
            birdReadyposition = birds[0].transform.position;
            birds[0].BeReady(birdReadyposition);
            aliveBirdCount = birds.Count;
        }
    }

    public void OnBirdSent()
    {
        birds.RemoveAt(0);
        //birds.Clear()
        if (0 < birds.Count)
        {
            birds[0].BeReady(birdReadyposition);
            //让下一只小鸟进入发射队列
        }

    }

    public void OnCurrentBirdDie()
    {
        --aliveBirdCount;
        getGameResult();

    }


    public void OnPigDie()
    {
        pigs.RemoveAt(0);
        getGameResult();
    }

    public void getGameResult()
    {
        if (0 == pigs.Count)
        {
            //赢了
            Debug.Log("胜利");
            return;
        }

        if (0 == aliveBirdCount)
        {
            //输了
            Debug.Log("失败");
            return;
        }
    }
}
