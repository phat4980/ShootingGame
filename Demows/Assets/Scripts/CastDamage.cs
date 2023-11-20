using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TargetType{
    normal, center
}
public class CastDamage : MonoBehaviour
{
    [SerializeField]
    private int setPointNumber;
    [SerializeField]
    private GameManager gameManager;
    public void addPoint()
    {
        if (tag.Equals("Target"))
        {
            gameManager.AddPoint(setPointNumber);
        }
        else
        {
            gameManager.AddPoint(setPointNumber*2);
        }
    }
}
