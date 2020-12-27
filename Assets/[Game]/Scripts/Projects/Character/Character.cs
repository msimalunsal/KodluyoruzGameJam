﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CharacterControllerType { Player, AI }

public class Character : MonoBehaviour, IDamageable
{

    public CharacterControllerType CharacterControllerType = CharacterControllerType.Player;

    #region Components
    private Rigidbody rigidbody;
    public Rigidbody Rigidbody { get { return (rigidbody == null) ? rigidbody = GetComponent<Rigidbody>() : rigidbody; } }

    private Collider collider;
    public Collider Collider { get { return (collider == null) ? collider = GetComponent<Collider>() : collider; } }
    #endregion

    #region Events
    [HideInInspector]
    public UnityEvent OnCharacterHit = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterRevive = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterSwitchLane = new UnityEvent();
    #endregion

    #region Properties
    private bool isDead;
    public bool IsDead { get { return (isDead); } set { isDead = value; } }
    [SerializeField]
    private bool isControlable;
    public bool IsControlable { get { return isControlable; } set { isControlable = value; } }
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        CharacterManager.Instance.AddCharacter(this);

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        CharacterManager.Instance.RemoveCharacter(this);
    }
    #endregion

    #region Public Methods
    public void KillCharacter()
    {
        if (IsDead)
            return;

        IsDead = true;
        IsControlable = false;
        OnCharacterHit.Invoke();

        if (CharacterControllerType == CharacterControllerType.Player)
            EventManager.OnLevelFail.Invoke();
    }

    public void ReviveCharacter()
    {
        if (!IsDead)
            return;

        IsDead = false;
        IsControlable = true;
        OnCharacterRevive.Invoke();
    }

    public void Damage()
    {
        KillCharacter();
        Debug.Log("Hasar aldım");
    }
    #endregion
}
