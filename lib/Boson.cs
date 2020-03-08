namespace Elementary.Boson
{
    using System;
    using Primitives;
    using UnitsNet;
    using UnitsNet.Units;
    using static @internal.Constants;
    using static Primitives.BosonType;
    using ElectricCharge = Primitives.ElectricCharge;

    [Serializable]
    public readonly partial struct Boson : IComparable, IComparable<Boson>, IEquatable<Boson>
    {
        private readonly BosonType _type;
        private readonly Energy _naturalMass;
        private readonly ElectricCharge _electricCharge;
        private readonly Mass _mass;
        private readonly InteractionFlags _interactionFlags;
        private readonly Spin _spin;
        private readonly Spin _isospin;
        private readonly int _hypercharge;
        private readonly float _lifetime;

        public Boson(
            BosonType Type, 
            Energy mass, 
            ElectricCharge electricCharge, 
            InteractionFlags interactionFlags, 
            Spin spin, 
            Spin isospin, 
            int hypercharge, 
            float lifetime)
        {
            this._naturalMass = mass;
            this._mass = new Mass((_naturalMass.ElectronVolts * SpeedOfLightSquared) / ElectronMassPlank,
                MassUnit.Kilogram);
            this._type = Type;
            this._electricCharge = electricCharge;
            this._interactionFlags = interactionFlags;
            this._spin = spin;
            this._isospin = isospin;
            this._hypercharge = hypercharge;
            this._lifetime = lifetime;
        }

        public bool IsStable() => float.IsInfinity(_lifetime);
        public bool IsVector() => _spin.Numerator == 1;
        public bool IsObserved() => _type != BosonType.Graviton;

        #region IComparable, IComparable<Boson>, IEquatable<Boson>

        /// <inheritdoc />
        public bool Equals(Boson other)
        {
            if (other == default)
                return false;
            if (this == default)
                return false;
            return this == other;
        }
        /// <inheritdoc />
        public int CompareTo(object other)
        {
            if (other is Boson q)
                return CompareTo(q);
            return 0;
        }

        /// <inheritdoc />
        public int CompareTo(Boson other)
        {
            if (other._type > this._type)
                return 1;
            if (other._type < this._type)
                return -1;
            return 0;
        }
        /// <inheritdoc />
        public override bool Equals(object obj)
            => obj is Boson other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)_type;
                hashCode = (hashCode * 397) ^ _electricCharge.GetHashCode();
                hashCode = (hashCode * 397) ^ _spin.GetHashCode();
                hashCode = (hashCode * 397) ^ _isospin.GetHashCode();
                hashCode = (hashCode * 397) ^ _naturalMass.GetHashCode();
                hashCode = (hashCode * 397) ^ _mass.GetHashCode();
                hashCode = (hashCode * 397) ^ _interactionFlags.GetHashCode();
                hashCode = (hashCode * 397) ^ _hypercharge.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)_lifetime;
                return hashCode;
            }
        }
        #endregion

        public static bool operator ==(Boson q1, Boson q2)
        {
            // handle 'boson == default'
            if (q1._type == Unk || q2._type == Unk)
                return false;
            return (q1._type == q2._type);
        }

        public static bool operator !=(Boson q1, Boson q2) => !(q1 == q2);

    }
}
