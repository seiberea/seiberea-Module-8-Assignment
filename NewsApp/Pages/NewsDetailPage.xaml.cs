using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailPage : ContentPage
{
    public NewsDetailPage(Article article)
    {
        InitializeComponent();
        BindingContext = article;
    }
}
