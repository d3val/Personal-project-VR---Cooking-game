using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heat : MonoBehaviour
{
    public bool isHot = false;
    public bool isHeatSource = false;
    public Heat currentHeatSource = null;

    private void Awake()
    {
        isHeatSource = false;
    }
    private void Update()
    {
        if (isHeatSource)
            return;
        if (currentHeatSource == null)
        {
            isHot = false;
            return;
        }

        isHot = currentHeatSource.isHot;
    }

    public void ToogleHeat()
    {
        isHot = !isHot;
    }

    public void ToogleHeatSource()
    {
        isHeatSource = !isHeatSource;
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
