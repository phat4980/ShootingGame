using Oculus.Interaction.HandGrab;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour, IHandGrabUseDelegate
{
    enum GunState
    {
        normal, fire
    }
    public bool hasBullet = false;
    private Action onFire;
    private bool isTrigger = false;
    [SerializeField]
    private GameObject prefabsBullet;
    [SerializeField]
    private GameObject FirePoint;

    [SerializeField]
    private SlideGun silde;
    [SerializeField]
    private GameObject casingPrefab;

    [SerializeField]
    private Transform sildeT;
    [SerializeField]
    private Transform sildeF;

    private GunState currentState = GunState.normal;
    private bool direction = false;
    [SerializeField]
    [Header("Audio empty")]
    private AudioClip emptySounds;
    [SerializeField]
    [Header("Audio Fire")]
    private AudioClip fireSounds;
    [SerializeField]
    private AudioSource audioSource;
    private void Awake()
    {
        onFire = OnFire;
    }
    public void OnFire()
    {
        Instantiate(prefabsBullet, FirePoint.transform.position, FirePoint.transform.rotation);
        hasBullet = false;
        direction = false;
        currentState = GunState.fire;
        audioSource.clip = fireSounds;
        audioSource.Play();
    }
    public void BeginUse()
    {
        if (!isTrigger && !hasBullet)
        {
            IsEmpty();
        }
    }
    public void OnCasing()
    {
        if (casingPrefab != null)
            Instantiate(casingPrefab, silde.transform.position, silde.transform.rotation);
    }
    public void AddBullet()
    {
        silde.OnSlideComplete?.Invoke();
    }

    public float ComputeUseStrength(float strength)
    {
        if (!isTrigger && hasBullet)
        {
            isTrigger = true;
            onFire?.Invoke();
        }
        return strength;
    }
    public void IsEmpty()
    {
        audioSource.clip = emptySounds;
        audioSource.Play();
    }
    public void EndUse()
    {
        isTrigger = false;
    }
    
    private void FixedUpdate()
    {
        switch (currentState)
        {
            case GunState.normal:
                {
                    break;
                }
            case GunState.fire:
                {
                    if (!direction)
                    {
                        silde.transform.position = Vector3.Lerp(silde.transform.position, sildeF.position, 0.5f);
                       
                        if (Vector3.Distance(silde.transform.position, sildeF.position)< 0.0002)
                        {
                            silde.transform.position = sildeF.position;
                           direction = true;
                            OnCasing();
                        }
                    }
                    else
                    {
                        silde.transform.position = Vector3.Lerp(silde.transform.position, sildeT.position, 0.5f);
                        if (Vector3.Distance(silde.transform.position, sildeF.position) > 0.0365f)
                        {
                            silde.transform.position = sildeT.position;
                            AddBullet();
                           currentState = GunState.normal;
                        }
                    }
                   
                    
                    break;
                }
        }
    }
}
