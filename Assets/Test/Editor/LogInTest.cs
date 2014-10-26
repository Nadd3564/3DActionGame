using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using NSubstitute;


namespace Cradle.Test
{
	[TestFixture]
	[Category ("LogIn Test")]
	public class LogInTest
	{
		//private LogIn.SpaceBook logIn;
		//private SortedList <string,LogIn.SpaceBook> community = new SortedList <string,LogIn.SpaceBook> (100);

		[SetUp] public void Init()
		{
			//logIn = new LogIn.SpaceBook("hi");
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		
		//正常値テスト（メソッド）
		[Test]
		[Category ("IsUnique Test")]
		public void IsUniqueTest () 
		{
			string s = "NAdd";
		}

		
		
	}
}

