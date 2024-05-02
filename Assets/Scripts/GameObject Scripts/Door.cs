using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class Door : MonoBehaviour, IPowerable
{
    private Vector3 originalPosition;
    private Vector3 openPosition;
    [SerializeField] private int doorOpenHeight = 4;
    private float doorSpeed = 10f;

    SoundManager Soundman;

    private void Start()
    {
        originalPosition = transform.position;
        openPosition = originalPosition + new Vector3(0, doorOpenHeight, 0);
        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
    }

    public void PowerOn()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDoor(openPosition));

        Debug.Log("Opening: " + this.gameObject.name);
    }

    public void PowerOff()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDoor(originalPosition));
    }

    private IEnumerator MoveDoor(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, doorSpeed * Time.deltaTime);
            yield return null;
        }

        if (target == openPosition)
        {
            Soundman.playSFX("Door_open");
        }
        else if (target == originalPosition)
        {
            Soundman.playSFX("Door_closing");
        }
    }
}