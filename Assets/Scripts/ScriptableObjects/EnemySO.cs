using UnityEngine;

[CreateAssetMenu(fileName ="EnemySO", menuName ="ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject  {
    [SerializeField] private int m_health = 100;
    
    public int Health {
        get {
            return m_health;
        }

        set {
            m_health = value;
        }
    }

}
