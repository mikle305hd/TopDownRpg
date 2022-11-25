using System;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float _health;
    
    private bool _isBroken;
    
    public event Action<float> Damaged;
    public event Action Broken;

    public void Damage(float value)
    {
        if (_isBroken)
            return;
        
        _health = _health - value > 0 
            ? _health - value 
            : 0; 
        Damaged?.Invoke(_health);
        
        if (_health <= 0)
        {
            _isBroken = true;
            Broken?.Invoke();
        }
    }
}