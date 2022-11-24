using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float fireLife;
    float damage = 20;

    public void Extinct()
    {
        fireLife -= damage * Time.deltaTime;
        Debug.Log(fireLife);
    }
}
