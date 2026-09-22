using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Points PacPoints;
    [SerializeField] private Pac pac;
    public static float Speed = 100f;

    public static int Score = 0;

    // Update is called once per frame
    public static void UpdateScore(int newScore)
    {
        Score = newScore;
        ScoreText.UpdateScore(Score);
    }

}
