using UnityEngine;

public class OutlineController : MonoBehaviour, IHighlightable
{
    private GameObject outline;

    private void Start()
    {
        outline = transform.GetChild(0).gameObject;
            if (outline.name != "Outline") {
                Debug.LogWarning("Outline object must have tag 'Outline'");
                Destroy(this.gameObject);
            }

        outline.SetActive(false);
    }
    
    public void OnLookAt()
    {
        outline.SetActive(true);
    }

    public void OnLookAway()
    {
        outline.SetActive(false);
    }
}
