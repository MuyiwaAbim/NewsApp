using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailPage : ContentPage
{
    public NewsDetailPage(Article article)
    {
        InitializeComponent();
        if (article != null)
        {
            ImgNews.Source = article.Image;
            LblTitle.Text = article.Title;
            LblContent.Text = article.Content;
        }
    }
}
