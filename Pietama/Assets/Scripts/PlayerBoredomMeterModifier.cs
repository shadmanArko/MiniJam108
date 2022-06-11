using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerBoredomMeterModifier : MonoBehaviour
{
    private Slider _boredomMeterSlider;
    
    public UnityEvent onDecreaseBoredom;
    public UnityEvent onIncreaseBoredom;
    // Start is called before the first frame update
    void Start()
    {
        _boredomMeterSlider = GameObject.Find("Slider").GetComponent<Slider>();
    }
    
    public void DecreaseBoredom()
    {
        if (_boredomMeterSlider.value > .1f)
        {
            _boredomMeterSlider.value -= .1f;
            onDecreaseBoredom.Invoke();
        }
    }

    public void IncreaseBoredom()
    {
        _boredomMeterSlider.value += .1f;
        onIncreaseBoredom.Invoke();
    }
}
