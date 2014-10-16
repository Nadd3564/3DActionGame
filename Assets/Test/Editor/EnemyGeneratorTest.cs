using NUnit.Framework;
using System;
using NSubstitute;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("EnemyGenerator Test")]
	public class EnemyGeneratorTest
	{
		public IGeneratorController iGenerator;
		public EnemyGeneratorController eGController;
		
		[SetUp] public void Init()
		{ 
			iGenerator = GetGeneratorMock ();
			eGController = GetControllerMock (iGenerator);	
		}
		
		[TearDown] public void Cleanup()
		{
			
		}

		//データ型テスト（オブジェクト）
		[Test]
		[Category ("maxActive Type Test")]
		public void MaxActiveTypeTest() 
		{
			Assert.That (eGController.GetMaxActive(), Is.TypeOf(typeof(int)));		
		}

		[Test]
		[Category ("RePopTime Type Test")]
		public void RePopTimeTypeTest() 
		{
			Assert.That (eGController.GetRePopTime(), Is.TypeOf(typeof(float)));		
		}

		//Null値テスト（オブジェクト）
		[Test]
		[Category ("maxActive NotNull Test")]
		public void NotNullMaxActiveTest() 
		{
			Assert.NotNull (eGController.GetMaxActive());		
		}

		[Test]
		[Category ("RePopTime NotNull Test")]
		public void NotNullRePopTimeTest() 
		{
			Assert.NotNull (eGController.GetRePopTime());		
		}


		//正常値テスト（オブジェクト）
		[Test]
		[Category ("GetMaxActive Test")]
		public void GetMaxActiveTest () 
		{
			int i = 2;
			Assert.That (eGController.GetMaxActive (), Is.EqualTo(i));		
		}
		
		[Test]
		[Category ("GetRePopTime Test")]
		public void GetRePopTimeTest () 
		{
			float f = 8.0f;
			Assert.That (eGController.GetRePopTime(), Is.EqualTo(f));		
		}


		//正常値テスト（メソッド）
		[Test]
		[Category ("SetMaxActive Test")]
		public void SetMaxActiveTest () 
		{
			eGController.SetMaxActive (4);
			Assert.That (eGController.GetMaxActive(), Is.EqualTo(4));		
		}

		[Test]
		[Category ("SetMaxActive Range Test")]
		public void SetMaxActiveRangeTest ([Range(-4, 4, 1)]int i) 
		{
			eGController.SetMaxActive (i);
			Assert.That (eGController.GetMaxActive(), Is.EqualTo(i));		
		}

		[Test]
		[Category ("SetRePopTime Test")]
		public void SetRePopTimeTest () 
		{
			eGController.SetRePopTime (10.0f);
			Assert.That (eGController.GetRePopTime(), Is.EqualTo(10.0f));		
		}

		[Test]
		[Category ("SetRePopTime Range Test")]
		public void SetRePopTimeRangeTest ([Range(-4.0f, 4.0f, 1.0f)]float f) 
		{
			eGController.SetRePopTime (f);
			Assert.That (eGController.GetRePopTime(), Is.EqualTo(f));		
		}


		//例外検知テスト
		[Test]
		[Category ("generate Exception Test")]
		[ExpectedException(typeof(ArgumentException))]
		public void generateExceptionTest () 
		{
			//Arrange
			iGenerator.Instantiate (2).Returns (false);

			//Act
			eGController.Generate (0, 2);
		}

		private IGeneratorController GetGeneratorMock () {
			return Substitute.For<IGeneratorController> ();
		}
		
		private EnemyGeneratorController GetControllerMock(IGeneratorController iGenerator) {
			var eGController = Substitute.For<EnemyGeneratorController> ();
			iGenerator.SameNullEnemys (1).Returns (true);
			eGController.SetGeneratorController (iGenerator);
			return eGController;
		}
		
	}
}

