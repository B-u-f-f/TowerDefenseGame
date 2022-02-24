using UnityEngine;

[CreateAssetMenu(fileName ="EnemySO", menuName ="ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject  {
    [SerializeField] private uint m_health = 100;

}
