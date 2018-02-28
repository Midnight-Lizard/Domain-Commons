using System;
using System.Collections.Generic;
using System.Text;

namespace MidnightLizard.Commons.Domain.Model
{
    public abstract class DomainEntityId { }

    public class DomainEntityId<T> : DomainEntityId, IEquatable<DomainEntityId<T>>
        where T : IComparable, IComparable<T>, IEquatable<T>
    {
        public T Value { get; protected set; }

        public DomainEntityId()
        {
        }

        public DomainEntityId(T id)
        {
            Value = id;
        }

        public override bool Equals(object obj)
        {
            return obj != null &&
                obj is DomainEntityId<T> other &&
                this.Equals(other);
        }

        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return Value?.ToString();
        }

        public bool Equals(DomainEntityId<T> other)
        {
            if (other == null) return false;

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
    }
}
