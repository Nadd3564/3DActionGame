using NUnit.Framework;
using System;
using NSubstitute;

	namespace Cradle{
	[TestFixture]
	public class AccountTest
	{
		Account source;
		Account destination;

		[SetUp]
		public void Init(){
			source = new Account ();
			source.Deposit (200m);

			destination = new Account ();
			destination.Deposit (150m);
		}

		[Test]
		public void TransferFunds()
		{
			source.TransferFunds(destination, 100m);
			
			Assert.AreEqual(250m, destination.Balance);
			Assert.AreEqual(100m, source.Balance);
		}

		[Test]
		[ExpectedException(typeof(DifferentStringException))]
		public void TransferWithFunds()
		{
			source.TransferFunds(destination, 300m);
		}

		[Test]
		[ExpectedException(typeof(DifferentStringException))]
		[Ignore("Decide how to implement transaction management")]
		public void TransferWithFundsAtomicity()
		{
			try{
				source.TransferFunds(destination, 300m);
			}
			catch(DifferentStringException e)
			{
			}

			Assert.AreEqual (200m, source.Balance);
			Assert.AreEqual (150m, destination.Balance);
		}
	}
}
