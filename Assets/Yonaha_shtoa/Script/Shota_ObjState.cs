using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Shota_ObjState : ScriptableObject {
    
    [SerializeField] int iReminingNumber; // 残り数設定用変数
    [SerializeField] float fGenerateRate; // 出現確率設定用変数
    [SerializeField] GameObject Obj; // 生成対象


    [SerializeField] int CurrentReminingNumber; // 実際に変動する値
    [SerializeField] float CurrentGenerateRate; // 実際に変動する値


    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        CurrentReminingNumber = iReminingNumber;
        CurrentGenerateRate = fGenerateRate;
    }

    public int GetiReminingNumber()
    {
        return CurrentReminingNumber;
    }

    public float GetGenerateRate()
    {
        return CurrentGenerateRate;
    }

    public GameObject GetObject()
    {
        return Obj;
    }

    public void AddGenerateRate(float addNum)
    {
        CurrentGenerateRate += addNum;
    }

    public void SubtractionReminingNumber(int subNum)
    {
        CurrentReminingNumber -= subNum;
    }
}
