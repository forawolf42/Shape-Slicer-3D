using UnityEngine;

public class CutScript : MonoBehaviour
{
	public static bool Cut(Transform victim, Vector3 _pos)
	{
		Vector3 pos = new Vector3(_pos.x, victim.position.y, victim.position.z);
		Vector3 victimScale = victim.localScale;
		float distance = Vector3.Distance(victim.position, pos);
		if (distance >= victimScale.x / 2) return false;


		//Büyük Objeyi Yok Et
		Vector3 leftPoint = victim.position - Vector3.right * victimScale.x / 2.1f;
		Vector3 rightPoint = victim.position + Vector3.right * victimScale.x / 2.1f;
		Material mat = victim.GetComponent<MeshRenderer>().material;
		Destroy(victim.gameObject);

		//Sað Taraf
		GameObject rightSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		rightSideObj.transform.position = (rightPoint + pos) / 2;
		float rightWidth = Vector3.Distance(pos, rightPoint);
		rightSideObj.transform.localScale = new Vector3(rightWidth, victimScale.y, victimScale.z);
		rightSideObj.AddComponent<Rigidbody>().mass = 1;
		rightSideObj.GetComponent<MeshRenderer>().material = mat;

		//Hareket
		rightSideObj.AddComponent<SwipeManager>();
		rightSideObj.AddComponent<JellyMesh>();


		//Sol Taraf
		GameObject leftSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		leftSideObj.transform.position = (leftPoint + pos) / 2;
		float leftWidth = Vector3.Distance(pos, leftPoint);
		leftSideObj.transform.localScale = new Vector3(leftWidth, victimScale.y, victimScale.z);
		leftSideObj.AddComponent<Rigidbody>().mass = 1f;
		leftSideObj.GetComponent<MeshRenderer>().material = mat;
		//Hareket
		leftSideObj.AddComponent<SwipeManager>();
		leftSideObj.AddComponent<JellyMesh>();
		return true;
	}
}
