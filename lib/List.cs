namespace Elementary.Boson
{
    using Primitives;
    using UnitsNet;
    using UnitsNet.Units;
    using static Primitives.InteractionFlags;

    public readonly partial struct Boson
    {
        /// <summary>
        /// The photon is a type of elementary particle.
        /// It is the quantum of the electromagnetic field including electromagnetic radiation such
        /// as light and radio waves, and the force carrier for the electromagnetic force (even when static via virtual particles).
        /// The invariant mass of the photon is zero;
        /// it always moves at the speed of light in a vacuum.
        /// </summary>
        public static readonly Boson Photon = 
            new Boson(
                BosonType.Photon, 
                Energy.Zero, 
                "(0)", 
                Electromagnetic | Weak | Gravity, 
                "+(1)", 
                "+(0)", 
                0,
                float.PositiveInfinity);
        /// <summary>
        /// The Z bosons are together known as the weak or more generally as the intermediate vector bosons.
        /// These elementary particles mediate the weak interaction;
        /// </summary>
        public static readonly Boson Z =
            new Boson(
                BosonType.NeutralWeak, 
                new Energy(91.1876, EnergyUnit.GigaelectronVolt),
                "(0)", 
                Weak,
                "+(1)", 
                "+(0)", 
                0, 
                (float)new Energy(2.4952, EnergyUnit.GigaelectronVolt).ElectronVolts);
        /// <summary>
        /// The W bosons are together known as the weak or more generally as the intermediate vector bosons.
        /// These elementary particles mediate the weak interaction;
        /// </summary>
        public static readonly Boson W =
            new Boson(
                BosonType.NeutralWeak,
                new Energy(80.379, EnergyUnit.GigaelectronVolt),
                "+(1)",
                Weak,
                "+(1)",
                "+(1)",
                0,
                (float)new Energy(2.085, EnergyUnit.GigaelectronVolt).ElectronVolts);
        /// <summary>
        /// A gluon is an elementary particle that acts as the exchange particle (or gauge boson)
        /// for the strong force between quarks.
        /// </summary>
        public static readonly Boson Gluon =
            new Boson(
                BosonType.ChargedWeak,
                Energy.Zero,
                "+(0)",
                Weak,
                "+(1)",
                "+(0)",
                0,
                float.PositiveInfinity);
        /// <summary>
        /// In theories of quantum gravity, the graviton is the hypothetical quantum of gravity,
        /// an elementary particle that mediates the force of gravity.
        ///
        /// There is no complete quantum field theory of gravitons due to an outstanding mathematical problem with renormalization
        /// in general relativity. In string theory, believed to be a consistent theory of quantum gravity,
        /// the graviton is a massless state of a fundamental string.
        /// </summary>
        public static readonly Boson Graviton =
            new Boson(
                BosonType.Graviton,
                Energy.Zero,
                "+(2)",
                Gravity,
                "+(0)",
                "+(0)",
                0,
                float.PositiveInfinity);

        public static readonly Boson X =
            new Boson(
                BosonType.Graviton,
                new Energy(1E+15, EnergyUnit.GigaelectronVolt), 
                "+(4/3)",
                Gravity,
                "+(1)",
                "+(1/2)",
                5 / 3,
                float.PositiveInfinity);
        public static readonly Boson Y =
            new Boson(
                BosonType.Graviton,
                new Energy(1E+15, EnergyUnit.GigaelectronVolt),
                "+(1/3)",
                Gravity,
                "+(1)",
                "+(1/2)",
                5/3,
                float.PositiveInfinity);
    }
}