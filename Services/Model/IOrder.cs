namespace Grosvenor.Practicum.Services.Model
{
    public interface IOrder
    {
        int EntreeCount { get; }
        int SideCount { get; }
        int DrinkCount { get; }
        int DessertCount { get; }
        void AddItem(MenuItemType menuItemType);
    }
}