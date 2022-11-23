namespace HomeWork_23_11_2022;

using System;
using System.Collections.Generic;

public class PagnationHelper<T>
{
    private IList<T> _collection;
    private int _itemsPerPage;
    
    /// <summary>
    /// Constructor, takes in a list of items and the number of items that fit within a single page
    /// </summary>
    /// <param name="collection">A list of items</param>
    /// <param name="itemsPerPage">The number of items that fit within a single page</param>
    public PagnationHelper(IList<T> collection, int itemsPerPage)
    {
        if (collection is null)
        {
            throw new ArgumentNullException(nameof(collection), "Collection is null.");
        }

        if (itemsPerPage <= 0)
        {
            throw new ArgumentException("Item per page cannot be less or equal zero.", nameof(itemsPerPage));
        }

        this._collection = collection;
        this._itemsPerPage = itemsPerPage;
    }

    /// <summary>
    /// The number of items within the collection
    /// </summary>
    public int ItemCount
    {
        get => this._collection.Count;
    }

    /// <summary>
    /// The number of pages
    /// </summary>
    public int PageCount
    {
        get => ItemCount % this._itemsPerPage == 0 ? ItemCount / this._itemsPerPage : ItemCount / this._itemsPerPage + 1;
    }

    /// <summary>
    /// Returns the number of items in the page at the given page index 
    /// </summary>
    /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
    /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
    public int PageItemCount(int pageIndex)
    {
        if (pageIndex >= PageCount || pageIndex < 0)
        {
            return -1;
        }

        if (pageIndex < PageCount - 1)
        {
            return this._itemsPerPage;
        }
        
        return (pageIndex + 1) * this._itemsPerPage - ItemCount;
    }

    /// <summary>
    /// Returns the page index of the page containing the item at the given item index.
    /// </summary>
    /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
    /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
    public int PageIndex(int itemIndex)
    {
        if (itemIndex >= ItemCount || itemIndex < 0)
        {
            return -1;
        }

        return itemIndex / this._itemsPerPage;
    }
}