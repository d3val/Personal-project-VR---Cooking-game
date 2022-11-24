using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        other.GetComponent<Food>().Extinct();
    }
}
