using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchInputMovement : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
	GameObject Player;
	float offDistance;
	float startPos;
	private Camera m_camera;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("player");
		m_camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void OnPointerDown(PointerEventData ped){
		offDistance = Player.transform.position.x - m_camera.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Player.transform.position.y, Player.transform.position.z)).x ;
	}

	public virtual void OnDrag(PointerEventData ped){
		if(Player == null)
			return;
		//Player.transform.position = new Vector2 (Mathf.Clamp(((Input.mousePosition.x-83f) * 0.05f)/*Time.deltaTime*/, camera.ViewportToWorldPoint (new Vector3 (0, 0)).x +0.48f, camera.ViewportToWorldPoint (new Vector3 (1, 0)).x -0.48f), Player.transform.position.y);

		Vector3 pos = new Vector3 (Input.mousePosition.x, Player.transform.position.y, Player.transform.position.z);

		Player.transform.position = new Vector2 (Mathf.Clamp(offDistance + m_camera.ScreenToWorldPoint(pos).x/*Time.deltaTime*/, m_camera.ViewportToWorldPoint (new Vector3 (0, 0)).x +0.48f, m_camera.ViewportToWorldPoint (new Vector3 (1, 0)).x -0.48f), Player.transform.position.y);

	}

	public virtual void OnPointerUp(PointerEventData ped){

	}
}
