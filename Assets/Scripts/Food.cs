using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    //Cooking variables
    private Heat currentHeatSource = null;
    private float cookingLevel;
    [SerializeField] float cookingMaxLevel;
    [SerializeField] Slider cookingSlider;
    [SerializeField] AudioClip cookingSound = null;
    // Overcooking variables
    private float overcookingLevel;
    [SerializeField] float overcookingMaxLevel;
    [SerializeField] GameObject overcookingSliderGameObject;
    private Slider overcookingSlider;
    bool isOvercooking = false;
    [SerializeField] ParticleSystem Fire;
    // Burned variables
    private bool isBurned = false;
    [SerializeField] AudioClip burningSound = null;

    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        cookingLevel = 0;
        overcookingLevel = 0;
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

    // Cooks the food
    private void Cook()
    {
        if (currentHeatSource == null)
            return;

        if (!currentHeatSource.isHot)
        {
            audioSource.clip = null;
            audioSource.Stop();
            return;
        }

        cookingLevel += Time.deltaTime;
        cookingSlider.value = cookingLevel;

        if (cookingLevel >= cookingMaxLevel)
            StartOvercooking();

        if (audioSource.clip == cookingSound)
            return;
        if (audioSource.isPlaying)
            return;

        audioSource.clip = cookingSound;
        audioSource.Play();
    }

    // Sets overcooking variables up to an initial state
    private void StartOvercooking()
    {
        isOvercooking = true;
        overcookingLevel = 0;
        overcookingSliderGameObject.SetActive(true);
        overcookingSlider = overcookingSliderGameObject.GetComponent<Slider>();
        overcookingSlider.maxValue = overcookingMaxLevel;
        overcookingSlider.value = 0;
    }

    // overcooks the food
    private void Overcooking()
    {
        if (currentHeatSource == null)
            return;

        if (!currentHeatSource.isHot)
        {
            audioSource.clip = null;
            audioSource.Stop();
            return;
        }

        overcookingLevel += Time.deltaTime;
        overcookingSlider.value = overcookingLevel;

        // When reach the overcookingMaxLevel, plays the fire particle system.
        if (overcookingLevel > overcookingMaxLevel)
        {
            isBurned = true;
            audioSource.clip = burningSound;
            audioSource.Play();
            Fire.Play();
        }

        if (audioSource.clip == cookingSound)
            return;
        if (audioSource.isPlaying)
            return;

        audioSource.clip = cookingSound;
        audioSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.gameObject.CompareTag("Fire Source"))
            return;

        // Set the currentHeatSource
        currentHeatSource = collision.gameObject.GetComponent<Heat>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Fire Source"))
            return;

        //Cleans the current Heat source.
        currentHeatSource = null;
    }

    //Stops fire particle system.
    public void Extinct()
    {
        if (isBurned)
        {
            audioSource.Stop();
            Fire.Stop();
        }
    }
}
