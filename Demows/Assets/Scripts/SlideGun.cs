using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGun : MonoBehaviour
{
    public Action OnSlideComplete;
    [SerializeField] Transform slideT;
    private void Awake()
    {
    }

    public void RegisterEvent(Action OnSlideComplete)
    {
        this.OnSlideComplete = OnSlideComplete;
    }
    public void ClearEvent()
    {
        this.OnSlideComplete = null;
    }
    public void UnSelect(PointerEvent pointerEvent)
    {
       
        if(transform.localPosition.z >= 0.03 && transform.localPosition.z < 0.04)
        {
            transform.position = slideT.position;
            OnSlideComplete?.Invoke();
        }
       
    }
  
}
