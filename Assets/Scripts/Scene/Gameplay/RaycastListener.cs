using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastListener : MonoBehaviour
{
    private Camera _mainCam;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(_mainCam.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);

            if (hit.collider != null)
            {
                Tile clicked = hit.transform.GetComponent<Tile>();

                if (clicked)
                    clicked.TileClicked();
            }
        }
    }
}
