using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
public void TestPriorityQueue_HigherPriorityRemovedFirst()
{
    var pq = new PriorityQueue();
    pq.Enqueue("Low", 1);
    pq.Enqueue("High", 5);
    pq.Enqueue("Medium", 3);
    Assert.AreEqual("High", pq.Dequeue());
}

[TestMethod]
public void TestPriorityQueue_FIFOTieBreaker()
{
    var pq = new PriorityQueue();
    pq.Enqueue("FirstHigh", 5);
    pq.Enqueue("SecondHigh", 5);
    Assert.AreEqual("FirstHigh", pq.Dequeue());
}


    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}