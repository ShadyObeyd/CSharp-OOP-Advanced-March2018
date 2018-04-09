using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class MathFloorTests
{
    [Test]
    public void MathFloorReturnsTheCorrectValue()
    {
        Mock<IFloor> doubleMock = new Mock<IFloor>();

        double doubleValue = 10.5;

        doubleMock.Setup(d => d.FloorNumber(doubleValue)).Returns(Math.Floor(doubleValue));

        double expectedResult = 10;

        Assert.That(doubleMock.Object.FloorNumber(doubleValue), Is.EqualTo(expectedResult));
    }
}