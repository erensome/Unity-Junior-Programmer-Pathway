using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PowerupType
{
    None,
    Pushback,
    Rocket,
    Smash
}
public class PowerUp : MonoBehaviour
{
    public PowerupType powerUpType;
}
