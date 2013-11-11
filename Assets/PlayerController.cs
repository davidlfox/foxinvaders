using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public int Health = 100;
	
	public float Speed = 10.0f;
	
	public float ReloadDelay = 0.2f;
	
	public Vector2 MinMaxX = Vector2.zero;
	
	public GameObject PrefabAmmo = null;
	
	public GameObject GunPosition = null;
	
	private bool WeaponsActivated = true;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Mathf.Clamp(transform.position.x + 
			Input.GetAxis("Horizontal") * Speed * Time.deltaTime, MinMaxX.x, MinMaxX.y), 
			transform.position.y, transform.position.z);		
	}
	
	void LateUpdate(){
		if(Input.GetButton("Fire1") && WeaponsActivated){
			Instantiate(PrefabAmmo, GunPosition.transform.position, PrefabAmmo.transform.rotation);
			
			WeaponsActivated = false;
			
			Invoke ("ActivateWeapons", ReloadDelay);
		}
	}
	
	void ActivateWeapons(){
		WeaponsActivated = true;
	}
}
