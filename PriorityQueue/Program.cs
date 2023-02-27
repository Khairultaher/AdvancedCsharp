using System;
using System.Collections.Generic;

// Create a priority queue of integers
PriorityQueue<int,int> queue = new PriorityQueue<int,int>();

// Add some items to the queue

queue.Enqueue(5, queue.Count + 1); // 1
queue.Enqueue(3, queue.Count + 1);
queue.Enqueue(7, queue.Count + 1);

// Get the item with the highest priority (which is 7)
int highestPriorityItem = queue.Peek();

// Remove the item with the highest priority (which is 7)
int dequeuedItem = queue.Dequeue();



Console.ReadLine();