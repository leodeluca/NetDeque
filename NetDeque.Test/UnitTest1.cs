namespace NetDeque.Test
{
    public class UnitTest1
    {
        [Fact]
        public void NewDequeCountZero()
        {
            var sut = new Deque<int>();

            Assert.Equal(0, sut.Count);
        }

        [Fact]
        public void NewDequeIsEmpty()
        {
            var sut = new Deque<int>();

            Assert.True(sut.IsEmpty);
        }

        [Fact]
        public void AddBeg()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);

           Assert.Equal(1, sut.PeekBeg());
        }

        [Fact]
        public void AddManyBeg()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);
            sut.AddBeg(2);
            sut.AddBeg(3);
            sut.AddBeg(4);
            
            Assert.Equal(4, sut.PeekBeg());
        }

        [Fact]
        public void AddEnd()
        {
            var sut = new Deque<int>();

            sut.AddEnd(1);

            Assert.Equal(1, sut.PeekEnd());
        }

        [Fact]
        public void AddManyEnd()
        {
            var sut = new Deque<int>();

            sut.AddEnd(1);
            sut.AddEnd(2);
            sut.AddEnd(3);
            sut.AddEnd(4);

            Assert.Equal(4, sut.PeekEnd());
        }

        [Fact]
        public void ThrowInvalidOperationExceptionWhenRemoveBegAndDequeIsNull()
        {
            var sut = new Deque<int>();

            Action action = () => sut.RemBeg();

            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void RemoveBegSameOrder()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);
            sut.AddBeg(2);
            sut.AddBeg(3);

            sut.RemBeg();

            Assert.True(sut.PeekBeg() == 2);
            Assert.True(sut.PeekEnd() == 1);
        }

        [Fact]
        public void RemoveBegCountCorretly()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);
            sut.AddBeg(2);
            sut.AddBeg(3);

            sut.RemBeg();

            Assert.True(sut.Count == 2);
        }

        [Fact]
        public void ThrowInvalidOperationExceptionWhenRemoveEndAndDequeIsNull()
        {
            var sut = new Deque<int>();

            Action action = () => sut.RemEnd();

            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void RemoveEndSameOrder()
        {
            var sut = new Deque<int>();

            sut.AddEnd(1);
            sut.AddEnd(2);
            sut.AddEnd(3);

            sut.RemEnd();

            Assert.True(sut.PeekBeg() == 1);
            Assert.True(sut.PeekEnd() == 2);
        }

        [Fact]
        public void RemoveEndCountCorretly()
        {
            var sut = new Deque<int>();

            sut.AddEnd(1);
            sut.AddEnd(2);
            sut.AddEnd(3);

            sut.RemEnd();

            Assert.True(sut.Count == 2);
        }

    }
}