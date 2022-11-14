using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heat : MonoBehaviour
{
    public bool isHot = false;
   
    public void ToogleHeat()
    {
        isHot = !isHot;
    }
}
