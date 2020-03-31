using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public Slider slider;
	public Gradient gradient;//this is to change the healthbar colors at different points.
	public Image fill;
    //public Slider slider;

    private void Start()
    {
        int startHealth = (int) slider.maxValue;
        slider.value.Equals(startHealth);
        /*if (!slider.value.Equals(slider.maxValue))
        {
            slider.value.Equals(slider.maxValue);
        }*/
    }

    public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		fill.color = gradient.Evaluate(1f);
	}
	
	public void SetHealth(int health)
	{
		slider.value = health;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
