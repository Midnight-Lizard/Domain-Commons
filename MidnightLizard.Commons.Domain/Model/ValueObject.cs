using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidnightLizard.Commons.Domain.Model
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        /// <summary>
        /// Returns values of properties for compare with other ValueObject
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<object> GetPropertyValues();

        public override bool Equals(object obj)
        {
            return obj != null &&
                obj is ValueObject other &&
                this.Equals(other);
        }

        public override int GetHashCode()
        {
            return GetPropertyValues()
             .Select(x => x?.GetHashCode() ?? 0)
             .Aggregate((x, y) => x ^ y);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public bool Equals(ValueObject other)
        {
            if (other == null)
            {
                return false;
            }

            IEnumerator<object> thisValues = this.GetPropertyValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetPropertyValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (thisValues.Current is null ^ otherValues.Current is null)
                {
                    return false;
                }
                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }
    }
}
