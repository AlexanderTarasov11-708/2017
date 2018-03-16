using NUnit.Framework;

namespace GameRing
{
    [TestFixture]
    public class RingTests
    {
        [Test]
        public void Initialization()
        {
            Assert.IsTrue(new RingList() is RingList);
        }

        [Test]
        public void InitializeWithChar()
        {
            var list = new RingList('F');
            Assert.AreEqual(1, list.Length());
            Assert.AreEqual('F', list.Head.GetChar());
        }

        [Test]
        public void InitializeWithPlayer()
        {
            var player = new Player(0, 'M');
            var list = new RingList(player);
            Assert.AreEqual(1, list.Length());
            Assert.AreEqual('M', list.Head.GetChar());
        }

        [Test]
        public void Add()
        {
            var list = new RingList('F');
            list.Add('M');
            Assert.AreEqual(2, list.Length());
            Assert.AreEqual('F', list.Head.GetChar());
            Assert.AreEqual('M', list.Tail.GetChar());
        }

        [Test]
        public void AddPlayer()
        {
            var list = new RingList();
            var player = new Player(0, 'M');
            list.Add(player);
            Assert.AreEqual(1, list.Length());
            Assert.AreEqual('M', list.Head.GetChar());
        }

        [Test]
        public void AddWithIndex()
        {
            var list = new RingList('F');
            list.Add('M');
            list.Add('M');
            list.Add(2, 'F');
            Assert.AreEqual(4, list.Length());
            Assert.AreEqual('F', list.GetPlayer(2).GetChar());
        }

        [Test]
        public void RemoveElement()
        {
            var list = new RingList('M');
            list.Add('M');
            list.Add('F');
            list.Remove(1);
            Assert.AreEqual(2, list.Length());
            Assert.AreEqual('F', list.GetPlayer(1).GetChar());
        }

        [Test]
        public void RemoveFirstElement()
        {
            var list = new RingList('M');
            list.Add('F');
            list.Add('F');
            list.Add('M');
            list.Remove(0);
            Assert.AreEqual(3, list.Length());
            Assert.AreEqual('F', list.Head.GetChar());
            Assert.AreEqual('M', list.Tail.GetChar());
        }

        [Test]
        public void RemoveLastElement()
        {
            var list = new RingList('M');
            list.Add('M');
            list.Add('F');
            list.Add('M');
            list.Remove(3);
            Assert.AreEqual(3, list.Length());
            Assert.AreEqual('M', list.Head.GetChar());
            Assert.AreEqual('F', list.Tail.GetChar());
        }

        [Test]
        public void RemoveLastOneElement()
        {
            var list = new RingList('M');
            list.Remove(0);
            Assert.AreEqual(0, list.Length());
        }
    }
}
