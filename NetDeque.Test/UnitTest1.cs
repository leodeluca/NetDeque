using FluentAssertions;
using System.Diagnostics;

namespace NetDeque.Test

{
    public class UnitTest1
    {
        [Fact]
        public void NewDequeCountZero()
        {
            var sut = new Deque<int>();

            //Assert.Equal(0, sut.Count);

            sut.Count.Should().Be(0);
        }

        [Fact]
        public void NewDequeIsEmpty()
        {
            var sut = new Deque<int>();

            //Assert.True(sut.IsEmpty);

            sut.IsEmpty.Should().BeTrue();
        }

        [Fact]
        public void AddBeg()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);

           //Assert.Equal(1, sut.PeekBeg());

            sut.PeekBeg().Should().Be(1);

        }

        [Fact]
        public void AddManyBeg()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);
            sut.AddBeg(2);
            sut.AddBeg(3);
            sut.AddBeg(4);

            //Assert.Equal(4, sut.PeekBeg());

            sut.PeekBeg().Should().Be(4);
        }

        [Fact]
        public void AddEnd()
        {
            var sut = new Deque<int>();

            sut.AddEnd(1);

            //Assert.Equal(1, sut.PeekEnd());

            sut.PeekEnd().Should().Be(1);
        }

        [Fact]
        public void AddManyEnd()
        {
            var sut = new Deque<int>();

            sut.AddEnd(1);
            sut.AddEnd(2);
            sut.AddEnd(3);
            sut.AddEnd(4);

            //Assert.Equal(4, sut.PeekEnd());

            sut.PeekEnd().Should().Be(4);
        }

        [Fact]
        public void ThrowInvalidOperationExceptionWhenRemoveBegAndDequeIsNull()
        {
            var sut = new Deque<int>();

            Action action = () => sut.RemBeg();

            //Assert.Throws<InvalidOperationException>(action);

           action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void RemoveBegSameOrder()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);
            sut.AddBeg(2);
            sut.AddBeg(3);

            sut.RemBeg();

            //Assert.True(sut.PeekBeg() == 2);
            //Assert.True(sut.PeekEnd() == 1);

            sut.PeekBeg().Should().Be(2);
            sut.PeekEnd().Should().Be(1);
        }

        [Fact]
        public void RemoveBegCountCorretly()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);
            sut.AddBeg(2);
            sut.AddBeg(3);

            sut.RemBeg();

            //Assert.True(sut.Count == 2);

            sut.Count.Should().Be(2);
        }

        [Fact]
        public void ThrowInvalidOperationExceptionWhenRemoveEndAndDequeIsNull()
        {
            var sut = new Deque<int>();

            Action action = () => sut.RemEnd();

            //Assert.Throws<InvalidOperationException>(action);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void RemoveEndSameOrder()
        {
            var sut = new Deque<int>();

            sut.AddEnd(1);
            sut.AddEnd(2);
            sut.AddEnd(3);

            sut.RemEnd();

            //Assert.True(sut.PeekBeg() == 1);
            //Assert.True(sut.PeekEnd() == 2);

            sut.PeekBeg().Should().Be(1);
            sut.PeekEnd().Should().Be(2);
        }

        [Fact]
        public void RemoveEndCountCorretly()
        {
            var sut = new Deque<int>();

            sut.AddEnd(1);
            sut.AddEnd(2);
            sut.AddEnd(3);

            sut.RemEnd();

            //Assert.True(sut.Count == 2);

            sut.Count.Should().Be(2);
        }

        [Fact]
        public void ThrowInvalidOperationExceptionWhenPeekBegCountIsNull()
        {
            var sut = new Deque<int>();

            Action action = () => sut.PeekBeg();

            //Assert.Throws<InvalidOperationException>(action);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ThrowInvalidOperationExceptionWhenPeekEndCountIsNull()
        {
            var sut = new Deque<int>();

            Action action = () => sut.PeekEnd();

            //Assert.Throws<InvalidOperationException>(action);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void PeeksReturnCorretlyValues()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);
            sut.AddEnd(2);

            //Assert.Equal(1, sut.PeekBeg());
            //Assert.Equal(2, sut.PeekEnd());

            sut.PeekBeg().Should().Be(1);
            sut.PeekEnd().Should().Be(2);
        }

        [Fact]
        public void SameCountAfterPeeks()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);
            sut.AddEnd(2);

            var count_before = sut.Count;

            sut.PeekBeg();
            sut.PeekEnd();

            var count_after = sut.Count;

            //Assert.Equal(count_before, count_after);

            count_before.Should().Be(count_after);
        }

        [Fact]
        public void SameOrderWhenAddBegAndEnd()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);
            sut.AddEnd(2);

            //Assert.Equal(1, sut.PeekBeg());
            //Assert.Equal(2, sut.PeekEnd());

            sut.PeekBeg().Should().Be(1);
            sut.PeekEnd().Should().Be(2);

            sut.AddBeg(3);
            sut.AddEnd(4);

            //Assert.Equal(3, sut.PeekBeg());
            //Assert.Equal(4, sut.PeekEnd());

            sut.PeekBeg().Should().Be(3);
            sut.PeekEnd().Should().Be(4);
        }

        [Fact]
        public void SameBehaviorWhenRemoveBegAfterAddEnd()
        {
            var sut = new Deque<int>();

            sut.AddEnd(1);
            sut.AddEnd(2);

            sut.RemBeg();

            //Assert.Equal(2, sut.PeekBeg());
            //Assert.Equal(1, sut.Count);

            sut.PeekBeg().Should().Be(2);
            sut.Count.Should().Be(1);
        }

        [Fact]
        public void SameBehaviorWhenRemoveEndAfterAddBeg()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);
            sut.AddBeg(2);

            sut.RemEnd();

            //Assert.Equal(2, sut.PeekEnd());
            //Assert.Equal(1, sut.Count);

            sut.PeekEnd().Should().Be(2);
            sut.Count.Should().Be(1);
        }

        [Fact]
        public void DoNotHaveInvalidElementsAfterManyAddsAndRemoves()
        {
            var sut = new Deque<string?>();

            sut.AddEnd("A");
            sut.AddBeg("B");
            sut.AddEnd(null);
            sut.AddBeg("C");

            sut.RemEnd(); 
            sut.RemBeg();
            sut.AddEnd("D");

            var items = new[] { sut.RemBeg(), sut.RemEnd() };

            //Assert.All(items, item => Assert.False(string.IsNullOrEmpty(item)));

            items.Should().NotContainNulls();
            items.Should().OnlyContain(item => !string.IsNullOrWhiteSpace(item));

        }

        [Fact]
        public void DequeIntegrityWhenManyAddsAndRemoves()
        {
            var sut = new Deque<int>();

            sut.AddBeg(1);
            sut.AddBeg(2);
            sut.AddBeg(3);
            sut.AddBeg(4);
            sut.AddBeg(5);
            sut.AddBeg(6);
            sut.AddBeg(7);
            sut.AddBeg(8);
            sut.AddBeg(9);

            sut.AddEnd(1);
            sut.AddEnd(2);
            sut.AddEnd(3);
            sut.AddEnd(4);
            sut.AddEnd(5);
            sut.AddEnd(6);
            sut.AddEnd(7);
            sut.AddEnd(8);
            sut.AddEnd(9);

            sut.RemBeg();
            sut.RemBeg();
            sut.RemBeg();
            sut.RemBeg();
            sut.RemBeg();

            sut.RemEnd();
            sut.RemEnd();
            sut.RemEnd();
            sut.RemEnd();

            //Assert.Equal(4, sut.PeekBeg());
            //Assert.Equal(5, sut.PeekEnd());
            //Assert.Equal(9, sut.Count);

            sut.PeekBeg().Should().Be(4);
            sut.PeekEnd().Should().Be(5);
            sut.Count.Should().Be(9);   

        }

    }
}