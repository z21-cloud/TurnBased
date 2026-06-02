using NUnit.Framework;
using UnityEngine;

namespace TurnBased.Tests
{
    public class MoveCalculusTest
{
    [Test]
    public void MoveTowards_MovesCorrectly()
    {
        var calc = new MoveCalculator();

        Vector3 start = Vector3.zero;
        Vector3 target = new Vector3(10, 0, 0);

        var result = calc.MoveTowards(start, target, 5f);

        Assert.AreEqual(new Vector3(5, 0, 0), result);
    }
}
}

