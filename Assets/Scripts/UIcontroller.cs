using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIcontroller : MonoBehaviour
{
    public Button MenuBtn;
    public Button WoodsBtn, CustomsBtn;
    bool IsMenuOpen;
    // Start is called before the first frame update
    void Start()
    {
        IsMenuOpen = true;
        var root = GetComponent<UIDocument>().rootVisualElement;
        MenuBtn = root.Q<Button>("MapSelectionMenu");
        WoodsBtn = root.Q<Button>("Woods");
        CustomsBtn = root.Q<Button>("Customs");

        MenuBtn.clicked += OpenMenu;

    }

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
    

}
