using UnityEngine;
using System.Collections;

public class KSMainBoard : MonoBehaviour
{
	readonly int CHARACTER_MAX_ROW		= 5;
	readonly int CHARACTER_MAX_COLUMN	= 10;
	readonly float CHARACTER_PLACEMENT_SCALE_X	= 1.4f;
	readonly float CHARACTER_PLACEMENT_SCALE_Z	= 0.8f;
	readonly float CHARACTER_PLACEMENT_OFFSET_Z =-0.1f;
	//
	readonly private string _fiftyWord = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもや ゆ よらりるれろわをん  零一二三四五六七八九";
	//
	private GameObject[] _characters = new GameObject[80];
	//
	public GameObject _characterPrefab;
	
	// Use this for initialization
	void Start ()
	{
		// set character 
		for (int i = 0; i < CHARACTER_MAX_COLUMN; i++) 
		{
			for (int j = 0; j < CHARACTER_MAX_ROW; j++) 
			{
				int index = i * CHARACTER_MAX_ROW + j;
				
				Vector3 pos	= this.transform.position;
				pos.x += ( 0.5f - (float)(i + 0.5f) / CHARACTER_MAX_COLUMN  ) * CHARACTER_PLACEMENT_SCALE_X;
				pos.z += ( 0.5f - (float)(j + 0.5f) / CHARACTER_MAX_ROW  ) * CHARACTER_PLACEMENT_SCALE_Z + CHARACTER_PLACEMENT_OFFSET_Z;
				pos.y += 0.055f;
				
				_characters[index] = (GameObject)Instantiate( _characterPrefab, pos, _characterPrefab.transform.rotation );
				_characters[index].transform.parent = this.transform;
				
				KSCharacter chara = (KSCharacter)_characters[index].GetComponent("KSCharacter");
				
				if (_fiftyWord [index].Equals (" ")) {
					chara.Character = string.Empty;
				} else {
					chara.Character = _fiftyWord[index].ToString ();
				}
				
				Vector2 size = chara.renderer.material.mainTextureScale;
				Vector2 offset;
				offset.x = i * size.x;
				offset.y = 1.0f - ( j + 1 ) * size.y;
				
				chara.SetTextureOffset (offset);
			}	
		}	
	}	
}