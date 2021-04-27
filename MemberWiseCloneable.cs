namespace ZespolLib
{
    public class MemberWiseCloneable<T>
    {
        public T Clone()
        {
            return (T) MemberwiseClone();
        }
    }
}