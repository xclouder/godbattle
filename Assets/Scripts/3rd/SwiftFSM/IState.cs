using UnityEngine;
using System.Collections;

public interface IState {

	void Enter();

	void Execute();

	void Exit();

}
