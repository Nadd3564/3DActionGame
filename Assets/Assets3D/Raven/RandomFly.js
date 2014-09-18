#pragma strict

public var speed : float = 5;
public var maxHeadingChange : float = 30;

private var heading : float;
private var targetRotation : Vector3;

public var flyAnimation : AnimationClip;
public var flyAnimationSpeed : float = 1;


function Start ()
	{
	heading = Random.Range(0, 360);
	transform.eulerAngles = new Vector3(0, heading, 0);
	StartCoroutine(NewHeading());
	}
function Update ()
	{
	transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * 2);
    transform.Translate(Vector3(0,0,speed)* Time.deltaTime, Space.Self);
    animation[flyAnimation.name].speed = flyAnimationSpeed;
	animation.CrossFade(flyAnimation.name, 0.2);
	}
function NewHeading ()
	{
	while (true) 
		{
		NewHeadingRoutine();
		yield WaitForSeconds(3);
		}
    }

function NewHeadingRoutine()
	{
	var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
    var ceil  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
    heading = Random.Range(floor, ceil);
    targetRotation = new Vector3(0, heading, 0);
    }