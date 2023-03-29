using UnityEngine;
using TMPro;

public class DisplayVelocity : MonoBehaviour
{
    TextMeshProUGUI _text;
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateText(float _velocity)
    {
        _text.SetText("Velocity: " + _velocity);
    }

}
