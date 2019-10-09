using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shota_Obj_Generator : MonoBehaviour {

    [SerializeField] private List<Shota_ObjState> Target_Obj; // 生成するプレハブ格納

    [SerializeField] private float fGenerate_Interval; // 生成間隔

    private float fGenerate_Count; // 生成までの残り時間

    [SerializeField] private float fGenerate_LaneSize; // レーンの横間隔

    [SerializeField] private int iGenerate_LaneNum; // レーンの数

    // エディタ上に生成位置描画
    private void OnDrawGizmos()
    {
        for (int i = 0; i < iGenerate_LaneNum; i++)
        {
            Gizmos.DrawIcon(new Vector3(fGenerate_LaneSize * i + transform.position.x, transform.position.y, transform.position.z),
                "yjrs.png", true);
        }
    }

    private void Start()
    {
        fGenerate_Count = 0;
        Target_Obj.Sort((a, b) => (int)b.GetGenerateRate() - (int)a.GetGenerateRate());
        
    }

    private void FixedUpdate()
    {
        fGenerate_Count += Time.deltaTime;

        if(fGenerate_Count >= fGenerate_Interval)
        {
            CreateObj();
            SetCount(0, ref fGenerate_Count);
        }

    }

    private void CreateObj()
    {
        int iRandNum;
        iRandNum = Random.Range(0, 100);
        GameObject obj = Instantiate(Target_Obj[SetIndex(iRandNum)].GetObject(),
            new Vector3(fGenerate_LaneSize*SelectLane() + transform.position.x,transform.position.y,transform.position.z),
            Quaternion.identity);
        Target_Obj[iRandNum].SubtractionReminingNumber(1);
        if(Target_Obj[iRandNum].GetiReminingNumber() <= 0)
        {
            float Rate = Target_Obj[iRandNum].GetGenerateRate();
            Target_Obj.RemoveAt(iRandNum);
            foreach(Shota_ObjState state in Target_Obj)
            {
                state.AddGenerateRate(Rate / Target_Obj.Count);
            }
        }
        CheckGenerateObject(obj);
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

    private void CheckGenerateObject(GameObject obj)
    {
        Debug.Log(obj.name + "　を　生成しました");
    }

    private int SetIndex(int randnum)
    {
        int indexNum = 0;
        int cumurativeRate = 0;

        foreach (Shota_ObjState state in Target_Obj)
        {
            cumurativeRate += (int)state.GetGenerateRate();

            if (cumurativeRate <= randnum)
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
//　ランダムな等間隔の位置に,ランダムに選んで生成します