using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapTransition : MonoBehaviour
{
    public Vector2 cameraMaxChange;
    public Vector2 cameraMinChange;
    public Vector3 playerChange;
    private CameraMovement cam;

    public bool needText;
    public string placeName;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            cam.minPosition += cameraMinChange;
            cam.maxPosition += cameraMaxChange;
            other.transform.position += playerChange;
            if (needText)
            {
                UIPlace.Instance.Display(placeName);
            }
        }
    }
}
