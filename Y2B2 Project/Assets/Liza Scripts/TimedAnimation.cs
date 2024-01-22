using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimedAnimation : MonoBehaviour
{
    public float animationTime;

    public Animator textAnim;
    public Animator imageAnim;

    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(animationTime);
        textAnim.SetTrigger("Play");
        imageAnim.SetTrigger("Play");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayAnimation());
    }
}
