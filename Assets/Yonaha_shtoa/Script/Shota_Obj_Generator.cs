﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shota_Obj_Generator : MonoBehaviour
{

    [SerializeField] private List<Shota_ObjState> Target_Obj; // 生成するプレハブ格納

    private List<Shota_ObjState> cp_target_Obj; // リセット用

    [SerializeField] private float fGenerate_Interval; // 生成間隔

    private float fGenerate_Count; // 生成までの残り時間

    [SerializeField] private float fGenerate_LaneSize; // レーンの横間隔

    [SerializeField] private int iGenerate_LaneNum; // レーンの数

    private void Start()
    {
        fGenerate_Count = 0;
        Target_Obj.Sort((a, b) => (int)b.GetGenerateRate() - (int)a.GetGenerateRate());

        cp_target_Obj = new List<Shota_ObjState>(Target_Obj);

    }

    private void FixedUpdate()
    {
        fGenerate_Count += Time.deltaTime;

        if (fGenerate_Count >= fGenerate_Interval)
        {
            CreateObj();
            SetCount(0, ref fGenerate_Count);
        }

    }

    private void CreateObj()
    {

        // ここで生成箱の中を補充しているので止めたい場合はこの条件式をコメントアウトしてください
        if (Target_Obj.Count == 0)
        {
            Target_Obj = new List<Shota_ObjState>(cp_target_Obj);
            foreach (Shota_ObjState state in Target_Obj)
            {
                state.Init();
            }
        }

        int iIndexNum = SetIndex(Random.Range(0, 100));

        Instantiate(Target_Obj[iIndexNum].GetObject(),
            new Vector3(fGenerate_LaneSize * SelectLane() + transform.position.x, transform.position.y, transform.position.z),
            Quaternion.identity);

        Target_Obj[iIndexNum].SubtractionReminingNumber(1);

        if (Target_Obj[iIndexNum].GetiReminingNumber() <= 0)
        {
            float Rate = Target_Obj[iIndexNum].GetGenerateRate();
            Target_Obj.RemoveAt(iIndexNum);
            foreach (Shota_ObjState state in Target_Obj)
            {
                state.AddGenerateRate(Rate / Target_Obj.Count);
            }
        }
    }

    private int SelectLane()
    {
        int iRandNum;
        iRandNum = Random.Range(0, iGenerate_LaneNum);
        return iRandNum;
    }

    private void SetCount(float fSetNum, ref float fCount)
    {
        fCount = fSetNum;
    }

    private int SetIndex(int randnum)
    {
        int indexNum = 0;
        int cumurativeRate = 0;

        foreach (Shota_ObjState state in Target_Obj)
        {
            cumurativeRate += Mathf.CeilToInt(state.GetGenerateRate());
            if (cumurativeRate >= randnum)
            {
                break;
            }
            indexNum++;
        }
        return indexNum;
    }

    // 座標同期用
    public Vector3 GetPosiiton()
    {
        return transform.position;
    }
}


//　このジェネレータは
//　配列に格納されたオブジェクトのクローンを
//　ランダムな等間隔の位置に,ランダムに生成します

//　追記：最大生成数、出現確率をある程度制御できるように変更を加えました。
//　なお、生成できるオブジェクトがなくなった場合,リセットされ最初のの生成状態に戻ります