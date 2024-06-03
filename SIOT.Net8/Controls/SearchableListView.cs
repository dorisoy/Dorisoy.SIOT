using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOT.Controls;

/// <summary>
/// This class extends the behavior of the ListView control to filter the ListViewItem based on text.
/// </summary>
public class SearchableListView : ListView
{
    #region Field

    /// <summary>
    /// Gets or sets the text value used to search.
    /// </summary>
    public static readonly BindableProperty SearchTextProperty =
        BindableProperty.Create(nameof(SearchText), typeof(string), typeof(SearchableListView), null, BindingMode.Default, null, OnSearchTextChanged);

    /// <summary>
    /// Gets or sets the text value used to search.
    /// </summary>
    private string searchText;
    private Predicate<object> filter;
    #endregion

    #region Property

    /// <summary>
    /// Gets or sets the text value used to search.
    /// </summary>
    public string SearchText
    {
        get { return (string)this.GetValue(SearchTextProperty); }
        set { this.SetValue(SearchTextProperty, value); }
    }

    //
    // Summary:
    //     Gets or sets the filter for the underlying collection
    public Predicate<object> Filter
    {
        get
        {
            return filter;
        }
        set
        {
            filter = value;
        }
    }
    #endregion

    #region Method

    /// <summary>
    /// Filtering the list view items based on the search text.
    /// </summary>
    /// <param name="obj">The list view item</param>
    /// <returns>Returns the filtered item</returns>
    public virtual bool FilterContacts(object obj)
    {
        if (this.SearchText == null)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Invoked when the search text is changed.
    /// </summary>
    /// <param name="bindable">The ListView</param>
    /// <param name="oldValue">The old value</param>
    /// <param name="newValue">The new value</param>
    private static void OnSearchTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var listView = bindable as SearchableListView;
        if (newValue != null && listView.ItemsSource != null)
        {
            listView.searchText = (string)newValue;
            //listView.ItemsSource.Filter = listView.FilterContacts;
            //listView.ItemsSource.RefreshFilter();
        }

        //listView.RefreshView();
    }

    #endregion
}
