/*
 * The Interpreter pattern is a design pattern used in software development to define a language and provide an interpreter for that language. The interpreter is responsible for interpreting the language and performing the operations defined by the language. The interpreter uses a set of rules to understand and execute commands in that language
 * 
 * Defines a grammatical representation for a language and provides an interpreter to deal with this grammar.
*/

var expression = new AddExpression(new NumberExpression(2), new NumberExpression(3));
var result = expression.Interpret();
Console.WriteLine(result);

abstract class Expression
{
    public abstract int Interpret();
}
class NumberExpression : Expression
{
    public int Number { get; set; }
    public NumberExpression(int number)
    {
        Number = number;
    }
    public override int Interpret()
    {
        return Number;
    }
}
class AddExpression : Expression
{
    public Expression Left { get; set; }
    public Expression Right { get; set; }
    public AddExpression(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }
    public override int Interpret()
    {
        return Left.Interpret() + Right.Interpret();
    }
}




