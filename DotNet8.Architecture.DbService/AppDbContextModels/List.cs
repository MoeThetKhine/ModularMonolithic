namespace DotNet8.Architecture.DbService.AppDbContextModels;

#region List

public partial class List
{
    public long Id { get; set; }

    public string Key { get; set; } = null!;

    public string? Value { get; set; }

    public DateTime? ExpireAt { get; set; }
}

#endregion