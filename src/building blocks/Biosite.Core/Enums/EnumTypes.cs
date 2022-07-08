using System.ComponentModel;

namespace Biosite.Core.Enums
{
    public enum NutraceuticalType
    {
        [Description("Não definido")]
        Undefined = 0,

        [Description("Aminoácidos")]
        AminoAcids = 1,

        [Description("Vitaminas")]
        Vitamins = 2,

        [Description("Minerais")]
        Minerals = 3,

        [Description("Fitoterapicos")]
        Phytotherapies = 4,

        [Description("Nutricosméticos")]
        NutriCosmetics = 5,

        [Description("Nutracéuticos")]
        Nutraceutics = 6,

        [Description("Ácidos Graxos")]
        FattyAcids = 7,

        [Description("Probióticos")]
        Probiotics = 8,

        [Description("Nootrópicos")]
        Nootropics = 9,

        [Description("Hormônios")]
        Hormones = 10,

        [Description("Fatores de Crescimento")]
        GrowthFactor = 11,

        [Description("Enzimas")]
        Enzimes = 12
    }

    public enum Gender
    {
        M,
        F
    }

    public enum PrescriptionType
    {
        //B: Biomarker
        [Description("Biomarcador")]
        B,
        //D: Disease
        [Description("Doença")]
        D
    }

    public enum BodyImageType
    {
        [Description("Padrão")]
        Default = 0,

        [Description("Ósseo")]
        Bone = 1,

        [Description("Circulatorio")]
        Circulatory = 2
    }

    public enum RangeClassification
    {
        [Description("0-7 anos")]
        Range_0_13 = 0,

        [Description("7-13 anos")]
        Range_7_13 = 1,

        [Description("13-18 anos")]
        Range_13_18 = 2,

        [Description("18-20 anos")]
        Range_18_20 = 3,

        [Description("20-49 anos")]
        Range_20_49 = 4,

        [Description("Acima de 50 anos")]
        Range_Above_50 = 5
    }

}
