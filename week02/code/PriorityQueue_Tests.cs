using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 3 items that have different priorities.
    // Expected Result: Dequeue should return the value with the highest priority.
    // Defect(s) Found: No defect found.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("mid", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("high", result);
    }

    [TestMethod]
    // Scenario: Add three items where two items share the highest priority.
    // Expected Result: Dequeue should return the tied highest-priority items in FIFO order.
    // Defect(s) Found: When multiple items have the same highest priority, dequeue does not return them in FIFO order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("first", 1);
        priorityQueue.Enqueue("second", 4);
        priorityQueue.Enqueue("third", 4);

        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: No defect found.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception of type {ex.GetType()} caught: {ex.Message}");
        }
    }
}