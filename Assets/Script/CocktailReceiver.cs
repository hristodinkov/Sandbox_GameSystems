using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CocktailReceiver : MonoBehaviour
{
    [SerializeField] private bool fireBreathingEnabled;
    [SerializeField] private bool iceCubeEnabled;
    [SerializeField] private bool chickenEffectEnabled;
    [SerializeField] private bool fartEnabled;
    [SerializeField] private bool shrinkEffectEnabled;
    [SerializeField] private bool hiccupEffectEnabled;
    [SerializeField] private bool helicopterEffectEnabled;

    [SerializeField] private ParticleSystem fireBreathEffect;
    [SerializeField] private GameObject iceCube;
    [SerializeField] private GameObject chickenModel;
    [SerializeField] private ParticleSystem fartEffect;
    [SerializeField] private ParticleSystem chickenTransformation;
    [SerializeField] private GameObject theBoss;
    [SerializeField] private GameObject theWholeGameObject;
    [SerializeField] private Animator bossAnimator;

    [SerializeField] private AudioSource hiccupAudioSource;
    [SerializeField] private AudioSource fartAudioSource;
    [SerializeField] private AudioSource chickenAudioSource;
    [SerializeField] private AudioSource hellicopterAudioSource;
    [SerializeField] private AudioSource fireBreathAudioSource;

    [SerializeField] private float speedRotation;

    private Coroutine hiccupRoutine;


    private DrinkEffectType[] receivedEffects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cocktail"))
        {
            ResetUnc();
            var cocktail = other.GetComponent<CocktailData>();

            receivedEffects = cocktail.effects.ToArray();

            ReadCocktailInfo();
            ApplyEffects();

            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if (helicopterEffectEnabled)
        {
            theWholeGameObject.transform.Rotate(0, 300f * Time.deltaTime*speedRotation, 0);
            if (!hellicopterAudioSource.isPlaying)
                hellicopterAudioSource.Play();
        }
        else
        {
            theWholeGameObject.transform.rotation = Quaternion.identity;
        }
    }


    //private void Update()
    //{
    //    ApplyEffects();
    //}

    private void ApplyEffects()
    {
        FireBreathing();
        IceCube();
        Fart();
        Chicken();
        Shrink();
        HandleHiccup();
    }

    private void HandleHiccup()
    {
        if (hiccupEffectEnabled)
        {
            if (hiccupRoutine == null)
                hiccupRoutine = StartCoroutine(HiccupLoop());
        }
        else
        {
            if (hiccupRoutine != null)
            {
                StopCoroutine(hiccupRoutine);
                hiccupRoutine = null;
            }
        }
    }
    private IEnumerator HiccupLoop()
    {
        while (hiccupEffectEnabled)
        {
            if (!hiccupAudioSource.isPlaying)
                hiccupAudioSource.Play();
            // Hiccup animation
            theWholeGameObject.transform.position += new Vector3(0, 0.5f, 0);
            yield return new WaitForSeconds(0.2f);
            theWholeGameObject.transform.position -= new Vector3(0, 0.5f, 0);

            // Wait 4 seconds before next hiccup
            yield return new WaitForSeconds(4f);
        }

        hiccupRoutine = null;
    }



    private void Shrink()
    {
        if(shrinkEffectEnabled)
        {
            theWholeGameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            theWholeGameObject.transform.position += new Vector3(0.7f, 0f, 0);

        }
        else
        {
            theWholeGameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            theWholeGameObject.transform.position -= new Vector3(0.7f, 0f, 0);
        }
    }

    private void Fart()
    {
        if (fartEnabled)
        {
            if (!fartEffect.isPlaying)
                fartEffect.Play();
            if (!fartAudioSource.isPlaying)
                fartAudioSource.Play();
        }
        else
        {
            fartEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }


    private void Chicken()
    {
        if (chickenEffectEnabled)
        {
            chickenModel.SetActive(true);
            theBoss.SetActive(false);

            if (chickenTransformation != null && !chickenTransformation.isPlaying)
                chickenTransformation.Play();
            if (!chickenAudioSource.isPlaying) 
                chickenAudioSource.Play();
        }
        else
        {
            chickenModel.SetActive(false);
            theBoss.SetActive(true);

            if (chickenTransformation != null)
                chickenTransformation.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }



    private void IceCube()
    {
        // Ice cube
        iceCube.SetActive(iceCubeEnabled);
        bossAnimator.enabled = !iceCubeEnabled;
    }

    private void FireBreathing()
    {
        if (fireBreathingEnabled)
        {
            if (!fireBreathEffect.isPlaying)
                fireBreathEffect.Play();
            if (!fireBreathAudioSource.isPlaying) 
                fireBreathAudioSource.Play();
        }
        else
        {
            fireBreathEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }


    private void ResetUnc()
    {
        fireBreathingEnabled = false;
        iceCubeEnabled = false;
        chickenEffectEnabled = false;
        fartEnabled = false;
        shrinkEffectEnabled = false;
        hiccupEffectEnabled = false;

        fireBreathAudioSource.Stop();
        fartAudioSource.Stop(); 
        chickenAudioSource.Stop(); 
        hellicopterAudioSource.Stop(); 
        hiccupAudioSource.Stop();

        if (hiccupRoutine != null)
        {
            StopCoroutine(hiccupRoutine);
            hiccupRoutine = null;
        }

        theWholeGameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        theWholeGameObject.transform.rotation = Quaternion.identity;
    }
   

    private void ReadCocktailInfo()
    {
        fireBreathingEnabled = receivedEffects.Contains(DrinkEffectType.FireBreath);
        iceCubeEnabled = receivedEffects.Contains(DrinkEffectType.IceCube);
        chickenEffectEnabled = receivedEffects.Contains(DrinkEffectType.Chicken);
        fartEnabled = receivedEffects.Contains(DrinkEffectType.Fart);
        shrinkEffectEnabled = receivedEffects.Contains(DrinkEffectType.Shrink);
        hiccupEffectEnabled = receivedEffects.Contains(DrinkEffectType.Hiccup);
        helicopterEffectEnabled = receivedEffects.Contains(DrinkEffectType.Helicopter);
    }
}
