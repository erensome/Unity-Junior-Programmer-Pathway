using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int health = 3;
    private int score = 0;


    public void DecreaseLive()
    {
        if (health > 0)
        {
            health--;
            print("Lives = " + health);
        }
        else if(health == 0)
        {
            print("Game Over");
            
            //Decrease one more time to prevent "game over" spam.
            health--;
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        print("Score = " + score);
    }
}
