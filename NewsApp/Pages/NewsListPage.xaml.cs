using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    private readonly string _categoryName;

    public NewsListPage(string categoryName)
    {
        InitializeComponent();
        _categoryName = categoryName;
        LblCategory.Text = _categoryName;
        GetNewsByCategory();
    }

    private async void GetNewsByCategory()
    {
        var apiService = new ApiService();
        var newsResult = await apiService.GetNews(_categoryName);
        CvNewsList.ItemsSource = newsResult.Articles;
    }

    private async void CvNewsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;

        var selectedArticle = e.CurrentSelection[0] as Article;
        if (selectedArticle != null)
        {
            await Navigation.PushAsync(new NewsDetailPage(selectedArticle));
        }
    }
}
