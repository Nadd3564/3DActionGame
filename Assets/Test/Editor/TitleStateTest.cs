using NUnit.Framework;
using System;
using System.IO;
using Cradle.DesignPattern;
using System.Collections.Generic;
using NSubstitute;


namespace Cradle.Test
{
	[TestFixture]
	[Category ("TitleState Test")]
	public class TitleStateTest
	{
		private TitleState titleState;

		[SetUp] public void Init()
		{
			titleState = Substitute.For<TitleState>();
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		
		//正常値テスト（メソッド）
		[Test]
		[Category ("GetKeyUpRet Test")]
		public void GetKeyUpRetTest () 
		{
			titleState.GetKeyUpRet ().Returns (true);
			Assert.True (titleState.GetKeyUpRet ());
		}

		
		
	}
}

