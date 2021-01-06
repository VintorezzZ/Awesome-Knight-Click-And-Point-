using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;

    private GameObject instantiatedMouse;
    public GameObject mousePoint;
    private bool _isinstantiatedMouseNull;

   
    void Update()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider is TerrainCollider)
                {
                    Vector3 temp = hit.point;
                    temp.y = 0.35f;

                    if (instantiatedMouse == null)
                    {
                        instantiatedMouse = Instantiate(mousePoint, temp, Quaternion.identity);
                    }
                    else
                    {
                        Destroy(instantiatedMouse);
                        instantiatedMouse = Instantiate(mousePoint, temp, Quaternion.identity);
                    }
                }
            }
        }
    }
}
