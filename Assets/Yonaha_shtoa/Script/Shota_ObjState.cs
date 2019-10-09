using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Shota_ObjState : ScriptableObject {
    
    [SerializeField] int iReminingNumber; // 残り数
    [SerializeField] float fGenerateRate; // 出現確率
    [SerializeField] GameObject Obj; // 生成対象

    public int GetiReminingNumber()
    {
        return iReminingNumber;
    }

    public float GetGenerateRate()
    {
        return fGenerateRate;
    }

    public GameObject GetObject()
    {
        return Obj;
    }

    public void AddGenerateRate(float addNum)
    {
        fGenerateRate += addNum;
    }

    public void SubtractionReminingNumber(int subNum)
    {
        iReminingNumber -= subNum;
    }

}
