using MarginEdgeInterview.Enums;

namespace MarginEdgeInterview.Classes;

public static class Endpoints
{
    /// <summary>
    /// Create new instance of InventoryItem class, add to storage dictionary, optionally include starting quantity.
    /// </summary>
    /// <param name="inventory"></param>
    /// <param name="name"></param>
    /// <param name="categories"></param>
    /// <param name="pricePerQuantity"></param>
    /// <param name="quantityInInventory"></param>
    /// <returns></returns>
    public static bool AddNewItemToInventory(Dictionary<string, InventoryItem> inventory, string name, List<CategoryEnum> categories, double pricePerQuantity, int? quantityInInventory)
    {
        // Check that no item with that name already exists.
        if (inventory.ContainsKey(name))
        {
            throw new ArgumentException("Item with the given name already exists in the inventory. If you're trying to set the quantity of that item, use the SetQuantityInInventory API instead.");
        }

        // Create the new item and add it to the inventory.
        InventoryItem newItem = new InventoryItem(name, categories, quantityInInventory, pricePerQuantity);
        inventory.Add(name, newItem);

        return true;
    }

    /// <summary>
    /// Fetch the item from the dictionary, set the quantity to the new value
    /// </summary>
    /// <param name="inventory"></param>
    /// <param name="name"></param>
    /// <param name="newQuantity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static bool SetQuantityInInventory(Dictionary<string, InventoryItem> inventory, string name, int newQuantity)
    {
        // Check to make sure the item is already in the inventory.
        if (!inventory.ContainsKey(name))
        {
            throw new ArgumentException("Item does not exist in the inventory. If you're trying to add a new item, please use the AddNewItemToInventory.");
        }

        // Make sure the new value is non-negative.
        if (newQuantity < 0)
        {
            throw new ArgumentException("Please provie a non-negative value for the item's quantity.");
        }

        // Update the inventory count for the item to the new value.
        inventory[name].QuantityInInventory = newQuantity;

        return true;
    }

    /// <summary>
    /// Provide user-friendly report for items below a given threshold
    /// </summary>
    /// <param name="inventory"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static List<InventoryItem> GetReportForItemsBelowQuantityLevel(Dictionary<string, InventoryItem> inventory, int quantity)
    {
        // Make sure the threshold is non-negative.
        if (quantity < 0)
        {
            throw new ArgumentException("Please provide a non-negative threshold for the report.");
        }

        return inventory.Values
            .Where(item => item.QuantityInInventory < quantity)
            .OrderBy(item => item.Name)
            .ToList();
    }

    /// <summary>
    /// TODO: Implement this if we have time
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static int GetQuantityOfItem(string name)
    {
        throw new NotImplementedException();
    }
}
