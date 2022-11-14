using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    Heat currentHeatSource = null;
    public float coockingLevel;
    public float cookingMax;

    private void Awake()
    {
        currentHeatSource = null;
    }

    private void Update()
    {
        Cook();
    }

    private void Cook()
    {
        if (currentHeatSource == null)
            return;

        if (!currentHeatSource.isHot)
            return;

        coockingLevel += Time.deltaTime;

        if (coockingLevel >= cookingMax)
        {
            Debug.Log("Cocinado");
        }
        else
        {
            Debug.Log("Cocinando");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.gameObject.CompareTag("Fire Source"))
            return;

        currentHeatSource = collision.gameObject.GetComponent<Heat>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Fire Source"))
            return;

        currentHeatSource = null;
    }
}
