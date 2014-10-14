using NUnit.Framework;
using System;
using NSubstitute;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("CharaAnimation Test")]
	public class CharaAnimationTest
	{
		public IAnimationController animation;
		public CharaAnimationController cAnimation;
		
		[SetUp] public void Init()
		{ 
			animation = GetAnimationMock ();
			cAnimation = GetControllerMock (animation);	
		}
		
		[TearDown] public void Cleanup()
		{
			
		}

		//データ型テスト（オブジェクト）
		[Test]
		[Category ("attacked Type Test")]
		public void attackedTypeTest() 
		{
			Assert.That (cAnimation.IsAttacked(), Is.TypeOf(typeof(bool)));		
		}

		[Test]
		[Category ("isDown Type Test")]
		public void isDownTypeTest() 
		{
			Assert.That (cAnimation.IsDown (), Is.TypeOf(typeof(bool)));		
		}

		//Null値テスト（オブジェクト）
		[Test]
		[Category ("attacked NotNull Test")]
		public void NotNullAttackedTest() 
		{
			Assert.NotNull (cAnimation.IsAttacked());		
		}

		[Test]
		[Category ("isDown NotNull Test")]
		public void NotNullIsDownTest() 
		{
			Assert.NotNull (cAnimation.IsDown());		
		}

		//正常値テスト（オブジェクト）
		[Test]
		[Category ("IsAttacked Test")]
		public void IsAttackedTest() 
		{
			Assert.False (cAnimation.IsAttacked());		
		}

		[Test]
		[Category ("IsDown Test")]
		public void IsDownTest() 
		{
			Assert.False (cAnimation.IsDown());		
		}

		//正常値テスト（メソッド）
		[Test]
		[Category ("SetAttacked Test")]
		public void SetAttackedTest() 
		{
			cAnimation.SetAttacked (true);
			Assert.True (cAnimation.IsAttacked());		
		}
		
		[Test]
		[Category ("SetDown Test")]
		public void SetDownTest() 
		{
			cAnimation.SetDown (true);
			Assert.True (cAnimation.IsDown());		
		}

		[Test]
		[Category ("StopAttack Test")]
		public void StopAttackTest(){
			cAnimation.StopAttack();
			Assert.False (cAnimation.IsAttacked());
		}

		[Test]
		[Category ("isAttacking Test")]
		public void isAttackingTest() 
		{
			//CrossCheck@CharaStatusController
			Assert.False (cAnimation.isAttacking());		
		}

		[Test]
		[Category ("SetAttacking Test")]
		public void SetAttackingTest() 
		{
			//CrossCheck@CharaStatusController
			cAnimation.SetAttacking (false);

			Assert.False (cAnimation.isAttacking());		
		}

		private IAnimationController GetAnimationMock () {
			return Substitute.For<IAnimationController> ();
		}
		
		private CharaAnimationController GetControllerMock(IAnimationController animation) {
			var cAnimation = Substitute.For<CharaAnimationController> ();
			cAnimation.SetAnimationController (animation);
			return cAnimation;
		}
		
	}
}