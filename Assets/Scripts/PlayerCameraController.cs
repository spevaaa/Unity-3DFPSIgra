using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float mouseSensitivity = 2;
    public float smoothing = 2;

    private GameObject player;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPosition;

    public Texture2D crosshairTexture;
    private Rect crosshairPosition;
    public float crosshairScale = 1;

    public AudioSource shootingAudioSource;

    private void Start()
    {
        player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        shootingAudioSource = GetComponent<AudioSource>();
    }

    private void OnGUI()
    {
        //if not paused
        if (Time.timeScale != 0)
        {
            if (crosshairTexture != null)
                GUI.DrawTexture(new Rect((Screen.width - crosshairTexture.width * crosshairScale) / 2, (Screen.height - crosshairTexture.height * crosshairScale) / 2, crosshairTexture.width * crosshairScale, crosshairTexture.height * crosshairScale), crosshairTexture);
            else
                Debug.Log("No crosshair texture set in the Inspector");
        }
    }

    private void Update()
    {
        RotateCamera();
        CheckForShooting();
    }

    private void RotateCamera()
    {
        Vector2 inputValue = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        inputValue = Vector2.Scale(inputValue, new Vector2(mouseSensitivity * smoothing, mouseSensitivity * smoothing));

        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputValue.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputValue.y, 1f / smoothing);

        currentLookingPosition += smoothedVelocity;

        currentLookingPosition.y = Mathf.Clamp(currentLookingPosition.y, -80f, 80f);

        transform.localRotation = Quaternion.AngleAxis(-currentLookingPosition.y, Vector3.right);

        player.transform.localRotation = Quaternion.AngleAxis(currentLookingPosition.x, player.transform.up);
    }

    private void CheckForShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {

            shootingAudioSource.Play();
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.name);

                /* Ovo je za iduću vježbu
                if(hit.collider.tag == "Enemy")
                {
                    EnemyHealth eHealth = hit.collider.GetComponent<EnemyHealth>();
                    eHealth.TakeDamage(10);
                }
                */
            }
        }
    }
}
