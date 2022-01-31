namespace RomanNumerals
{
    public interface IConvNumbers
    {
        string ToRomanNumerals(int original);
        int ToArabicNumerals(string romanNumeral);
    }
}