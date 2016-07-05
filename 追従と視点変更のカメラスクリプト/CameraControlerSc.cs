using UnityEngine;
using System.Collections;


namespace Yaden
{
	// カメラの位置、角度を変えるクラス
	public class CameraControlerSc : MonoBehaviour
	{
		public Transform target;			// Playerを入れる
		public ParticleSystem ptsm;			// Particle
		public Vector3 sideOffset   = new Vector3(7.0f, 1.0f, 7.0f);
		public Vector3 fowardOffset = new Vector3(0.0f, 1.0f, 4.0f);

		private Vector3 Sideviewpoint;		// 横からの位置
		private Vector3 Fowardviewpoint;	// 目の前からの位置
		private Quaternion Siderotation;	// 横からの角度
		private Quaternion Fowardrotation;	// 目の前からの角度
		private bool f_side;				// 横側かどうか
		private bool f_move;				// カメラ遷移中かどうか

		// Lerp のため
		public  Transform startPoint, endPoint;
		public  float speed = 1.0F;
		private float startTime;
		private float journeyLength;


		void Start ()
		{
			f_side 			= true;
			f_move 			= true;
			Siderotation    = Quaternion.Euler(0.0f, 270.0f, 0.0f);
			Fowardrotation  = Quaternion.Euler(0.0f, 180.0f, 0.0f);
			GetComponent<LinerSide>().enabled   = true;
			GetComponent<LinerFoward>().enabled = false;
			GetComponent<Transform> ().position = new Vector3 (target.position.x + sideOffset.x,
							                                  target.position.y + sideOffset.y,
			                                                  target.position.z + sideOffset.z);
		}

		void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Space)) {
				f_side = !f_side;
				ptsm.Play();
				if(f_side)
				{
					GetComponent<LinerSide>().enabled   = true;
					GetComponent<LinerFoward>().enabled = false;
				}else{
					GetComponent<LinerFoward>().enabled = true;
					GetComponent<LinerSide>().enabled   = false;
				}
			}

			if (f_side && GetComponent<LinerFoward>().isFinish() == false
			    && GetComponent<LinerSide>().isFinish() == false)
			{
//				transform.rotation=Quaternion.Slerp(transform.rotation,
//				                                    Quaternion.LookRotation((Sideviewpoint-transform.position).normalized),
//				                                    0.1f*Time.deltaTime);

//				transform.rotation = Siderotation;
				Vector3 cameraPoint = new Vector3 (target.position.x + sideOffset.x,
				                                   target.position.y + sideOffset.y,
				                                   target.position.z + sideOffset.z);

				GetComponent<Transform>().position = cameraPoint;
			}
			if(!f_side && GetComponent<LinerFoward>().isFinish() == false
			   && GetComponent<LinerSide>().isFinish() == false)
			{
//				transform.rotation	= Fowardrotation;
				Vector3 cameraPoint = new Vector3 (target.position.x + fowardOffset.x,
				                                   target.position.y + fowardOffset.y,
				                                   target.position.z + fowardOffset.z);

				GetComponent<Transform>().position = cameraPoint;
			}

			transform.LookAt (target);
		}
	}
}