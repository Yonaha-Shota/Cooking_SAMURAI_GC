using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shota_weapon : MonoBehaviour {
    [SerializeField] GameObject Trail; // 剣閃
    [SerializeField] GameObject parentObj; // 親オブジェクト
    [SerializeField] float rote; // 回転角度
    [SerializeField] float roteSpeed; // 剣速
    [SerializeField] float waitTime; // 残心時間
    private Vector3 initRotation; // 納刀時角度
    private bool iaiFlg; // 振る
    private float moving; // 変化した角度
    private int iaiStep; // 居合段階
    private float waitcount;

    private void Start()
    {
        initRotation = parentObj.transform.rotation.eulerAngles;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            iaiFlg = true;
        }

        if (iaiFlg)
        {
            iai();
        }
    }

    private void iai()
    {
        switch (iaiStep)
        {
            case 0:

                if (rote > Mathf.Abs(moving))
                {
                    SwitchChange(true);
                    parentObj.transform.Rotate(0, 0, roteSpeed * Time.deltaTime);
                    moving += roteSpeed * Time.deltaTime;
                }
                if(rote <= Mathf.Abs(moving))
                {
                    waitcount += Time.deltaTime;
                    if(waitcount >= waitTime)
                    iaiStep++;
                }
                break;
            case 1:
                Reset();
                break;
            default:
                break;
        }
    }

    private void SwitchChange(bool isActive)
    {
        Trail.SetActive(isActive);
    }

    private void Reset()
    {
        SwitchChange(false);
        parentObj.transform.rotation = Quaternion.Euler(initRotation);
        moving = 0;
        iaiStep = 0;
        waitcount = 0;
        iaiFlg = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Reset();
    }
}
