using System.ComponentModel;

namespace WowAutoApp.Core.Domain.Enums
{
    /// <summary>
    /// Credit application residence owner type
    /// </summary>
    public enum EmploymentStatusType
    {
        [Description("Self Employed")]
        SelfEmployed = 0,
        [Description("Contract")]
        Contract = 1,
        [Description("Retired")]
        Retired = 2,
        [Description("Unemployed")]
        Unemployed = 3,
        [Description("Business Owner")]
        BusinessOwner = 4
    }
}