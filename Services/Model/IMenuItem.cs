namespace Grosvenor.Practicum.Services.Model
{
    public interface IMenuItem
    {
        string Name { get; }
        int MaxAllowablePerOrder { get; }
    }
}