using Moq;
using NUnit.Framework;
using System;

public class MathAbsTests
{
    [Test]
    public void MathAbsReturnsNegativeNumbersCorrectly()
    {
        Mock<IAbs> mockInt = new Mock<IAbs>();

        int negativeInt = -99;

        mockInt.Setup(m => m.ReturnAbsoluteValue(negativeInt)).Returns(Math.Abs(negativeInt));

        int expectedResult = 99;

        Assert.That(mockInt.Object.ReturnAbsoluteValue(negativeInt), Is.EqualTo(expectedResult));
    }
}