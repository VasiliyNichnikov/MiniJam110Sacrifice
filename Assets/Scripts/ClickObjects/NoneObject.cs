namespace ClickObjects
{
    public class NoneObject: IClickObject
    {
        public bool IsClick => false;
        public bool IsAction => false;
    }
}