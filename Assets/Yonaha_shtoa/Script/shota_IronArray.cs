using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shota_IronArray : MonoBehaviour {

    [SerializeField] GameObject Target_Anim; // 対象のアニメーション
    [SerializeField] float DeadTime; // アニメーションが消滅するまでの時間
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject anim = Instantiate(Target_Anim,transform.position,Quaternion.identity);
        Destroy(anim,DeadTime);
    }
}
