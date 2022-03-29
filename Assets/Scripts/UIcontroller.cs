using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIcontroller : MonoBehaviour
{
    public MapGroup Maps;
    public Button MenuBtn;
    public Button WoodsBtn, CustomsBtn;
    bool IsMenuOpen;
  
    void OpenMenu()
    {
        // Open menu
        if (IsMenuOpen == false)
        {
            WoodsBtn.style.display = DisplayStyle.Flex;
            CustomsBtn.style.display = DisplayStyle.Flex;
            IsMenuOpen = true;
        }
        // Close menu
        else if(IsMenuOpen == true)
        {
            WoodsBtn.style.display = DisplayStyle.None;
            CustomsBtn.style.display = DisplayStyle.None;
            IsMenuOpen = false;
        }
    }
    void Start()
    {
        IsMenuOpen = true;
        var root = GetComponent<UIDocument>().rootVisualElement;
        MenuBtn = root.Q<Button>("MapSelectionMenu");
        WoodsBtn = root.Q<Button>("Woods");
        CustomsBtn = root.Q<Button>("Customs");

        MenuBtn.clicked += OpenMenu;
        WoodsBtn.clicked += WoodsActive;
        CustomsBtn.clicked += CustomsActive;

    }
    void WoodsActive()
    {
        Maps.SetActive(1);
    }

    void CustomsActive()
    {
        Maps.SetActive(0);
    }

}
