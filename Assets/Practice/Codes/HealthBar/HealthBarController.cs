using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarController : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _currentHealth;
    private float _lerpSpeed = 0.01f;
    
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _healthTailBar;
    
    private Coroutine _HPChangeCoroutine;
    

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage()
    {
        
        _currentHealth -= 10;
        if (_currentHealth <= 0)
            _currentHealth = 0;
        StartHPChangeCoroutine();
    }

    public void Heal()
    {
        _currentHealth += 10;
        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        
        StartHPChangeCoroutine();
    }

    private void StartHPChangeCoroutine()
    {
        if (_HPChangeCoroutine != null) 
            StopCoroutine(_HPChangeCoroutine);
        
        _HPChangeCoroutine = StartCoroutine(ChangeHealthBar());
        
    }

    private IEnumerator ChangeHealthBar()
    {
        float fillAmount = (float)_currentHealth / _maxHealth;
        _healthBar.fillAmount = fillAmount;
        
        while (_healthTailBar.fillAmount != fillAmount)
        {
            _healthTailBar.fillAmount = Mathf.Lerp(_healthTailBar.fillAmount, fillAmount, _lerpSpeed);
            yield return null;
        }
    }
}
