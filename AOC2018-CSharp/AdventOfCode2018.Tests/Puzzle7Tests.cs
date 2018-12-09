using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018.Day07;
using System.Collections.Generic;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Puzzle7Tests
    {
        // --------------------------------------------------------------------
        private static String[] TestData = new[]
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
            };

        private static String[] TestSteps = new[] { "A", "B", "C", "D", "E", "F" };
        
        private static StepRules GetTestData()
        {
            var rules = new StepRules();
            rules.AddRules(TestData);
            return rules;
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestStepRuleCreation()
        {
            string goodLine = TestData[0];
            string badLine = TestData[0].Replace("be", String.Empty);
            var sr = new StepRules();

            try
            {
                sr.AddRule(badLine);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid data line format found.", e.Message);
            }

            Assert.AreEqual(0, sr.Rules.Count);

            sr.AddRule(goodLine);
            Assert.AreEqual(2, sr.Rules.Count);
            Assert.IsTrue(sr.Rules.ContainsKey("A"));   // Step A has a dependency on Step C.
            Assert.IsTrue(sr.Rules.ContainsKey("C"));   // Step C has no dependency.
            Assert.AreEqual(0, sr.Rules["C"].Count);
            Assert.AreEqual(1, sr.Rules["A"].Count);
            Assert.IsTrue(sr.Rules["A"].Contains("C"));

            sr.Clear();
            Assert.AreEqual(0, sr.Rules.Count);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestStepLoadingFromTestData()
        {
            var sr = GetTestData();

            foreach (var s in TestSteps)
            {
                Assert.IsTrue(sr.Rules.ContainsKey(s));
            }
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestPuzzleLoadingStepRules()
        {
            var p = new Puzzle07();
            var s = p.LoadStepRules();
            Assert.AreNotEqual(0, s.Result.Rules.Count);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestAllReadySteps()
        {
            var sr = GetTestData();
            var ready = sr.GetReadySteps();
            Assert.AreEqual(1, ready.Count);
            Assert.AreEqual("C", ready[0]);

            sr.RemoveDependency(ready[0]);
            ready = sr.GetReadySteps();
            Assert.AreEqual(2, ready.Count);
            Assert.AreEqual("A", ready[0]);
            Assert.AreEqual("F", ready[1]);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestNextReadyStep()
        {
            var sr = GetTestData();
            var ready = sr.GetNextReadyStep();

            Assert.IsFalse(String.IsNullOrEmpty(ready));
            Assert.AreEqual("C", ready);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestRemoveDependency()
        {
            var sr = GetTestData();
            sr.RemoveDependency("C");
            var ready = sr.GetNextReadyStep();
            Assert.IsFalse(String.IsNullOrEmpty(ready));
            Assert.AreEqual("A", ready);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestTaskDurationMap()
        {
            var d = WorkProcessor.GetTaskDuration("A");
            Assert.AreEqual(1, d);

            d = WorkProcessor.GetTaskDuration("Z");
            Assert.AreEqual(26, d);

            d = WorkProcessor.GetTaskDuration("*");
            Assert.AreEqual(-1, d);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestWorkProcessorQueueTasks()
        {
            var wp = new WorkProcessor(2);
            Assert.IsTrue(wp.AddTask("A"));
            Assert.IsTrue(wp.AddTask("B"));
            Assert.IsFalse(wp.AddTask("C"));
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestWorkProcessorProcessQueue()
        {
            var wp = new WorkProcessor(2);
            var ready = new List<string> { "A", "F", "C" };
            wp.LoadWorkQueue(ref ready);
            Assert.AreEqual(1, ready.Count);
            Assert.AreEqual("C", ready[0]);

            List<string> completed;
            for (var i = 0; i < 7; i++)
            {
                completed = wp.ProcessQueue();

                if (i == 0)
                {
                    Assert.AreEqual(1, completed.Count);
                    Assert.AreEqual("A", completed[0]);
                }
                else if (i == 5)
                {
                    Assert.AreEqual(1, completed.Count);
                    Assert.AreEqual("F", completed[0]);
                }
                else if (i > 5)
                {
                    Assert.IsTrue(wp.IsTaskQueueEmpty());
                }
                else
                {
                    Assert.AreEqual(0, completed.Count);
                }
            }
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestPuzzle7A()
        {
            var steps = GetTestData();
            Assert.AreEqual(TestSteps.Length, steps.Rules.Count);
            var s = new Solver07();
            var result = s.PuzzleA(steps);
            Assert.AreEqual("CABDFE", result);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestPuzzle7B()
        {
            var steps = GetTestData();
            Assert.AreEqual(TestSteps.Length, steps.Rules.Count);
            var s = new Solver07();
            var result = s.PuzzleB(steps, 2);
            Assert.AreEqual("15", result);
        }
    }
}
