using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shota_Obj : MonoBehaviour {
    [SerializeField] float fFallSpeed;// 落下速度
    [SerializeField] float fMaxFallSpeed;// 最大落下速度
    float fTotalFallTime; // 落下時間
    [SerializeField]　float DeathPosition; // これ以下になると消える

    private void Update()
    {
        if(fFallSpeed  * fTotalFallTime < fMaxFallSpeed)
        fTotalFallTime += Time.deltaTime;

        transform.Translate(0, -fFallSpeed * fTotalFallTime, 0);

        if(transform.position.y <= -DeathPosition)
        {
            Destroy(gameObject);
        }
    }
}
