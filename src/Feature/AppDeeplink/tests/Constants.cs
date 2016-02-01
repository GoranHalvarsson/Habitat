namespace VisionsInCode.Foundation.AppDeeplink.Tests
{
  using Sitecore.Data;

  internal class Constants
  {
    internal struct StringOperations
    {

      internal struct IsEqualTo
      {
        internal static ID ItemID = new ID("{10537C58-1684-4CAB-B4C0-40C10907CE31}");
        internal const string ItemName = "is equal to";
      }

      internal struct Contains
      {
        internal static ID ItemID = new ID("{2E67477C-440C-4BCA-A358-3D29AED89F47}");
        internal const string ItemName = "contains";
      }

      internal struct IsCaseInsensitivelyEqualTo
      {
        internal static ID ItemID = new ID("{537244C2-3A3F-4B81-A6ED-02AF494C0563}");
        internal const string ItemName = "is case-insensitively equal to";
      }

      internal struct IsNotEqualTo
      {
        internal static ID ItemID = new ID("{A6AC5A6B-F409-48B0-ACE7-C3E8C5EC6406}");
        internal const string ItemName = "is not equal to";
      }

      internal struct IsNotCaseInsensitivelyEqualTo
      {
        internal static ID ItemID = new ID("{6A7294DF-ECAE-4D5F-A8D2-C69CB1161C09}");
        internal const string ItemName = "is not case-insensitively equal to";
      }
      internal struct MatchesTheRegularExpression
      {
        internal static ID ItemID = new ID("{F8641C26-EE27-483C-9FEA-35529ECC8541}");
        internal const string ItemName = "matches the regular expression";
      }
      internal struct EndsWith
      {
        internal static ID ItemID = new ID("{22E1F05F-A17A-4D0C-B376-6F7661500F03}");
        internal const string ItemName = "ends with";
      }
      internal struct StartsWith
      {
        internal static ID ItemID = new ID("{FDD7C6B1-622A-4362-9CFF-DDE9866C68EA}");
        internal const string ItemName = "starts with";
      }
    }
  }
}
