using UnityEngine;
using System.Collections;

public class ConGUI : MonoBehaviour {
	public Transform mainCamera;
	public int rotSpeed = 20;
	public GameObject[] effectObj;
	public GameObject[] effectObProj;
	private int arrayNo = 0;
	
	private GameObject nowEffectObj;


	private float num = 0F;
	private float numBck = 0F;
	private Vector3 initPos;
	
	private bool  haveProFlg = false;
	private GameObject nonProFX;

	private Vector3 tmpPos;

	bool visibleBt (){
		foreach(GameObject tmpObj in effectObProj){
			if( effectObj[ arrayNo ].name == tmpObj.name){
				nonProFX = tmpObj;
				return true;
			}
		}
		return false;
	}
	
	void  Start (){
		tmpPos = initPos = mainCamera.localPosition;
		
		haveProFlg = visibleBt();
	}
	
	void  Update (){
	}
	
	void  OnGUI (){
		
		if (GUI.Button ( new Rect(20, 0, 30, 30), "←")) {//return
			arrayNo --;
			if(arrayNo < 0)arrayNo = effectObj.Length -1;
			//effectOn();
			
			haveProFlg = visibleBt();
		}
		
		if (GUI.Button ( new Rect(50, 0, 200, 30), effectObj[ arrayNo ].name )) {
			//effectOn();
		}
		
		if (GUI.Button ( new Rect(250, 0, 30, 30), "→")) {//next
			arrayNo ++;
			if(arrayNo >= effectObj.Length)arrayNo = 0;
			//effectOn();
			
			haveProFlg = visibleBt();
		}
	}
	

	public int nowBullet()
    {
		return arrayNo;
	}
}