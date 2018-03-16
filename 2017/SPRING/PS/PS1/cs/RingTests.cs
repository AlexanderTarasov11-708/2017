using NUnit.Framework;

namespace GameRing
{
    /**
     * @author - Тарасов Александр 11-708
     * Вариант 12 
     * Реализация кольцевого список
     * Тесты
     */
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
        public void InitializeAndAddElement()
        {
            var list = new RingList();
            list.Add('M');
            Assert.AreEqual(1, list.Length());
            Assert.AreEqual('M', list.Head.GetChar());
            Assert.AreEqual('M', list.Tail.GetChar());
            Assert.AreEqual(list.Head, list.Tail.Next);
        }

        [Test]
        public void AddElement()
        {
            var list = new RingList('F');
            list.Add('M');
            Assert.AreEqual(2, list.Length());
            Assert.AreEqual('F', list.Head.GetChar());
            Assert.AreEqual('M', list.Tail.GetChar());
            Assert.AreEqual(list.Head, list.Tail.Next);
        }

        [Test]
        public void AddElementPlayer()
        {
            var list = new RingList();
            var player = new Player(0, 'M');
            list.Add(player);
            Assert.AreEqual(1, list.Length());
            Assert.AreEqual('M', list.Head.GetChar());
            Assert.AreEqual(list.Head, list.Tail.Next);
        }

        [Test]
        public void AddElementWithIndex()
        {
            var list = new RingList('F');
            list.Add('M');
            list.Add('M');
            list.Add(2, 'F');
            Assert.AreEqual(4, list.Length());
            Assert.AreEqual('F', list.GetPlayer(2).GetChar());
        }

        [Test]
        public void AddElementWithFirstIndex()
        {
            var list = new RingList('F');
            list.Add('M');
            list.Add('M');
            list.Add(0, 'M');
            Assert.AreEqual(4, list.Length());
            Assert.AreEqual('M', list.GetPlayer(0).GetChar());
            Assert.AreEqual('M', list.Head.GetChar());
        }

        [Test]
        public void AddElementWithLastIndex()
        {
            var list = new RingList('F');
            list.Add('M');
            list.Add('M');
            list.Add(3, 'F');
            Assert.AreEqual(4, list.Length());
            Assert.AreEqual('F', list.GetPlayer(3).GetChar());
            Assert.AreEqual('F', list.Tail.GetChar());
            Assert.AreEqual(list.Head, list.Tail.Next);
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

        [Test]
        public void MergeLists()
        {
            var list1 = new RingList('M');
            list1.Add('M');
            list1.Add('M');
            list1.Add('M');
            var list2 = new RingList('F');
            list2.Add('F');
            list2.Add('F');
            list2.Add('F');
            var merged = list1.Merge(list2);
            Assert.AreEqual(8, merged.Length());
            Assert.AreEqual('M', merged.Head.GetChar());
            Assert.AreEqual('F', merged.GetPlayer(4).GetChar());
            Assert.AreEqual('F', merged.Tail.GetChar());
        }

        [Test]
        public void SeperateListsByGender()
        {
            var list1 = new RingList('M');
            list1.Add('F');
            list1.Add('M');
            list1.Add('F');
            list1.Add('F');
            list1.Add('M');
            list1.Add('F');
            var tuple = list1.SeparateGender(0);
            Assert.AreEqual(3, tuple.Item1.Length());
            Assert.AreEqual(4, tuple.Item2.Length());
            Assert.AreEqual('M', tuple.Item1.Head.GetChar());
            Assert.AreEqual('F', tuple.Item2.Tail.GetChar());
        }

        [Test]
        public void SortByGender()
        {
            var list1 = new RingList('M');
            list1.Add('F');
            list1.Add('M');
            list1.Add('F');
            list1.Add('F');
            list1.Add('M');
            list1.Add('F');
            var maleFirst = list1.Sort(0,true);
            var femaleFirst = list1.Sort(0, false);
            Assert.AreEqual(7, maleFirst.Length());
            Assert.AreEqual('M', maleFirst.Head.GetChar());
            Assert.AreEqual('F', maleFirst.GetPlayer(3).GetChar());
            Assert.AreEqual('F', maleFirst.Tail.GetChar());
            Assert.AreEqual('F', femaleFirst.Head.GetChar());
            Assert.AreEqual('M', femaleFirst.Tail.GetChar());
        }

        [Test]
        public void DeleteEveryK()
        {
            var list = new RingList('M');
            list.Add('F');
            list.Add('M');
            list.Add('F');
            list.Add('F');
            list.Add('M');
            list.Add('F');
            var player = list.DeleteEveryK(3);
            Assert.IsTrue(player is Player);
            Assert.AreEqual('M', player.GetChar());
        }
    }
}
