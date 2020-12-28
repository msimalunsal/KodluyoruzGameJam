using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    Character character;
    Character Character { get { return (character == null) ? character = GetComponentInParent<Character>() : character; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.AddListener(() => InvokeTrigger("Walk"));
        EventManager.OnLevelFinish.AddListener(() => Animator.Rebind());
        Character.OnCharacterRevive.AddListener(() => InvokeTrigger("Walk"));
       // Character.OnCharacterHit.AddListener(() => InvokeTrigger("Jump"));
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.RemoveListener(() => InvokeTrigger("Walk"));
        EventManager.OnLevelFinish.AddListener(() => Animator.Rebind());
       //Character.OnCharacterHit.RemoveListener(() => InvokeTrigger("Jump"));
    }

    private void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        Animator.SetBool("Walk", Character.IsControlable);
    }

    private void InvokeTrigger(string value)
    {
        Animator.SetBool(value , true);
    }

}

