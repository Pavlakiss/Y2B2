using UnityEngine;
using System.Collections;

public class ScaleImage : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(1f, 1f, 1f); // The final scale you want your image to have
    public float duration = 5.0f; // Duration in seconds for the scale down animation

    private Vector3 initialScale; // To remember the scale your image starts with

    private void Start()
    {
        initialScale = transform.localScale; // Remember the initial scale
        StartCoroutine(ScaleDown());
    }

    IEnumerator ScaleDown()
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale; // Ensure the target scale is set precisely at the end
    }
}
