using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsHomePage : ContentPage
{
    public List<Category> CategoryList { get; } = new()
    {
        new Category(){Name="World", ImageUrl="world.png"},
        new Category(){Name="Nation", ImageUrl="nation.png"},
        new Category(){Name="Business", ImageUrl="business.png"},
        new Category(){Name="Technology", ImageUrl="technology.png"},
        new Category(){Name="Entertainment", ImageUrl="entertainment.png"},
        new Category(){Name="Sports", ImageUrl="sports.png"},
        new Category(){Name="Science", ImageUrl="science.png"},
        new Category(){Name="Health", ImageUrl="health.png"},
    };

    public NewsHomePage()
    {
        InitializeComponent();
        GetBreakingNews();
        CvCategories.ItemsSource = CategoryList;
    }

    private async void GetBreakingNews()
    {
        var apiService = new ApiService();
        var newsResult = await apiService.GetNews("Sports");
        CvNews.ItemsSource = newsResult.Articles;
    }

    private async void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;

        var selectedCategory = e.CurrentSelection[0] as Category;
        if (selectedCategory != null)
        {
            await Navigation.PushAsync(new NewsListPage(selectedCategory.Name));
        }
    }

    private async void CvNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
