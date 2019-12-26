using System.ComponentModel;

namespace WowAutoApp.Core.Domain.Enums
{
    /// <summary>
    /// Credit application residence owner type
    /// </summary>
    public enum OwnerType
    {
        [Description("Self or Spouse")]
        SelfOrSpouse = 0,
        [Description("Landlord")]
        Landlord = 1,
        [Description("Relative")]
        Relative = 2,
        [Description("Mortgage")]
        Mortgage = 3,
        [Description("Others")]
        Others = 4
    }
}