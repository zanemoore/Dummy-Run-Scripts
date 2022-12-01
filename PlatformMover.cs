using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    /// Level 2

    [SerializeField] private float moveUnits;
    [SerializeField] private float moveTime;
    [SerializeField] private float moveDelay;
    [SerializeField] private float timeBetween;

    // allows the pillar platform in Level 2 to move vertically
    private IEnumerator MovePlatform()
    {
        yield return new WaitForSeconds(moveDelay);
        float totalTime = 0;
        float originalY = transform.position.y;

        while (totalTime < moveTime)
        {
            float y = Mathf.Lerp(0, moveUnits, totalTime / moveTime);
            transform.position = new Vector3(transform.position.x, originalY + y, transform.position.z);
            totalTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator ReversePlatform()
    {
        yield return new WaitForSeconds(timeBetween);
        float totalTime = 0;
        float originalY = transform.position.y;

        while (totalTime < moveTime)
        {
            float y = Mathf.Lerp(0, moveUnits * -1, totalTime / moveTime);
            transform.position = new Vector3(transform.position.x, originalY + y, transform.position.z);
            totalTime += Time.deltaTime;
            yield return null;
        }
    }

    // triggers the pillar movement once the player enters a specific area
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(MovePlatform());
        }
    }

    // stops the pillar movement once the player exits a specific area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ReversePlatform());
        }
    }
}
