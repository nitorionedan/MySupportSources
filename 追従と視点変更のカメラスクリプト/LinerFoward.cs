using UnityEngine;
using System.Collections;


namespace Yaden
{
	public class LinerFoward : MonoBehaviour
	{
		[SerializeField, Range(0, 10)]
		float time = 1;
		
		[SerializeField]
		Vector3	endPosition1;

		//[SerializeField]
		//AnimationCurve curve;

		public Transform target;
		private float   startTime;
		private Vector3 startPosition;

		void OnEnable ()
		{
			if (time <= 0) {
				transform.position = endPosition1;
				enabled = false;
				return;
			}
			
			startTime 		= Time.timeSinceLevelLoad;
//			startPosition 	= transform.position;
			startPosition 	= target.position + new Vector3(3.0f, 1.0f, 0.0f);
			endPosition1	= target.position + new Vector3(0.0f, 1.0f, 2.5f);
		}
		
		void Update ()
		{
			var diff = Time.timeSinceLevelLoad - startTime;
			if (diff > time) {
				transform.position = endPosition1;
				enabled = false;
			}
			
			var rate = diff / time;
			//var pos = curve.Evaluate(rate);
			startPosition 	= target.position + new Vector3(3.0f, 1.0f, 0.0f);
			endPosition1	= target.position + new Vector3(0.0f, 1.0f, 2.5f);
			transform.position = Vector3.Lerp (startPosition,
			                                   endPosition1, rate);
			transform.LookAt (target);
			//transform.position = Vector3.Lerp (startPosition, endPosition, pos);
		}
		
		void OnDrawGizmosSelected ()
		{
			#if UNITY_EDITOR
			
			if( !UnityEditor.EditorApplication.isPlaying || enabled == false ){
				startPosition = target.position;
			}
			
			UnityEditor.Handles.Label(target.position + endPosition1,
			                          (target.position + endPosition1).ToString());
			UnityEditor.Handles.Label(target.position + startPosition,
			                          (target.position + startPosition).ToString());
			#endif
			Gizmos.DrawSphere (target.position + endPosition1, 0.1f);
			Gizmos.DrawSphere (target.position + startPosition, 0.1f);
			
			Gizmos.DrawLine (target.position + startPosition,
			                 target.position + endPosition1);
		}

		public bool isFinish(){
			return enabled;
		}
	}
}
