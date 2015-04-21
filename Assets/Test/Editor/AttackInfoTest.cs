using NUnit.Framework;
using System;
using NSubstitute;

namespace Cradle.Test
{
    [TestFixture]
    [Category("AttackInfo Test")]
    public class AttackInfoTest
    {
        public IInfoController iInfo;
        public AttackInfoController aIController;

        [SetUp]
        public void Init()
        {
            iInfo = GetInfoMock();
            aIController = GetControllerMock(iInfo);
        }

        [TearDown]
        public void Cleanup()
        {

        }


        //データ型テスト（オブジェクト）
        [Test]
        [Category("attackPower Type Test")]
        public void attackPowerTypeTest()
        {
            Assert.That(aIController.getAttackPower(), Is.TypeOf(typeof(float)));
        }

        //Null値テスト（オブジェクト）
        [Test]
        [Category("attackPower NotNull Test")]
        public void NotNullattackPowerTest()
        {
            Assert.NotNull(aIController.getAttackPower());
        }

        //正常値テスト(オブジェクト)
        [Test]
        [Category("getAttackPower Test")]
        public void GetAttackPowerTest()
        {
            float f = 0.0f;
            Assert.That(aIController.getAttackPower(), Is.EqualTo(f));
        }

        //異常値テスト(オブジェクト)
        [Test]
        [Category("NotGetAttackPower Test")]
        public void NotGetAttackPowerTest([Range(-10.0f, -1.0f, 1.0f)]float f)
        {
            Assert.That(aIController.getAttackPower(), Is.Not.EqualTo(f));
        }


        //正常値テスト（メソッド）
        [Test]
        [Category("SetAttackPower Test")]
        public void SetAttackPowerTest()
        {
            float x = aIController.setAttackPower(10.0f);
            Assert.That(aIController.getAttackPower(), Is.EqualTo(x));
        }

        [Test]
        [Category("SetAttackPower Range Test")]
        public void SetAttackPowerRangeTest([Range(-4.0f, 4.0f, 1.0f)]float x)
        {
            aIController.setAttackPower(x);
            Assert.That(aIController.getAttackPower(), Is.EqualTo(x));
        }


        [Test]
        [Category("SetAttackBoostPower Test")]
        public void SetAttackBoostPowerTest()
        {
            float x = aIController.setAttackPower(10.0f);
            aIController.setAttackBoostPower(10.0f);
            Assert.That(aIController.getAttackPower(), Is.EqualTo(20.0f));
        }

        [Test]
        [Category("SetAttackBoostPower Range Test")]
        public void SetAttackBoostPowerRangeTest([Range(-4.0f, 4.0f, 1.0f)]float x)
        {
            float i = aIController.setAttackPower(10.0f);
            i += aIController.setAttackBoostPower(x);
            Assert.That(aIController.getAttackPower(), Is.EqualTo(10.0f + x));
        }


        private IInfoController GetInfoMock()
        {
            return Substitute.For<IInfoController>();
        }

        private AttackInfoController GetControllerMock(IInfoController iInfo)
        {
            var aIController = Substitute.For<AttackInfoController>();
            aIController.SetInfoController(iInfo);
            return aIController;
        }

    }
}

