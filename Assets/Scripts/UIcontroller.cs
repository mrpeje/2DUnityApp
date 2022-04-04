using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIcontroller : MonoBehaviour
{
    public MapGroup Maps;
    public Button MenuBtn;
    public Button WoodsBtn, CustomsBtn, FactoryBtn, ReserveBtn, ShorelineBtn, LighthouseBtn, InterchangeBtn;
    bool IsMenuOpen;
  
    void OpenMenu()
    {
        // Open menu
        if (IsMenuOpen == false)
        {
            WoodsBtn.style.display = DisplayStyle.Flex;
            CustomsBtn.style.display = DisplayStyle.Flex;
            FactoryBtn.style.display = DisplayStyle.Flex;
            ReserveBtn.style.display = DisplayStyle.Flex;
            ShorelineBtn.style.display = DisplayStyle.Flex;
            LighthouseBtn.style.display = DisplayStyle.Flex;
            InterchangeBtn.style.display = DisplayStyle.Flex;

            IsMenuOpen = true;
        }
        // Close menu
        else if(IsMenuOpen == true)
        {
            WoodsBtn.style.display = DisplayStyle.None;
            CustomsBtn.style.display = DisplayStyle.None;
            FactoryBtn.style.display = DisplayStyle.None;
            ReserveBtn.style.display = DisplayStyle.None;
            ShorelineBtn.style.display = DisplayStyle.None;
            LighthouseBtn.style.display = DisplayStyle.None;
            InterchangeBtn.style.display = DisplayStyle.None;

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
        FactoryBtn = root.Q<Button>("Factory");
        ReserveBtn = root.Q<Button>("Reserve");
        ShorelineBtn = root.Q<Button>("Shoreline");
        LighthouseBtn = root.Q<Button>("Lighthouse");
        InterchangeBtn = root.Q<Button>("Interchange");

        MenuBtn.clicked += OpenMenu;
        WoodsBtn.clicked += WoodsActive;
        CustomsBtn.clicked += CustomsActive;
        FactoryBtn.clicked += FactoryActive;
        ReserveBtn.clicked += ReserveActive;
        ShorelineBtn.clicked += ShorelineActive;
        LighthouseBtn.clicked += LighthouseActive;
        InterchangeBtn.clicked += InterchangeActive;

    }

    void CustomsActive()
    {
        Maps.SetActive(0);
    }
    void FactoryActive()
    {
        Maps.SetActive(1);
    }
    void LighthouseActive()
    {
        Maps.SetActive(2);
    }
    void WoodsActive()
    {
        Maps.SetActive(3);
    }
    void InterchangeActive()
    {
        Maps.SetActive(5);
    }
    void ReserveActive()
    {
        Maps.SetActive(4);
    }
    void ShorelineActive()
    {
        Maps.SetActive(6);
    }



}
