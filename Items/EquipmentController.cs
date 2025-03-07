using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentController : MonoBehaviour
{
    public Image weapon;

    public static EquipmentController instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void UpdateImage(Texture2D equippedWeapon)
    {
        weapon.sprite = Sprite.Create(equippedWeapon, new Rect(0.0f, 0.0f, equippedWeapon.width, equippedWeapon.height), new Vector2(0.5f, 0.5f), 100f);
        
    }
}
