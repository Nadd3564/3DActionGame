using NUnit.Framework;
using System;
using System.Collections.Generic;
using NSubstitute;
using Cradle.DesignPattern;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("SceneManager Test")]
	public class SceneManagerTest
	{
		private SceneManager manager;
		
		
		[SetUp] public void Init()
		{
			manager = Substitute.For<SceneManager> ();
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		
		//データ型テスト（オブジェクト）
		[Test]
		[Category ("activeState Type Test")]
		public void activeStateTypeTest() 
		{
			manager.InitState ();
			Assert.That (manager.GetActiveState(), Is.TypeOf(typeof(TitleState)));		
		}

	}
}