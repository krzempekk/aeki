using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Health = 100f;
    public float MoveSpeed = 4f;
    public float SprintSpeed = 6f;
    public float SpeedIncreaseFactor = 1.5f;

    public void IncreaseSpeed() {
        MoveSpeed *= SpeedIncreaseFactor;
        SprintSpeed *= SpeedIncreaseFactor;
    }

    public void DecreaseSpeed() {
        MoveSpeed /= SpeedIncreaseFactor;
        SprintSpeed /= SpeedIncreaseFactor;
    }
}
