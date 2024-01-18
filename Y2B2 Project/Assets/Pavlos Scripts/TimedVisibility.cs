using UnityEngine;
using System.Collections;

public class TimedVisibility : MonoBehaviour
{
    public float delayBeforeAppearing = 5.0f; // Time in seconds before the object appears

    private void Start()
    {
        // Make the object invisible at the start
        gameObject.SetActive(false);

        // Start the coroutine to make the object appear after a delay
        StartCoroutine(MakeVisibleAfterDelay());
    }

    IEnumerator MakeVisibleAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeAppearing);

        // Make the object visible
        gameObject.SetActive(true);
    }
}
