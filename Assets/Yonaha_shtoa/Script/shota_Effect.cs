﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shota_Effect : MonoBehaviour {
    
    public void SelfDestroy(float limit)
    {
        Destroy(gameObject , limit);
    }
    public void ParentDestroy(float limit)
    {
        Destroy(transform.root.gameObject, limit);
    }
}
