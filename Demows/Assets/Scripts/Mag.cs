using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mag : MonoBehaviour
{
    [SerializeField]
    private int numberOfBullets = 17;
    [SerializeField]
    private SlideGun slide;
    [SerializeField]
    private GunController gunController;
    [SerializeField]
    private TextMeshPro textNumber;
    [SerializeField]
    private bool showNumber = true;
    private void Awake()
    {
        textNumber.text = numberOfBullets.ToString();
        if (showNumber)
        textNumber.gameObject.SetActive(true);
        else textNumber.gameObject.SetActive(false);
    }
    public void SnapElement()
    {
        slide.RegisterEvent(OnSlideComplete);
    }


    public void OnSlideComplete()
    {
        if (gunController != null && !gunController.hasBullet && numberOfBullets>0)
        {
            numberOfBullets -= 1;
            gunController.hasBullet = true;
        }
        textNumber.text = numberOfBullets.ToString();

    }
    public void UnsnapElement()
    {

        slide.ClearEvent();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
