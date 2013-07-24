using UnityEngine;

public class KSCoin : MonoBehaviour
{

	readonly private Vector3 _originalPosition = new Vector3( 0.0f, 0.0f, 0.5f);
	public Vector2 _pos;
	private Vector2 _previousPos;
	
	// Keep Character if stopping Time is over _keepIntervalSec
	public float _keepIntervalSec = 1.0f;
	private float _stoppingTime = 0.0f;
	
	public float acceptablePosDef = 0.05f;
	
	//
	public string _characterBuffer = System.String.Empty;
	public string _currentCharacter;
	
	// For Mouse Controll
	private float _radius = 0.0f;
	private Vector3 _screenPoint;
	private Vector3 _mouseCenterOffset;
	private bool _isBeDragging = false;
	
	void Start ()
	{
		transform.position = _originalPosition;
		_radius = ((BoxCollider)collider).size.x * transform.localScale.x * 0.5f;
	}
	
	void Update ()
	{
		if ( Input.GetKeyDown("c") )
		{
			Clear();
		}
		
		if ( Input.GetKeyDown("r") )
		{
			Reset();
		}
		
		if ( _isBeDragging )
		{
			_pos = new Vector2 (transform.position.x, transform.position.z);
				
			if ( _pos == _previousPos )
			{
				_stoppingTime += Time.deltaTime;	
			}
			else
			{
				_stoppingTime = 0.0f;	
			}
			
			_previousPos = _pos;
			
			if ( _stoppingTime > _keepIntervalSec )
			{
				 Debug.Log("Append Character");
				_characterBuffer += _currentCharacter;
				_stoppingTime = 0.0f;
			}
		}
	}
	
	public void Clear()
	{
		_currentCharacter = string.Empty;
		_characterBuffer = string.Empty;
	}
	
	public void Reset()
	{
		Clear();
		transform.position = _originalPosition;
	}
	
	void OnTriggerEnter( Collider other )
	{
		Debug.Log("TriggerEnter");
		if ( other.gameObject.tag == "KSCharacter" )
		{
			_currentCharacter = ((KSCharacter)other.gameObject.GetComponent<KSCharacter>()).Character;
		}
		else
		{
			_currentCharacter = string.Empty;
		}
	}
	
	void OnTriggerExit( Collider other )
	{
		_stoppingTime = 0.0f;
		_currentCharacter = string.Empty;
	}

	
	void OnMouseDown ()
	{
		Vector3 leftBottom = new Vector3( transform.position.x - _radius, transform.position.y, transform.position.z - _radius );
		Vector3 rightTop   = new Vector3( transform.position.x + _radius, transform.position.y, transform.position.z + _radius );
		
		Vector3 screenPointLeftBottom  = Camera.mainCamera.WorldToScreenPoint(leftBottom);
		Vector3 screenPointRightTop = Camera.mainCamera.WorldToScreenPoint(rightTop);
		
		// if mouse is in rectangle		
		if ( screenPointLeftBottom.x < Input.mousePosition.x && Input.mousePosition.x < screenPointRightTop.x
			&& screenPointLeftBottom.y < Input.mousePosition.y && Input.mousePosition.y < screenPointRightTop.y )
		{
			_screenPoint = Camera.mainCamera.WorldToScreenPoint(transform.position);
			Debug.Log("Cricked Coin");	
			_isBeDragging = true;
		}
		
		_mouseCenterOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
	}
	
	void OnMouseUp ()
	{
		_isBeDragging = false;	
	}
	
	
	void OnMouseDrag ()
	{
		if ( _isBeDragging )
		{
	        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
	        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + _mouseCenterOffset;
	        transform.position = currentPosition;
		}
	}

}
