﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageble
{
    // Start is called before the first frame update
    int Health
    {
        get; set;
    }
    void Damage();

}
