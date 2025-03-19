namespace DotNet8.Architecture.DbService.AppDbContextModels;

#region Hash

public partial class Hash
{
    public string Key { get; set; } = null!;

    public string Field { get; set; } = null!;

    public string? Value { get; set; }

    public DateTime? ExpireAt { get; set; }
}

#endregion
