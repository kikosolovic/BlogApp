using BlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using static System.Net.WebRequestMethods;

namespace BlogApplication.DAL
{
    public class AppInitializer : System.Data.Entity.DropCreateDatabaseAlways<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            //Users intialization data
            var users = new List<User>
            {
                new User{userId=Guid.NewGuid(), userName="kiko", password="solo", isAdmin=true},
                new User{userId=Guid.NewGuid(), userName="vikor", password="prd", isAdmin=false}
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            //Blogs intialization data
            var blogs = new List<Blog>
            {
                new Blog{blogId=Guid.NewGuid(), authorId=users[0].userId, title="hlupa ryba", rating="3/10", image="https://www.gannett-cdn.com/presto/2022/11/28/USAT/d94f7349-890c-47e1-a681-7d65a4e09f42-221019_Batfish_Dumpling__Museums_Victoria-Ben_Healley.jpg?crop=7354,4137,x1,y350&width=3200&height=1801&format=pjpg&auto=webp"},
                new Blog{blogId=Guid.NewGuid(), authorId=users[1].userId, title="dinosaurus", rating="4/10", image="https://m.media-amazon.com/images/I/513SgKCkhbL._AC_UF894,1000_QL80_.jpg"},
                new Blog{blogId=Guid.NewGuid(), authorId=users[1].userId, title="nemo", rating="6/10", image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSc3xqlOqb4lgTAFBgiHWXVsZ0gOnMPuaTrwQ&usqp=CAU"}
                
            };
            blogs.ForEach(b => context.Blogs.Add(b));
            context.SaveChanges();
        }
    }
}