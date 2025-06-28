using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Postagens.Services;
using Postagens.Models;

namespace Postagens.ViewModels
{
    public partial class PostViewModel : ObservableObject
    {
        [ObservableProperty]
        private string titulo;

        [ObservableProperty]
        private string corpo;

        List<PostModel> postagens;

        public ICommand DisplayPostsCommand { get; private set; }
        public PostViewModel(){ 
            DisplayPostsCommand = new Command(DisplayPosts);
        }

        public async void DisplayPosts()
        {
            PostService postservice = new PostService();
            postagens = await postservice.getPosts();
            Titulo = postagens[0].Title;
            Corpo = postagens[0].Body;
        }
    }
}
