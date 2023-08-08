# unit testing course

**Why we need unit testing?**
Unit testing is a crucial practice in software development, including C#. It involves writing small, isolated tests for individual units of code, such as functions or methods, to ensure they work as expected. Here's why unit testing is important:

- Detecting Bugs Early: _Unit tests help catch bugs and issues in code early in the development process, making them easier and cheaper to fix._
- Regression Prevention: _As you make changes or updates to your codebase, unit tests ensure that existing functionality remains intact._
- Documentation: _Unit tests act as documentation for how your code should work. They provide clear examples of how to use functions and methods._
- Design Improvement: _Writing tests often forces you to write more modular and loosely-coupled code, leading to better overall design._
- Confidence in Refactoring: _When you need to refactor or make changes, having comprehensive unit tests gives you confidence that you haven't broken anything._

**Best practices for writing Unit tests:**
- Test Isolation: _Each test should run independently and not depend on the outcome of other tests._
- Clear Test Naming: _Use descriptive names for tests that clearly indicate what aspect of functionality is being tested._
- Arrange-Act-Assert (AAA) Pattern: _Structure your tests into three sections: Arrange (set up), Act (perform the action), and Assert (verify the result)._
- Single Responsibility Principle: _Test only one aspect of functionality per test._
- Mocks and Stubs: _Use mocks and stubs to isolate the code being tested from its dependencies._
- Test Coverage: _Aim for high test coverage to ensure critical parts of your code are well-tested._
- Keep Tests Fast: _Tests should execute quickly to encourage frequent testing._

**Using initialization and cleanup attributes:**
We can use attributes to define methods that run before and after tests. 
This is useful for setting up test data and cleaning up resources. 

- **[SetUp]**: Runs before each test and can be used for test data initialization.
- **[TearDown]**: Runs after each test and can be used for cleanup tasks.

**Attributes that help you organize unit tests:**
Organizing tests is essential as your codebase grows. 
Commonly used attributes include:

- **[TestFixture]**: Used to define a test fixture (a container for tests) in NUnit.
- **[TestClass] and [TestMethod]**: Used to define test classes and methods in MSTest.

Using different assert classes and methods:
Assertions are used to verify that expected conditions are met in your tests. 
Commonly used assertion methods include:

- Assert.AreEqual(expected, actual): Compares if two values are equal.
- Assert.IsTrue(condition): Checks if a condition is true.
- Assert.IsFalse(condition): Checks if a condition is false.
- Assert.IsNull(obj), Assert.IsNotNull(obj): Checks for null or non-null values.

**Consolidate tests by making them data driven:**
Data-driven testing involves running the same test code with multiple sets of input data. This can be achieved using parameterized tests. 
In NUnit and MSTest, you can use attributes like [TestCase] and [DataRow] to supply multiple inputs to a single test method.

**Automating Unit tests with the command line:**
Many testing frameworks allow you to automate running tests from the command line, which is useful for integration into build and deployment processes. 
For example, in NUnit, you can use the nunit3-console.exe tool to run tests. In MSTest, you can use the **_vstest.console.exe tool_**.
