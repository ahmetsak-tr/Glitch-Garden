using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text startText;
    void Start()
    {
        startText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        startText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }
    
    public void SpendStars(int amount)
    {
        if(amount <= stars)
        {
            stars -= amount;
            UpdateDisplay();

        }

    }
}
