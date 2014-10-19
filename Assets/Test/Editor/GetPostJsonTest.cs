using NUnit.Framework;
using System;
using NSubstitute;
using Cradle;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("GetPostJson Test")]
	public class GetPostJsonTest
	{
		private GetPostJsonController gPJson;

		[SetUp] public void Init()
		{ 
			gPJson = new GetPostJsonController ();
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		

		//正常値テスト(メソッド)
		[Test]
		[Category ("Get Test")]
		public void GetTest ()
		{
			gPJson.Get ("http://localhost:8080/Cradle/json/1");
		}

		[Test]
		[Category ("Post Test")]
		public void PostTest ()
		{
			gPJson.Post ("http://localhost:8080/Cradle/json/");
		}

	}
}

