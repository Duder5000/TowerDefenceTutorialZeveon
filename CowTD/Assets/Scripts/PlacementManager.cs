using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public GameObject basicTowerObject;

    public Camera cam;

    private GameObject dummyPlacement;
    private GameObject hoverTile;

    public LayerMask mask;

    public bool isBuilding;

    public void Start() {
        StartBuilding();
    }

    public Vector2 GetMousePosition() {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

   public void GetCurrentHoverTile() {
        Vector2 mousePosition = GetMousePosition();

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0, 0), 0.1f, mask, -100, 100);

        if (hit.collider != null) {
           if (MapGenerator.mapTiles.Contains(hit.collider.gameObject)) {
                if (!MapGenerator.pathTiles.Contains(hit.collider.gameObject)) {
                      hoverTile = hit.collider.gameObject; 
                 }

            }
        }
    }

    public void StartBuilding() {
        isBuilding = true;

        dummyPlacement = Instantiate(basicTowerObject);

        if (dummyPlacement.GetComponent<Tower>() != null) {
            Destroy(dummyPlacement.GetComponent<Tower>());
        }

        if (dummyPlacement.GetComponent<BarrelRotation>() != null) {
            Destroy(dummyPlacement.GetComponent<BarrelRotation>());
        }

    }

    public void EndBuilding()
    {
        isBuilding = false;

    }


    public void Update() {
        if (isBuilding == true) {
            if (dummyPlacement != null) {
                GetCurrentHoverTile();

                dummyPlacement.transform.position = hoverTile.transform.position;
            }
        }
        
    }

}
