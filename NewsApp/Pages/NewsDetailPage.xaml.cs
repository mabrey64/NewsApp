using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailPage : ContentPage
{
	public Article SelectedArticle { get; set; }
    public NewsDetailPage(Article article)
	{
		InitializeComponent();
        BindingContext = article;
        SelectedArticle = article;
        Title = article.Title;
    }
}