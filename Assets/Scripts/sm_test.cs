using UnityEngine;
using System.Collections;

public class sm_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKey( KeyCode.A ) )
		{
			SpidarMouse.Instance.SetForce2D(-1.0f, 0.0f );
		}
		else if ( Input.GetKey( KeyCode.D ) )
		{
			SpidarMouse.Instance.SetForce2D( 1.0f, 0.0f );
		}
		else if ( Input.GetKey( KeyCode.W ) )
		{
			SpidarMouse.Instance.SetForce2D( 0.0f,-1.0f );
		}
		else if ( Input.GetKey( KeyCode.S ) )
		{
			SpidarMouse.Instance.SetForce2D( 0.0f, 1.0f );
		}
		else
		{
			SpidarMouse.Instance.SetForce2D( 0.0f, 0.0f );
		}
	}
	
	
}
