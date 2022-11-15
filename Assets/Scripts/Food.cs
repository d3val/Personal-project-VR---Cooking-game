using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    Heat currentHeatSource = null;
    public float cookingLevel;
    public float cookingMaxLevel;
    public Slider cookingSlider;

    public float overcookingLevel;
    public float overcookingMaxLevel;
    public GameObject overcookingSliderGameObject;
    private Slider overcookingSlider;
    bool isOvercooking = false;
    public ParticleSystem Fire;

    bool isBurned = false;
    private void Awake()
    {
        isOvercooking = false;
        currentHeatSource = null;
        cookingSlider.maxValue = cookingMaxLevel;
        cookingSlider.value = 0;
    }

    private void Update()
    {
        if (isBurned)
            return;

        if (isOvercooking)
        {
            Overcooking();
            return;
        }
        Cook();
    }

    private void Cook()
    {
        if (currentHeatSource == null)
            return;

        if (!currentHeatSource.isHot)
            return;

        cookingLevel += Time.deltaTime;
        cookingSlider.value = cookingLevel;

        if (cookingLevel >= cookingMaxLevel)
            StartOvercooking();
        else
        {
            Debug.Log("Cocinando");
        }
    }

    private void StartOvercooking()
    {
        isOvercooking = true;
        overcookingLevel = 0;
        overcookingSliderGameObject.SetActive(true);
        overcookingSlider = overcookingSliderGameObject.GetComponent<Slider>();
        overcookingSlider.maxValue = overcookingMaxLevel;
        overcookingSlider.value = 0;
    }
    private void Overcooking()
    {
        if (currentHeatSource == null)
            return;

        if (!currentHeatSource.isHot)
            return;

        overcookingLevel += Time.deltaTime;
        overcookingSlider.value = overcookingLevel;

        if (overcookingLevel > overcookingMaxLevel)
        {
            Debug.Log("Ya se quemo");
            isBurned = true;
            Fire.Play();
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
