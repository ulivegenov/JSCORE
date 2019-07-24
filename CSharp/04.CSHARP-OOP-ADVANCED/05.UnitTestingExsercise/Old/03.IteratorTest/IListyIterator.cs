public interface IListyIterator
{
    bool HasNext();
    bool Move();
    //Must be a void Type. Only for Unit test is string Type!!!!
    string Print();
}