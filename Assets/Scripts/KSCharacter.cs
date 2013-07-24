using UnityEngine;
using System.Collections;


public class KSCharacter : MonoBehaviour 
{
	readonly private float _uvTileX = 12;
	readonly private float _uvTileY = 12;
	//
	private string _character;
	public string Character
	{
		get
		{
			return this._character;
		}
		set
		{
			this._character = value;
		}
	}
	
	public void SetTextureOffset ( Vector2 vec )
	{
		renderer.material.mainTextureOffset = vec;
	}
	
	// Use this for initialization
	void Awake () 
	{
		renderer.material.mainTextureScale = new Vector2( 1.0f / _uvTileX , 1.0f / _uvTileY );
	}
}
