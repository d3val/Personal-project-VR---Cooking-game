using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public List<SwitchPan> switches = new List<SwitchPan>();

    private void Start()
    {

        foreach (SwitchPan switchPan in switches)
        {
            switchPan.indicatorIsActivated = switchPan.panHeatIndicator.activeSelf;
        }
    }
    public void ToogleHeatIndicator(int index)
    {
        switches[index].indicatorIsActivated = !switches[index].indicatorIsActivated;
        switches[index].panHeatIndicator.SetActive(switches[index].indicatorIsActivated);

    }
}

[System.Serializable]
public class SwitchPan
{
    public GameObject panHeatIndicator;
    public bool indicatorIsActivated = false;
}
