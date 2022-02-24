using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CannonSO", menuName ="ScriptableObjects/Cannon")]
public class CannonSO : ScriptableObject 
{
    [SerializeField] public float m_rangeRadius = 10f;
    [SerializeField] public uint m_fireDelay = 2000;
    [SerializeField] public uint m_damage = 10;
    [SerializeField] public float m_angVelocity = 5f;

}
