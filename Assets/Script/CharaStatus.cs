using UnityEngine;
using System.Collections;

public class CharaStatus : MonoBehaviour {
	public int HP = 100;
	public int MaxHP = 100;
	public int Power = 10;
	public GameObject lastAttackTarget = null;
	public string charactername = "Player";
	public bool attacking = false;
	public bool died = false;
}
