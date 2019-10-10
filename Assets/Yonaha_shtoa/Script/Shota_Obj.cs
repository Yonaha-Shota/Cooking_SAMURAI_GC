using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shota_Obj : MonoBehaviour {

    [SerializeField] float fFallSpeed;// 落下速度
    [SerializeField] float fMaxFallSpeed;// 最大落下速度
    float fTotalFallTime; // 落下時間
    [SerializeField]　float DeathPosition; // この数値以下になると消滅

    [SerializeField] float expansionSpeed; // 拡大速度
    float expansionScale; // 大きさ
    [SerializeField] float amplitude; // 揺れる幅
    [SerializeField] float amplitudeSpeed; // 揺れる速さ
    int ShakeVec; // 揺れる方向
    [SerializeField] int MaxShakeCount;
    int ShakeCount;
    float currentAngle; // 今の角度
    int Step; // 生成　－＞　拡大　－＞　揺れ　－＞　落下

    private void Start()
    {
        transform.localScale = Vector3.zero;
        expansionScale = 0.0f;
        ShakeCount = 0;
        ShakeVec = 0;
        Step = 0;
    }

    private void FixedUpdate()
    {

        switch (Step)
        {
            case 0:
                expansionScale += expansionSpeed * Time.deltaTime;
                if(expansionScale >= 1.0f)
                {
                    expansionScale = 1.0f;
                    Step++;
                }
                transform.localScale = new Vector3(expansionScale,expansionScale,expansionScale);
                break;
            case 1:
                if(ShakeCount < MaxShakeCount)
                {
                    if(currentAngle < amplitude && ShakeVec == 0)
                    {
                        currentAngle += Time.deltaTime * amplitudeSpeed;
                    }
                    else
                    {
                        ShakeVec = 1;
                    }

                    if(currentAngle > -amplitude && ShakeVec == 1)
                    {
                        currentAngle -= Time.deltaTime * amplitudeSpeed;
                    }
                    else
                    {
                        ShakeVec = 0;
                    }

                    if(Mathf.Abs(currentAngle) < 1)
                    {
                        ShakeCount++;
                    }
                }
                else
                {
                    transform.rotation = Quaternion.Euler(Vector3.zero);
                    Step++;
                }

                transform.rotation =  Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentAngle));
                break;
            case 2:
                if (fFallSpeed  * fTotalFallTime < fMaxFallSpeed)
                    fTotalFallTime += Time.deltaTime;

                transform.Translate(0, -fFallSpeed * fTotalFallTime, 0);
                if (transform.position.y <= -DeathPosition)
                {
                    Step++;
                }
                break;
            case 3:
                Destraction(gameObject);
                break;
            default:
                break;
        }
    }

    private void Destraction(GameObject target)
    {
        Destroy(target);
    }
}
