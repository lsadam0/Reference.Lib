using System;

namespace Reference.Lib.Utils
{
    /// <summary>
    ///     - Sorting operations only consider SortyEntity.Value
    ///     - Equality operations consider SortEntity.Value & SortEntity.Identifier
    /// </summary>
    public class SortEntity : IEquatable<SortEntity>, IComparable, IComparable<SortEntity>
    {
        public SortEntity(int value)
        {
            Value = value;
            Identifier = Guid.NewGuid();
        }

        public Guid Identifier { get; }

        public int Value { get; }


        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null)) return 1;
            if (!(obj is SortEntity)) throw new ArgumentException();

            return CompareTo((SortEntity) obj);
        }

        public int CompareTo(SortEntity other)
        {
            return ReferenceEquals(other, null) ? 1 : Value.CompareTo(other.Value);
        }

        public bool Equals(SortEntity other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Identifier == other.Identifier;
        }

        public static bool operator ==(SortEntity a, SortEntity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }

        public static bool operator !=(SortEntity a, SortEntity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (!(obj is SortEntity)) return false;

            return Equals((SortEntity) obj);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}