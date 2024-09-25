using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    TAUNT
}
public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimation player_Anim;
    private bool activateTimerToReset;
    private float default_Combo_Timer = 0.3f;
    private float current_Combo_Timer;
    private ComboState current_Combo_State;

    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;
    }

    void Awake()
    {
        player_Anim = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {
        if(Input.GetKeyDown(KeyCode.Z))      
        {
            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if(current_Combo_State == ComboState.PUNCH_1)
            {
                player_Anim.Punch_1();
            }

            if (current_Combo_State == ComboState.PUNCH_2)
            {
                player_Anim.Punch_2();
            }

            if (current_Combo_State == ComboState.PUNCH_3)
            {
                player_Anim.Punch_3();
            }

        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            player_Anim.Kick_1();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            player_Anim.Taunt();
        }
    }

    void ResetComboState()
    {
        if(activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;
            if(current_Combo_Timer <= 0f)
            {
                current_Combo_State = ComboState.NONE;
                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }
}
