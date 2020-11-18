using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats mystats;
    void Start()
    {
        playerManager = PlayerManager.instance;
        mystats = GetComponent<CharacterStats>();

    }
    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat=playerManager.player.GetComponent<CharacterCombat>();
        Debug.Log(playerCombat);
        if (playerCombat != null)
        {
            //aqui le hacemos daño al enemigo
            Debug.Log(playerManager + " " + mystats);
            playerCombat.Attack(mystats);
        }
    }

    
}
