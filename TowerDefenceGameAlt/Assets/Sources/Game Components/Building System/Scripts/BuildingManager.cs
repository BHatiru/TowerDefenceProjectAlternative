using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private const float MAX_RANGE = 50f;
    [SerializeField] private GameObject[] _objects;
    [SerializeField] private Material _materialDefault;
    [SerializeField] private Material _materialPlacable;
    [SerializeField] private Material _materialImplacable;
    private GameObject _placingObject;

    private Vector3 position;
    private RaycastHit hit;

    public float gridSize;
    public bool isPlacable = true;

    [SerializeField] private LayerMask _mask;
    [SerializeField] private Camera _camera;

    
    void Update()
    {
            
        if(_placingObject != null){
            _placingObject.transform.position = position;
            if(Input.GetMouseButtonDown(0) && isPlacable){
                PlaceObject();
            }
            UpdateMaterials();
        }
        
    }
    private void FixedUpdate(){
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        bool hitSomething = Physics.Raycast(ray, out RaycastHit hit, MAX_RANGE, _mask);

        if(hitSomething){
            position = hit.point;
        }
    }

    private void UpdateMaterials(){
        if(isPlacable){
          
            _placingObject.GetComponent<MeshRenderer>().material = _materialPlacable;
           
            
        }
        if(!isPlacable){
            
            _placingObject.GetComponent<MeshRenderer>().material = _materialImplacable;
            
            
        }
        
    }

    public void SpawnObject(int index){
        _placingObject = Instantiate(_objects[index], position, transform.rotation);
    }

    public void PlaceObject(){
        _placingObject.GetComponent<MeshRenderer>().material = _materialDefault;
        
        _placingObject = null;
    }


    
}
