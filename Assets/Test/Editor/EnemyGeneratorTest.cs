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
		
		//正常値テスト
		[Test]
		[Category ("Calc Test")]
		public void CalcTimeTest ()
		{
			Assert.That (eGController.CalcTime(), Is.EqualTo (0.0f));
		}
		
		[Test]
		[Category ("Calc Test")]
		[TestCase("string")]
		public void GetMaxActiveTest ([Values(-1,0,1,2,null)]int x) 
		{
			eGController.GetMaxActive ();
			Assert.That (eGController.maxActive, Is.EqualTo(x));		
		}
		
		[Test]
		[Category ("Calc Test")]
		[TestCase(null)]
		[TestCase("string")]
		public void SetMaxActiveTest ([Range(-1,10,1)]int x) 
		{
			eGController.SetMaxActive (x);
			Assert.That (eGController.maxActive, Is.EqualTo(x));		
		}
		
		[Test]
		 [Category ("Calc Test")]
		 [TestCase("string")]
		 public void GetRePopTimeTest ([Values(-1.0f,0.0f,1.0f,8.0f,null)]float x) 
		 {
			eGController.GetRePopTime ();
			Assert.That (eGController.RePopTime, Is.EqualTo(x));		
		 }
		 
		[Test]
		[Category ("Calc Test")]
		[TestCase(null)]
		[TestCase("string")]
		public void SetRePopTimeTest ([Range(-1.0f,10.0f,1.0f)]float x) 
		{
			eGController.SetRePopTime (x);
			Assert.That (eGController.RePopTime, Is.EqualTo(x));		
		}
		
		private IGeneratorController GetGeneratorMock () {
			return Substitute.For<IGeneratorController> ();
		}
		
		private EnemyGeneratorController GetControllerMock(IGeneratorController iGenerator) {
			var eGController = Substitute.For<EnemyGeneratorController> ();
			eGController.SetGeneratorController (iGenerator);
			eGController.CalcTime ().Returns (0.0f);
			return eGController;
		}
		
	}
}

