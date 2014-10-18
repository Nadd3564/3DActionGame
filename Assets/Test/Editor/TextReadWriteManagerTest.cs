using NUnit.Framework;
using System;
using System.IO;
using NSubstitute;
using Cradle.Resource;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("TextReadWriteManager Test")]
	public class TextReadWriteManagerTest
	{
		public TextReadWriteManager tManager;
		System.DateTime now; 

		[SetUp] public void Init()
		{
			tManager = new TextReadWriteManager ();
			now = System.DateTime.Now;
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		

		//正常値テスト（メソッド）
		[Test]
		[Category ("WriteTextFileWithReadTextFile Test")]
		public void WriteTextFileWithReadTextFileTest () 
		{
			string s = "[" + now + "] " + "Check" + "\r\n";
			tManager.WriteTextFile ("/" + "ErrorLog_Cradle.txt", "Check");
			Assert.That (tManager.ReadTextFile("/" + "ErrorLog_Cradle.txt"), Is.EqualTo(s));		
		}

		[Test]
		[Category ("ReadTextFile Test")]
		public void ReadTextFileTest () 
		{
			string s = "[" + now + "] " + "Check" + "\r\n";
			Assert.That (tManager.ReadTextFile("/" + "ErrorLog_Cradle.txt"), Is.Not.EqualTo(s));		
		}

	}
}

