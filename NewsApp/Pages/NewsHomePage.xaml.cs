using NewsApp.Models;
using NewsApp.Pages;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsHomePage : ContentPage
{
    public List<Article> ArticleList;
    public List<Category> CategoryList = new List<Category>()
    {
        new Category(){Name="World", ImageUrl = "world.png"},
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

    private async Task GetBreakingNews()
    {
        var apiService = new ApiService();
        var newsResult = await apiService.GetNews("Sports");
        ArticleList = newsResult.Articles;
        CvNews.ItemsSource = ArticleList;
    }

    private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Category selectedCategory)
        {
            Navigation.PushAsync(new NewsListPage(selectedCategory.Name));
        }
    }
}
