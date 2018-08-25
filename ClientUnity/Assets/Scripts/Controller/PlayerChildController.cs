using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildController : MonoBehaviour 
{
    [SerializeField] ThirdPersonCharacter m_ThirdPersonCharacter;

    public void WeaponCollider_Open()
    {
        m_ThirdPersonCharacter.WeaponCollider_Open();
    }

    public void WeaponCollider_Close()
    {
        m_ThirdPersonCharacter.WeaponCollider_Close();
    }
}
