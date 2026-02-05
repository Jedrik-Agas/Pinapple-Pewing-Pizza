using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    //[SerializeField] private Camera PCamera;

    public void BarUpdate(int Value)
    {
        slider.value = Value; 
    }

    void Update()
    {
        //transform.rotation = PCamera.transform.rotation;
    }
}
