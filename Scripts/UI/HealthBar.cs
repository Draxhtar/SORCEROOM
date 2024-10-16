using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] bool doesHaveText = false;
    [SerializeField] TMP_Text healthText;

    public void SetMaxHealth(int health) 
    {
        slider.maxValue = health;
        UpdateText(slider.value);
    }

    public void SetMaxHealthAtStart(int health)
    {
        slider.maxValue = health;
        SetHealth(health);
    }

    public void SetHealth(int health) 
    {
        slider.value = health;
        if (doesHaveText)
            UpdateText(health);
    }

    public void UpdateText(float health) 
    {
        healthText.text = health.ToString() + "/" + slider.maxValue.ToString();
    }
}
