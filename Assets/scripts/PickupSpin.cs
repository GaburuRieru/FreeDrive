using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpin : MonoBehaviour {

    private Transform tr;

	void Start () {
        tr = this.transform;
        StartCoroutine(Spin());
	}
	
    IEnumerator Spin()
    {
        while (true)
        {
            Vector3 rot = tr.rotation.eulerAngles;
            rot.y += 2f;
            Vector3 newRot = rot;
            Quaternion newquat = Quaternion.Euler(newRot);
            tr.rotation = newquat;
            //bug.Log(rot);
            yield return new WaitForSeconds(Time.deltaTime / 2);
        }
       
    }
}
