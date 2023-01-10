using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    // variables
    [SerializeField] private float m_yUndulatingRange = 0.5f;
    [SerializeField] private float m_UndulatingWalkSpeed = 0.5f;
    [SerializeField] private float m_UndulatingRunSpeed = 0.5f;
    private float m_defaultY;

    //references
    [SerializeField] CharacterController m_playerCharacterController;

    private void Start() 
    {
        m_defaultY = transform.localPosition.y;
    }

    private void Update() 
    {
        // need to check for running or walking
        Undulate(m_UndulatingRunSpeed);
    }

    private void Undulate( float undulateSpeed )
    {
        float y = Mathf.Sin( Time.time * undulateSpeed ) * m_yUndulatingRange + m_defaultY;
        transform.localPosition = new Vector3( transform.localPosition.x, y, transform.localPosition.z );
    }
}
