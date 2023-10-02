using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InformationButton : MonoBehaviour
{
    [SerializeField]
    private GameObject information_panel;
    private bool is_active = false;
    public void Button_Press()
    {
        is_active = !is_active;
        information_panel.SetActive(is_active);
    }
}
