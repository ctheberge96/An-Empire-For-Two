using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthbarManager))]
public class Damageable : MonoBehaviour
{
    private float hp;
    public float maxHp;
    public float defense;
    public float health {
        get {
            return hp;
        }
        set {
            float actualDamage = maxHp - defense;
            hp -= Mathf.Max(0, actualDamage);
        }
    }

}
