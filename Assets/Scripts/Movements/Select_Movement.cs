using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Movement : MonoBehaviour
{
    public Animator anim;

    public void IsTouched()
    {
        Debug.Log("touch!!!!!!!!");
        anim.SetBool("isClicked", true);
    }
}
