using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int point = 0;
    [SerializeField]
    private TextMeshPro pointText;
    private void Awake()
    {
        ResetGame();
    }
    public void ResetGame()
    {
        point = 0;
        SetTextPoint();
    }
    public void SetTextPoint()
    {
        pointText.text = "POINTS: " + point;
    }
    public void AddPoint(int points)
    {
        point += points;
        pointText.text = "POINTS: " + point;
    }
}
