using NUnit.Framework;
using System;
using NSubstitute;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("CharaMove Test")]
	public class CharaMoveTest
	{
		public IMoveController move;
		public CharaMoveController cMove;
		
		[SetUp] public void Init()
		{ 
			move = GetMoveMock ();
			move.LessThanVMagnitude ().Returns (true);
			move.IsGrounded ().Returns (true);
			cMove = GetControllerMock (move);	
		}
		
		[TearDown] public void Cleanup()
		{
			
		}


		//データ型テスト（オブジェクト）
		[Test]
		[Category ("GravityPower Type Test")]
		public void GravityPowerTypeTest() 
		{
			Assert.That (cMove.GetGravityPower(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("StoppingDistance Type Test")]
		public void StoppingDistanceTypeTest() 
		{
			Assert.That (cMove.GetStoppingDist(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("walkSpeed Type Test")]
		public void walkSpeedTypeTest() 
		{
			Assert.That (cMove.GetWalkSpeed(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("rotationSpeed Type Test")]
		public void rotationSpeedTypeTest() 
		{
			Assert.That (cMove.GetRotationSpeed(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("distance Type Test")]
		public void distanceTypeTest() 
		{
			Assert.That (cMove.GetDistance(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("arrived Type Test")]
		public void arrivedTypeTest() 
		{
			Assert.That (cMove.IsArrived(), Is.TypeOf(typeof(bool)));		
		}

		[Test]
		[Category ("forceRotate Type Test")]
		public void forceRotateTypeTest() 
		{
			Assert.That (cMove.IsForceRotate(), Is.TypeOf(typeof(bool)));		
		}

		[Test]
		[Category ("velocity Type Test")]
		public void velocityTypeTest() 
		{
			Assert.That (cMove.getVelocity(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("forceRotateDirection Type Test")]
		public void forceRotateDirectionTypeTest() 
		{
			Assert.That (cMove.getForceRotateDirection(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("destination Type Test")]
		public void destinationTypeTest() 
		{
			Assert.That (cMove.getDestination(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("destinationXZ Type Test")]
		public void velocitydestinationXZTypeTest() 
		{
			Assert.That (cMove.getDestinationXZ(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("direction Type Test")]
		public void directionTypeTest() 
		{
			Assert.That (cMove.getDirection(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("currentVelocity Type Test")]
		public void currentVelocityTypeTest() 
		{
			Assert.That (cMove.getCurrentVelocity(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("snapGround Type Test")]
		public void snapGroundTypeTest() 
		{
			Assert.That (cMove.getSnapGround(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("characterTargetRotation Type Test")]
		public void characterTargetRotationTypeTest() 
		{
			Assert.That (cMove.getCharacterTargetRot(), Is.TypeOf(typeof(string)));		
		}


		//データ存在テスト(オブジェクト)
		[Test]
		[Category ("velocity NotEmpty Test")]
		public void IsNotEmptyVelocityTest() 
		{
			Assert.IsNotEmpty (cMove.getVelocity());		
		}

		[Test]
		[Category ("forceRotateDirection NotEmpty Test")]
		public void IsNotEmptyForceRotateDirectionTest() 
		{
			Assert.IsNotEmpty (cMove.getForceRotateDirection());		
		}

		[Test]
		[Category ("destination NotEmpty Test")]
		public void IsNotEmptyDestinationTest() 
		{
			Assert.IsNotEmpty (cMove.getDestination());		
		}

		[Test]
		[Category ("destinationXZ NotEmpty Test")]
		public void IsNotEmptyDestinationXZTest() 
		{
			Assert.IsNotEmpty (cMove.getDestinationXZ());		
		}

		[Test]
		[Category ("direction NotEmpty Test")]
		public void IsNotEmptyDirectionTest() 
		{
			Assert.IsNotEmpty (cMove.getDirection());		
		}

		[Test]
		[Category ("currentVelocity NotEmpty Test")]
		public void IsNotEmptyCurrentVelocityTest() 
		{
			Assert.IsNotEmpty (cMove.getCurrentVelocity());		
		}

		[Test]
		[Category ("snapGround NotEmpty Test")]
		public void IsNotEmptySnapGroundTest() 
		{
			Assert.IsNotEmpty (cMove.getSnapGround());		
		}

		[Test]
		[Category ("characterTargetRotation NotEmpty Test")]
		public void IsNotEmptyCharacterTargetRotationTest() 
		{
			Assert.IsNotEmpty (cMove.getCharacterTargetRot());		
		}


		//Null値テスト（オブジェクト）
		[Test]
		[Category ("GravityPower NotNull Test")]
		public void NotNullGravityPowerTest() 
		{
			Assert.NotNull (cMove.GetGravityPower());		
		}

		[Test]
		[Category ("StoppingDistance NotNull Test")]
		public void NotNullStoppingDistanceTest() 
		{
			Assert.NotNull (cMove.GetStoppingDist());		
		}

		[Test]
		[Category ("walkSpeed NotNull Test")]
		public void NotNullWalkSpeedTest() 
		{
			Assert.NotNull (cMove.GetWalkSpeed());		
		}

		[Test]
		[Category ("rotationSpeed NotNull Test")]
		public void NotNullRotationSpeedTest() 
		{
			Assert.NotNull (cMove.GetRotationSpeed());		
		}

		[Test]
		[Category ("distance NotNull Test")]
		public void NotNullDistanceTest() 
		{
			Assert.NotNull (cMove.GetDistance());		
		}

		[Test]
		[Category ("arrived NotNull Test")]
		public void NotNullArrivedTest() 
		{
			Assert.NotNull (cMove.IsArrived());		
		}

		[Test]
		[Category ("forceRotate NotNull Test")]
		public void NotNullForceRotateTest() 
		{
			Assert.NotNull (cMove.IsForceRotate());		
		}

		[Test]
		[Category ("velocity NotNull Test")]
		public void NotNullVelocityTest() 
		{
			Assert.NotNull (cMove.getVelocity());		
		}

		[Test]
		[Category ("forceRotateDirection NotNull Test")]
		public void NotNullForceRotateDirectionTest() 
		{
			Assert.NotNull (cMove.getForceRotateDirection());		
		}

		[Test]
		[Category ("destination NotNull Test")]
		public void NotNullDestinationTest() 
		{
			Assert.NotNull (cMove.getDestination());		
		}

		[Test]
		[Category ("destinationXZ NotNull Test")]
		public void NotNullDestinationXZTest() 
		{
			Assert.NotNull (cMove.getDestinationXZ());		
		}

		[Test]
		[Category ("direction NotNull Test")]
		public void NotNullDirectionTest() 
		{
			Assert.NotNull (cMove.getDirection());		
		}

		[Test]
		[Category ("currentVelocity NotNull Test")]
		public void NotNullCurrentVelocityTest() 
		{
			Assert.NotNull (cMove.getCurrentVelocity());		
		}

		[Test]
		[Category ("snapGround NotNull Test")]
		public void NotNullSnapGroundTest() 
		{
			Assert.NotNull (cMove.getSnapGround());		
		}

		[Test]
		[Category ("characterTargetRotation NotNull Test")]
		public void NotNullCharacterTargetRotationTest() 
		{
			Assert.NotNull (cMove.getCharacterTargetRot());		
		}


		//正常値テスト
		[Test]
		[Category ("GravityPower Test")]
		public void GravityPowerTest() 
		{
			float f = 9.8f;
			Assert.That (cMove.GetGravityPower(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("StoppingDistance Test")]
		public void StoppingDistanceTest() 
		{
			float f = 0.6f;
			Assert.That (cMove.GetStoppingDist(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("walkSpeed Test")]
		public void WalkSpeedTest() 
		{
			float f = 6.0f;
			Assert.That (cMove.GetWalkSpeed(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("rotationSpeed Test")]
		public void rotationSpeedTest() 
		{
			float f = 360.0f;
			Assert.That (cMove.GetRotationSpeed(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("distance Test")]
		public void distanceTest() 
		{
			float f = 0.0f;
			Assert.That (cMove.GetDistance(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("arrived Test")]
		public void arrivedTest() 
		{
			Assert.False (cMove.IsArrived());		
		}

		[Test]
		[Category ("forceRotate Test")]
		public void forceRotateTest() 
		{
			Assert.False (cMove.IsForceRotate());		
		}

		[Test]
		[Category ("velocity Test")]
		public void velocityTest()
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (cMove.getVelocity(), Is.EqualTo (s));
		}
		
		[Test]
		[Category ("forceRotateDirection Test")]
		public void forceRotateDirectionTest()
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (cMove.getForceRotateDirection(), Is.EqualTo (s));
		}

		[Test]
		[Category ("destination Test")]
		public void destinationTest()
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (cMove.getDestination(), Is.EqualTo (s));
		}

		[Test]
		[Category ("destinationXZ Test")]
		public void destinationXZTest()
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (cMove.getDestinationXZ(), Is.EqualTo (s));
		}

		[Test]
		[Category ("direction Test")]
		public void directionTest()
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (cMove.getDirection(), Is.EqualTo (s));
		}

		[Test]
		[Category ("currentVelocity Test")]
		public void currentVelocityTest()
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (cMove.getCurrentVelocity(), Is.EqualTo (s));
		}

		[Test]
		[Category ("snapGround Test")]
		public void snapGroundTest()
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (cMove.getSnapGround(), Is.EqualTo (s));
		}

		[Test]
		[Category ("GetCharacterTargetRot Test")]
		public void GetCharacterTargetRotTest()
		{
			string s = "(0.0, 0.0, 0.0, 0.0)";
			Assert.That (cMove.getCharacterTargetRot(), Is.EqualTo (s));
		}


		//正常値テスト(メソッド)
		[Test]
		[Category ("SetDistance Test")]
		public void SetDistanceTest() 
		{
			float f = 10.0f;
			cMove.SetDistance (10.0f);
			Assert.That (cMove.GetDistance(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("SetDistance Range Test")]
		public void SetDistanceTest([Range(-400.0f, 400.0f, 100.0f)]float l ) 
		{
			cMove.SetDistance (l);
			Assert.That (cMove.GetDistance(), Is.EqualTo(l));		
		}

		[Test]
		[Category ("SetArrived Test")]
		public void SetArrivedTest() 
		{
			Assert.True(cMove.SetArrived(true));		
		}

		[Test]
		[Category ("SetForceRotate Test")]
		public void SetForceRotateTest() 
		{
			Assert.True(cMove.SetForceRotate(true));		
		}

		[Test]
		[Category ("SetGravityAcceleration Test")]
		public void SetGravityAccelerationTest() 
		{
			string s = "(0.0, 0.0, 0.0)";
			cMove.SetGravityAcceleration ();
			Assert.That(cMove.getVelocity(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SetVelocityY Test")]
		public void SetVelocityYTest() 
		{
			string s = "0";
			cMove.SetVelocityY ();
			Assert.That(cMove.getVelocityY(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SetCurrentVelocity Test")]
		public void SetCurrentVelocityTest() 
		{
			string s = cMove.getVelocity ();
			cMove.SetCurrentVelocity ();
			Assert.That(cMove.getCurrentVelocity(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SetVelocityZero Test")]
		public void SetVelocityZeroTest() 
		{
			string s = "(0.0, 0.0, 0.0)";
			cMove.SetVelocityZero ();
			Assert.That(cMove.getCurrentVelocity(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SmoothVelocity Test")]
		public void SmoothVelocityTest() 
		{
			string s = "(0.0, 0.0, 0.0)";
			cMove.SmoothVelocity ();
			Assert.That(cMove.getVelocity(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SetWalkSpdVelocity Test")]
		public void SetWalkSpdVelocityTest() 
		{
			string s = "(0.0, 0.0, 0.0)";
			cMove.SetWalkSpdVelocity ();
			Assert.That(cMove.getVelocity(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SetDestXZ Test")]
		public void SetDestXZTest() 
		{
			string s = "(0.0, 0.0, 0.0)";
			cMove.SetDestXZ ();
			Assert.That(cMove.getDestinationXZ(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SetDestAlign Test")]
		public void SetDestAlignTest() 
		{
			string s = "0";
			cMove.SetDestAlign (0.0f);
			Assert.That(cMove.getDestinationXZ_Y(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SnapZero Test")]
		public void SnapZeroTest() 
		{
			string s = "(0.0, 0.0, 0.0)";
			cMove.SnapZero ();
			Assert.That(cMove.getSnapGround(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SnapDown Test")]
		public void SnapDownTest() 
		{
			string s = "(0.0, -1.0, 0.0)";
			cMove.SnapDown ();
			Assert.That(cMove.getSnapGround(), Is.EqualTo(s));		
		}


		[Test]
		[Category ("LessThanDist Test")]
		public void LessThanDistTest() 
		{
			Assert.True(cMove.LessThanDist());		
		}

		[Test]
		[Category ("DestArrived Test")]
		public void DestArrivedTest() 
		{
			cMove.DestArrived ();
			Assert.True(cMove.IsArrived());		
		}

		[Test]
		[Category ("WalkRotateCondition Test")]
		public void WalkRotateConditionTest() 
		{
			Assert.False(cMove.WalkRotateCondition());		
		}

		[Test]
		[Category ("WalkStop Test")]
		public void WalkStopTest() 
		{
			cMove.WalkStop ();
			Assert.True(cMove.IsArrived());		
		}

		[Test]
		[Category ("WalkSpeedVelocity Test")]
		public void WalkSpeedVelocityTest() 
		{
			string s = "(0.0, 0.0, 0.0)";
			cMove.SetArrived (true);
			cMove.WalkSpeedVelocity ();
			Assert.That(cMove.getVelocity(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SetTargetRot Test")]
		public void SetTargetRotTest() 
		{
			string s = "(0.0, 0.0, 0.0, 1.0)";
			cMove.SetTargetRot ();
			Assert.That(cMove.getCharacterTargetRot(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SetTargetForceRot Test")]
		public void SetTargetForceRotTest() 
		{
			string s = "(0.0, 0.0, 0.0, 1.0)";
			cMove.SetTargetForceRot ();
			Assert.That(cMove.getCharacterTargetRot(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("WalkRotation Test")]
		public void WalkRotationTest() 
		{
			//Arrange
			cMove.WalkRotateCondition ().Returns (true);

			//Act
			string s = "(0.0, 0.0, 0.0, 1.0)";
			cMove.WalkRotation ();

			//Assert
			Assert.That(cMove.getCharacterTargetRot(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("MoveManagementTest")]
		public void MoveManagementWithSetDestAlignTest() 
		{
			string s = "10";
			float f = 100.0f;
			string t = "(0.0, -1.0, 0.0)";

			cMove.SetArrived (true);
			cMove.MoveManagement (10.0f, 100.0f);

			Assert.That(cMove.getDestinationXZ_Y(), Is.EqualTo(s));		
			Assert.That(cMove.GetDistance(), Is.EqualTo(f));	
			Assert.That (cMove.getSnapGround(), Is.EqualTo(t));
		}

		//例外検出テスト
		[Test]
		[Category ("WalkSpeedVelocity Exception Test")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void WalkSpeedVelocityExceptionTest() 
		{
			cMove.WalkSpeedVelocity ();
		}



		private IMoveController GetMoveMock () {
			return Substitute.For<IMoveController> ();
		}
		
		private CharaMoveController GetControllerMock(IMoveController move) {
			var cMove = Substitute.For<CharaMoveController> ();
			cMove.SetMoveController (move);
			return cMove;
		}
		
	}
}

