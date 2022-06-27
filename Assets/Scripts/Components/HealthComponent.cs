using System;
using UIComponents;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private Image _healthBar;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onDie;
        [SerializeField] private UnityEvent _onRestoreHealth;
        [SerializeField] private HealthChange _onChange;

        private int _maxHealth;
        private Score _score;

        private void Awake()
        {
            _score = FindObjectOfType<Score>();
        }

        private void Start()
        {
            _maxHealth = _health;
            UpdateHealthBar();
        }
        

        public void ApplyDamage(int damage)
        {
            _health -= damage;
            UpdateHealthBar();
            _onChange?.Invoke(_health);

            _onDamage?.Invoke();
            if (_health <= 0)
            {
                _onDie?.Invoke();
                _score.ChangeScore(1);
            }
        }

        public void RestoreHealth(int healthReplenishment)
        {
            _health += healthReplenishment;
            UpdateHealthBar();
            _onChange?.Invoke(_health);
        
            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
        
            _onRestoreHealth?.Invoke();
        }
        
        private void UpdateHealthBar() {
            _healthBar.fillAmount = Mathf.Clamp((float)_health / _maxHealth, 0, 1f);
        }
    
        [Serializable]
        public class HealthChange : UnityEvent<int>
        {
        
        }
    }
}