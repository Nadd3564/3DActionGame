using NUnit.Framework;
using System;
using NSubstitute;
using Cradle.FM;

namespace Cradle.Test
{
    [TestFixture]
    [Category("DropItem Test")]
    public class DropItemTest
    {
        public IDropItemController iDrop;
        public DropItemController dIController;
        public DropItemController.ItemKind kind;

        [SetUp]
        public void Init()
        {
            iDrop = GetItemMock();
            dIController = GetControllerMock(iDrop);
        }

        [TearDown]
        public void Cleanup()
        {

        }


        //データ型テスト(オブジェクト)
        [Test]
        [Category("ItemKind Attack Type Test")]
        public void ItemKindAttackTypeTest()
        {
            Assert.That(dIController.GetAttackKind(), Is.TypeOf(typeof(DropItemController.ItemKind)));
        }

        [Test]
        [Category("ItemKind Heal Type Test")]
        public void ItemKindHealTypeTest()
        {
            Assert.That(dIController.GetHealKind(), Is.TypeOf(typeof(DropItemController.ItemKind)));
        }

        [Test]
        [Category("ItemKind itemKind Type Test")]
        public void ItemKinditemKindTypeTest()
        {
            Assert.That(dIController.itemKind(), Is.TypeOf(typeof(DropItemController.ItemKind)));
        }

        //Null値テスト(オブジェクト)
        [Test]
        [Category("ItemKind Attack NotNull Test")]
        public void NotNullAttackTest()
        {
            Assert.NotNull(dIController.GetAttackKind());
        }

        [Test]
        [Category("ItemKind Heal NotNull Test")]
        public void NotNullHealTest()
        {
            Assert.NotNull(dIController.GetHealKind());
        }

        [Test]
        [Category("ItemKind itemKind NotNull Test")]
        public void NotNullitemKindTest()
        {
            Assert.NotNull(dIController.itemKind());
        }


        //正常値テスト(メソッド)
        [Test]
        [Category("IsPlayer Test")]
        public void IsPlayerTest()
        {
            string s = "Player";
            Assert.True(dIController.IsPlayer(s));
        }

        [Test]
        [Category("IsNotPlayer Test")]
        public void IsNotPlayerTest()
        {
            string s = "Enemy";
            Assert.False(dIController.IsPlayer(s));
        }

        [Test]
        [Category("IsTerrain Test")]
        public void IsTerrainTest()
        {
            string s = "Terrain";
            Assert.True(dIController.IsTerrain(s));
        }

        [Test]
        [Category("IsNotTerrain Test")]
        public void IsNotTerrainTest()
        {
            string s = "Enemy";
            Assert.False(dIController.IsTerrain(s));
        }

        [Test]
        [Category("CheckTerrain Test")]
        public void CheckTerrainTest()
        {
            string s = "Terrain";
            bool flg = false;
            Assert.True(dIController.CheckTerrain(s, flg));
        }

        [Test]
        [Category("CanNot CheckTerrain Test")]
        public void CanNotCheckTerrainTest()
        {
            string s = "Player";
            bool flg = false;

            Assert.False(dIController.CheckTerrain(s, flg));
        }


        private IDropItemController GetItemMock()
        {
            return Substitute.For<IDropItemController>();
        }

        private DropItemController GetControllerMock(IDropItemController iDrop)
        {
            var dIController = Substitute.For<DropItemController>();
            dIController.SetDropItemController(iDrop);
            return dIController;
        }

    }
}

