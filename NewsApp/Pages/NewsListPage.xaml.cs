using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    public NewsListPage(string categoryName)
    {
        InitializeComponent();
        Title = categoryName;
        LoadArticles(categoryName);
    }

    private async void LoadArticles(string category)
    {
        var apiService = new ApiService();
        var newsResult = await apiService.GetNews(category);
        CvArticles.ItemsSource = newsResult.Articles;
    }

    private void CvArticles_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Article selectedArticle)
        {
            Navigation.PushAsync(new NewsDetailPage(selectedArticle));
        }
    }
}
