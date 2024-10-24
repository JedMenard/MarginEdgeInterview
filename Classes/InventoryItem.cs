using MarginEdgeInterview.Enums;

namespace MarginEdgeInterview.Classes;

public class InventoryItem
{
    public readonly string Name;
    private readonly List<CategoryEnum> Categories;
	public int QuantityInInventory;
    private readonly double PricePerQuantity;

    public InventoryItem(string name, List<CategoryEnum> categories, int? quantity, double price)
    {
        this.Name = name;
        this.Categories = categories;
        this.QuantityInInventory = quantity ?? 0;
        this.PricePerQuantity = price;
    }
}
