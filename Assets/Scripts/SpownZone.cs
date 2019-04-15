using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownZone : MonoBehaviour
{
    private PlayerController thePlayer;
    private CameraFollow theCamara;

    public Vector2 facingDirection = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamara = FindObjectOfType<CameraFollow>();

        thePlayer.transform.position = this.transform.position;
        theCamara.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamara.transform.position.z);

        thePlayer.lastMovement = facingDirection;
    }
}
