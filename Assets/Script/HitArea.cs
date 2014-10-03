using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class HitArea : MonoBehaviour {
	
	//void Damage(AttackArea.AttackInfo attackInfo)
		void Damage(AttackInfo attackInfo)
	{
		transform.root.SendMessage ("Damage",attackInfo);
	}
}
}