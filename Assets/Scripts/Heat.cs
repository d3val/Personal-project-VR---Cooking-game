using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heat : MonoBehaviour
{
    public bool isHot { get; private set; }
    [SerializeField] bool isHeatSource = false;
    private Heat currentHeatSource = null;

    private void Awake()
    {
        isHot = false;
    }
    private void Update()
    {
        // If the game object it's an heat source skip following code
        if (isHeatSource)
            return;

        // if the game object it's not a heat source it means that needs
        // a heat source to be hot
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

    // If the game object is colliding with an heat source
    // it will be game object's currentHeatSource

    private void OnCollisionEnter(Collision collision)
    {
        if (isHeatSource)
            return;
        if (!collision.gameObject.CompareTag("Fire Source"))
            return;

        currentHeatSource = collision.gameObject.GetComponent<Heat>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (isHeatSource)
            return;

        if (!collision.gameObject.CompareTag("Fire Source"))
            return;

        currentHeatSource = null;
    }

}
