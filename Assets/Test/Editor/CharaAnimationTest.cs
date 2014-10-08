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
		
		//正常値テスト
		[Test]
		[Category ("Bool Test")]
		[TestCase(true)]
		[TestCase(false)]
		[TestCase(null)]
		public void StopAttackTest(bool flg){
			cAnimation.StopAttack();
			Assert.That (cAnimation.IsAttacked(), Is.EqualTo(flg));
		}

		[Test]
		[Category ("Bool Test")]
		[TestCase(true)]
		[TestCase(false)]
		[TestCase(null)]
		public void StopAttackTest2(bool flg){
			cAnimation.SetAttacked (false);
			cAnimation.SetAttacking (true);
			cAnimation.StopAttack();
			Assert.That (cAnimation.IsAttacked(), Is.EqualTo(flg));
		}

		[Test]
		[Category ("Bool Test")]
		[TestCase(true)]
		[TestCase(false)]
		[TestCase(null)]
		public void StopAttackTest3(bool flg){
			cAnimation.SetAttacked (true);
			cAnimation.SetAttacking (false);
			cAnimation.StopAttack();
			Assert.That (cAnimation.IsAttacked(), Is.EqualTo(flg));
		}

		[Test]
		[Category ("Bool Test")]
		[TestCase(true)]
		[TestCase(false)]
		[TestCase(null)]
		public void StopAttackTest4(bool flg){
			cAnimation.SetAttacked (false);
			cAnimation.SetAttacking (false);
			cAnimation.StopAttack();
			Assert.That (cAnimation.IsAttacked(), Is.EqualTo(flg));
		}

		[Test]
		[Category ("Bool Test")]
		[TestCase(true)]
		[TestCase(false)]
		[TestCase(null)]
		public void StopAttackTest5(bool flg){
			cAnimation.SetAttacked (true);
			cAnimation.SetAttacking (true);
			cAnimation.StopAttack();
			Assert.That (cAnimation.IsAttacked(), Is.EqualTo(flg));
		}

		[Test]
		[Category ("Bool Test")]
		[TestCase(true)]
		[TestCase(false)]
		[TestCase(null)]
		public void StopAttackTest6(bool flg){
			cAnimation.SetAttacked (false);
			cAnimation.SetAttacking (false);
			Assert.That (cAnimation.StopAttack(), Is.EqualTo(flg));
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