using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    // variables
    [SerializeField] private float m_yUndulatingRange = 0.5f;
    [SerializeField] private float m_undulatingSpeedScale = 0.5f;
    [SerializeField] private float m_walkUndulatingSpeed;
    [SerializeField] private float m_runUndulatingSpeed;
    private float m_defaultY;

    //references
    [SerializeField] CharacterController m_playerCharacterController;
    [SerializeField] PlayerMovement m_playerMovement;

    private void Start() 
    {
        m_defaultY = transform.localPosition.y;
    }

    private void Update() 
    {
        // need to check for running or walking
        switch ( m_playerMovement.GetPlayerMovementState() )
        {
            case PlayerMovementState.Idle:
                break;
            case PlayerMovementState.Walking:
                Undulate( m_walkUndulatingSpeed );
                break;
            case PlayerMovementState.Running:
                Undulate( m_runUndulatingSpeed );
                break;
            case PlayerMovementState.Jumping:
                break;
            case PlayerMovementState.FreeThrowing:
                break;
            default:
                break;
        }
    }

    private void Undulate( float undulateSpeed )
    {
        float y = Mathf.Sin( Time.time * undulateSpeed ) * m_yUndulatingRange + m_defaultY;
        transform.localPosition = new Vector3( transform.localPosition.x, y, transform.localPosition.z );
    }
}
