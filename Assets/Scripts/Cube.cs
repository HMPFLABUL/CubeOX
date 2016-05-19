using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Cube : MonoBehaviour {


    
    //private GameObject[] cube;
    public float speed;
    private bool allowRot;
    [SerializeField]
    private List<GameObject> cube = new List<GameObject>();
    private MeshFilter[] temp;
    public static bool rotateCube;
    public GameObject rotator;
    

    void OnEnable () {
        rotateCube = false;
        temp = GetComponentsInChildren<MeshFilter>();
        allowRot = true;
       // cube = new GameObject[temp.Length];
        foreach(MeshFilter m in temp)
        {
            cube.Add(m.gameObject);
        }
        
       // RotateY(0);
        //RotateZ(0);


    }
	void Update () {
	if(rotateCube)
        {
            StartCoroutine(rotateWholeCube(new Vector3(45, 135, 0)));
            rotateCube = false;
        }
	}

    public void RotateZ(int side)
    {
        if (allowRot)
        {
            foreach (GameObject obj in cube)
            {

                if ((int)obj.transform.localPosition.z == side)
                {

                    obj.transform.SetParent(rotator.transform);
                }

            }

            StartCoroutine(LerpRot(new Vector3(0f, 0f, -90f)));



        }
    }

    public void RotateY(int side)
    {
        if (allowRot)
        {
            foreach (GameObject obj in cube)
            {

                if ((int)obj.transform.localPosition.y == side)
                {

                    obj.transform.SetParent(rotator.transform);
                }

            }

            StartCoroutine(LerpRot(new Vector3(0f, -90f, 0f)));

        }
    }

    public void RotateX(int side)
    {
        if (allowRot)
        {
            foreach (GameObject obj in cube)
            {

                if ((int)obj.transform.localPosition.x == side)
                {

                    obj.transform.SetParent(rotator.transform);
                }

            }

            StartCoroutine(LerpRot(new Vector3(-90f, 0f, 0f)));


        }
    }
    

    private IEnumerator LerpRot(Vector3 end)
    {
        allowRot = false;
        while (rotator.transform.localRotation != Quaternion.Euler(end))
        {
           // Debug.Log("lop");
            rotator.transform.localRotation = Quaternion.RotateTowards(rotator.transform.localRotation, Quaternion.Euler(end), speed * Time.fixedDeltaTime);
            yield return null;

        }
        rotator.transform.localRotation = Quaternion.Euler(end);
        
        yield return null;
        foreach (MeshFilter obj in rotator.GetComponentsInChildren<MeshFilter>())
        {
           // Debug.Log(obj.gameObject.name);
            obj.gameObject.transform.SetParent(this.transform);
            obj.transform.localPosition = new Vector3(
                Mathf.Round(obj.transform.localPosition.x),
                 Mathf.Round(obj.transform.localPosition.y),
                 Mathf.Round(obj.transform.localPosition.z)
                );


        }
        rotator.transform.localRotation = Quaternion.Euler(Vector3.zero);
        allowRot = true;
    }

    private IEnumerator rotateWholeCube(Vector3 finalRotation)
    {
        while (transform.localRotation != Quaternion.Euler(finalRotation))
        {
            // Debug.Log("lop");
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(finalRotation),speed*Time.fixedDeltaTime);
            yield return null;

        }
        yield return new WaitForSeconds(1f);
        yield return rotateWholeCubeBack(new Vector3(45f, 315, 0));
    }
    private IEnumerator rotateWholeCubeBack(Vector3 finalRotation)
    {
        while (transform.localRotation != Quaternion.Euler(finalRotation))
        {
            // Debug.Log("lop");
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(finalRotation), speed * Time.fixedDeltaTime);
            yield return null;

        }
        yield return null;
    }

}
