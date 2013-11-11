using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public int Health = 100;
	
	public float Speed = 1.0f;
	
	public Vector2 MinMaxX = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// ping pong enemy position
		transform.position = new Vector3(MinMaxX.x + Mathf.PingPong(Time.time * Speed, 1.0f) *
			(MinMaxX.y - MinMaxX.x), transform.position.y, transform.position.z);
	}
	
	void OnTriggerEnter(Collider other){
		Destroy(gameObject);
		Destroy(other.gameObject);
	}
}
