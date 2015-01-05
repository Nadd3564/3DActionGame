using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cradle.FM;


/// @http://creativecommons.org/licenses/by-sa/3.0/
namespace Cradle.FM{
	
	public enum Transition
	{
		None = 0,
		SawPlayer,
		ReachPlayer,
		LostPlayer,
		NoHealth,
	}
	
	public enum FSMStateID
	{
		None = 0,
		Searching,
		Approaching,
		Attacking,
		Dead,
	}
	
	
	public class AdvancedFSM : FSM {
		private List<FSMState> fsmStates;

		//fsmStates
		private FSMStateID currentStateID;
		public FSMStateID CurrentStateID{ get { return currentStateID; }}
		
		private FSMState currentState;
		public FSMState CurrentState { get { return currentState; } }
		
		
		public AdvancedFSM(){
			fsmStates = new List<FSMState> ();
		}

		//新たに状態を追加
		public void AddFSMState(FSMState fsmState){
			//引数の確認
			if(fsmState == null){
				Debug.LogError("FSM ERROR: Null reference is not allowed");
			}

			//状態が存在しないときの条件式
			if(fsmStates.Count == 0)
			{
				fsmStates.Add(fsmState);
				currentState = fsmState;
				currentStateID = fsmState.ID;
				return;
			}
			
			//状態が存在する場合の条件式
			foreach(FSMState state in fsmStates)
			{
				if(state.ID == fsmState.ID)
				{
					Debug.LogError("FSM ERROR: 既に存在する状態をリストに追加しようとしています。");
					return;
				}
			}
			
			//状態をリストに追加する
			fsmStates.Add (fsmState);
		}
		
		//状態を削除する場合に使う
		public void DeleteState(FSMStateID fsmState)
		{
			//削除する前に、状態が空でないか確認
			if (fsmState == FSMStateID.None)
			{
				Debug.LogError("FSM ERROR: 不正なIDです。");
				return;
			}
			
			//状態を削除
			foreach(FSMState state in fsmStates)
			{
				if(state.ID == fsmState)
				{
					fsmStates.Remove(state);
					return;
				}
			}
			Debug.LogError ("FSM ERROR: 指定された状態が存在しません。削除に失敗しました。");
		}
		
		//このメソッドで遷移させる
		public void RunTransition(Transition trans)
		{
			//引数の確認
			if(trans == Transition.None)
			{
				Debug.LogError("FSM ERROR: Null遷移は不正です。");
				return;
			}
			
			//currentStateが指定の遷移についての状態を持つか
			FSMStateID id = currentState.GetOutputState (trans);
			if(id == FSMStateID.None)
			{
				Debug.LogError("FSM ERROR: 現在の状態はこの遷移が指定する状態を持ちません。");
				return;
			}
			
			//currentStateIDとcurrentStateを更新
			currentStateID = id;
			foreach(FSMState state in fsmStates)
			{
				if(state.ID == currentStateID)
				{
					currentState = state;
					break;
				}
			}
		}
	}
}
