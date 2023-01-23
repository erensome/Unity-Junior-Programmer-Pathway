using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int health;
    private int score;

    public int Health
    {
        get => health;
        set => health = value;
    }
    public int Score
    {
        get => score;
        set => score = value;
    }
}
