using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedScrollHandle : MonoBehaviour
{
    [SerializeField] public ScrollRect RectTranformScroll;
    [SerializeField] public Slider NewScrollSlider;
 
    private void OnEnable()
    {
        NewScrollSlider.onValueChanged.AddListener(UpdateScrollPosition);
        RectTranformScroll.onValueChanged.AddListener(UpdateSliderValue);
    }
 
    private void OnDisable()
    {
        // important! Don't forget to unsubscribe from events! 
        NewScrollSlider.onValueChanged.RemoveListener(UpdateScrollPosition);
        RectTranformScroll.onValueChanged.RemoveListener(UpdateSliderValue);
    }
 
    private void UpdateScrollPosition(float value)
    {
        // Here I flip the value in the code instead of trying to rotate the UI element itself since it's easier for me :P
        RectTranformScroll.verticalNormalizedPosition = 1 - value;
    }
 
    private void UpdateSliderValue(Vector2 scrollPosition)
    {
        // Again, flippin the value for visual consistency
        NewScrollSlider.SetValueWithoutNotify(1 - scrollPosition.y);
    }
}