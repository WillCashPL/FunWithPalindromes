namespace PalindromesLib.Models;

public class TextWithExtendedInfo
{
    public string Text { get; }
    public int OriginalIndex { get; }
    public int Length => Text.Length;

    public TextWithExtendedInfo(string text, int originalIndex)
    {
        Text = text;
        OriginalIndex = originalIndex;
    }

    public override string ToString()
    {
        return $"Text: {Text}, Index: {OriginalIndex}, Length: {Length} \n";
    }

    private sealed class TextOriginalIndexEqualityComparer : IEqualityComparer<TextWithExtendedInfo>
    {
        public bool Equals(TextWithExtendedInfo x, TextWithExtendedInfo y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            
            return string.Equals(x.Text, y.Text, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(TextWithExtendedInfo obj)
        {
            return HashCode.Combine(obj.Text.ToLowerInvariant());
        }
    }

    public static IEqualityComparer<TextWithExtendedInfo> TextOriginalIndexComparer { get; } = new TextOriginalIndexEqualityComparer();
}