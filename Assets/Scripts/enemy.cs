using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    protected Animator anim;
    protected AudioSource death;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        death = GetComponent<AudioSource>();
    }

    public void JumpedOn()
    {
        anim.SetTrigger("Death");
        death.Play();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
