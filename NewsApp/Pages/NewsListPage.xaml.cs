using System.Collections.ObjectModel;

namespace NewsApp.Pages;
using NewsApp.Models;
using NewsApp.Services;

public partial class NewsListPage : ContentPage
{
    private ObservableCollection<Article> ArticleList { get; set; } = new ObservableCollection<Article>();
    private string _categoryName;
    public NewsListPage(string categoryName)
	{
        InitializeComponent();
        Title = categoryName;
        _categoryName = categoryName;
        CvArticles.ItemsSource = ArticleList;
        _ = LoadArticlesAsync(categoryName);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadArticlesAsync(_categoryName);
    }

    private async Task LoadArticlesAsync(string categoryName)
    {
        var apiService = new ApiService();
        var newsResult = await apiService.GetNews(categoryName);
        ArticleList.Clear();
        foreach (var item in newsResult.Articles)
        {
            ArticleList.Add(item);
        }
    }
}