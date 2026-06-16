using NUnit.Framework;
using UnityEngine;
using TurnBased.Pathfinding;
public class GridSystemTests
{
    [Test]
    public void GetWorldPosition_WhenCoordinateGiven_ReturnsCorrectWorldVector()
    {
        // 1. Arrange
        int width = 10;
        int height = 10;
        float cellSize = 2.0f;

        var gridSystem = new GridSystem(height, width, cellSize);

        int testX = 3;
        int testZ = 2;

        Vector3 expectedPosition = new Vector3(6f, 0f, 4f);

        // 2. Act
        GridPosition testGridPosition = new GridPosition(testX, testZ);
        Vector3 actualPosition = gridSystem.GetWorldPosition(testGridPosition);

        // 3. Assert
        Assert.AreEqual(expectedPosition, actualPosition, "World position isn't correct");
    }

    [Test]
    public void GetWorldPosition_WhenCoordinateGiven_ReturnsCorrectWorldVector2()
    {
        int width = 10;
        int height = 10;
        float cellSize = 2.0f;

        var gridSystem = new GridSystem(height, width, cellSize);

        int testX = -1;
        int testZ = -1;

        Vector3 expectedPosition = new Vector3(-2f, 0, -2f);
        GridPosition testGridPosition = new GridPosition(testX, testZ);

        Vector3 actualPosition = gridSystem.GetWorldPosition(testGridPosition);

        Assert.AreEqual(expectedPosition, actualPosition, "World position isn't correct");
    }


    [Test]
    public void GetGridNode_WhenWorldPositionInsideCell_ReturnsCorrectFlooredNode()
    {
        // 1. Arrange 
        int width = 5;
        int height = 5;
        float cellSize = 2.0f;

        var gridSystem = new GridSystem(height, width, cellSize);

        Vector3 worldPosition = new Vector3(5.9f, 0f, 3.1f);

        // 2. Act
        GridPosition resultNode = gridSystem.GetGridNode(worldPosition);

        Assert.AreEqual(2, resultNode.X, "X needs to be rounded to 2");
        Assert.AreEqual(1, resultNode.Z, "Z needs to be rounded to 1");
    }
}