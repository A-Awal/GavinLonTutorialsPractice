// See https://aka.ms/new-console-template for more information
// Expression trees represent code in a tree-like data structure,
// where each node is an expression, for example, a method call or a binary operation such as x < y.
// Expression Trees provide richer interaction with the arguments that are functions.
// Expression Trees represent code as a structure that you examine, modify, or execute. 

// These tools give you the power to manipulate code during run time.
// You write code that examines running algorithms, or injects new capabilities.
// In more advanced scenarios, you modify running algorithms and even translate C# expressions into another form for execution in another environment.

// You compile and run code represented by expression trees. Building and running expression trees enables dynamic modification of executable code,
// the execution of LINQ queries in various databases, and the creation of dynamic queries.

// You can have the C# or Visual Basic compiler create an expression tree for you based on an anonymous lambda expression,
// or you can create expression trees manually by using the System.Linq.Expressions namespace.

using System.Linq.Expressions;
using ExpressionTrees;

Expression<Func<int, bool>> lambda = num => num <5;
var c = lambda.Compile().Invoke(3);
Console.Write(c);

// You create expression trees in your code. You build the tree by creating each node and attaching the nodes into a tree structure. You learn how to create expressions in the article on building expression trees.
//
//     Expression trees are immutable. If you want to modify an expression tree, you must construct a new expression tree by copying the existing one and replacing nodes in it. You use an expression tree visitor to traverse the existing expression tree

// DATA THAT DEFINES CODE
var sum = 1 + 2;    
Expression<Func<int, bool>> exprTree = num => num < 5;
ParameterExpression param = (ParameterExpression)exprTree.Parameters[0];
BinaryExpression operation = (BinaryExpression)exprTree.Body;
ParameterExpression left = (ParameterExpression)operation.Left;
ConstantExpression right = (ConstantExpression)operation.Right;

Console.WriteLine("Decomposed expression: {0} => {1} {2} {3}",
    param.Name, left.Name, operation.NodeType, right.Value);

// Every node in an expression tree is an object of a class that is derived from Expression.
// That design makes visiting all the nodes in an expression tree a relatively straightforward recursive operation.
// The general strategy is to start at the root node and determine what kind of node it is.
// If the node type has children, recursively visit the children. At each child node, repeat the process used at the root node:
// determine the type, and if the type has children, visit each of the children.

var constant = Expression.Constant(24, typeof(int));

Console.WriteLine($"This is a/an {constant.NodeType} expression type");
Console.WriteLine($"The type of the constant value is {constant.Type}");
Console.WriteLine($"The value of the constant value is {constant.Value}");

Expression<Func<int, int, int>> addition = (a, b) => a + b;

Console.WriteLine($"This expression is a {addition.NodeType} expression type");
Console.WriteLine($"The name of the lambda is {((addition.Name == null) ? "<null>" : addition.Name)}");
Console.WriteLine($"The return type is {addition.ReturnType.ToString()}");
Console.WriteLine($"The expression has {addition.Parameters.Count} arguments. They are:");
foreach (var argumentExpression in addition.Parameters)
{
    Console.WriteLine($"\tParameter Type: {argumentExpression.Type.ToString()}, Name: {argumentExpression.Name}");
}

var additionBody = (BinaryExpression)addition.Body;
Console.WriteLine($"The body is a {additionBody.NodeType} expression");
Console.WriteLine($"The left side is a {additionBody.Left.NodeType} expression");
var left2 = (ParameterExpression)additionBody.Left;
Console.WriteLine($"\tParameter Type: {left.Type.ToString()}, Name: {left2.Name}");
Console.WriteLine($"The right side is a {additionBody.Right.NodeType} expression");
var right2 = (ParameterExpression)additionBody.Right;
Console.WriteLine($"\tParameter Type: {right.Type.ToString()}, Name: {right2.Name}");
Expression<Func<int>> sum1 = () => 1 + (2 + (3 + 4));

// var lm = new LambdaVisitor(addition);
// lm.Visit("");

var sm1 = new LambdaVisitor(sum1);
sm1.Visit("");

