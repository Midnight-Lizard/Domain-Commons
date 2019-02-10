using System;

namespace MidnightLizard.Commons.Domain.Model
{
    public class SingleValueType
    {
    }

    public class SingleValueType<TValue> : SingleValueType, IEquatable<SingleValueType<TValue>>
        where TValue : IComparable, IComparable<TValue>, IEquatable<TValue>
    {
        public TValue Value { get; protected set; }

        protected SingleValueType()
        {
        }

        public SingleValueType(TValue value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj != null &&
                obj is SingleValueType<TValue> other &&
                this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Value != null ? this.Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return this.Value?.ToString();
        }

        public bool Equals(SingleValueType<TValue> other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.Value == null ^ other.Value == null)
            {
                return false;
            }

            if (this.Value != null && !this.Value.Equals(other.Value))
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(SingleValueType<TValue> left, SingleValueType<TValue> right)
        {
            if (left is null)
            {
                return right is null ? true : false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        public static bool operator !=(SingleValueType<TValue> left, SingleValueType<TValue> right)
        {
            return !(left == right);
        }
    }
}
