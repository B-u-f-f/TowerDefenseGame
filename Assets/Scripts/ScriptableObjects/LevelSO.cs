using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "ScriptableObjects/Level")]
public class LevelSO : ScriptableObject {
    [field: SerializeField] public int m_initialCoins = 500;
}
