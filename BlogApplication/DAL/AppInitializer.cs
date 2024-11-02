using Rating.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Rating.DAL
{
    public class AppInitializer : System.Data.Entity.DropCreateDatabaseAlways<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            //Users intialization data
            var users = new List<User>
            {
                new User{userId=Guid.NewGuid(), userName="kiko", password="solo", isAdmin=true},
                new User{userId=Guid.NewGuid(), userName="viktor", password="mery", isAdmin=false}
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            //Blogs intialization data
            var blogs = new List<content>
            {
                new content{postId=Guid.NewGuid(), authorId=users[0].userId, title="karbobruska", rating=10, source="https://www.naradie-shop.sk/resize/e:51a35/400/400/files/flex/karbobrusky/l21-6-230-schleifen.jpg"},
                new content{postId=Guid.NewGuid(), authorId=users[1].userId, title="udica", rating=5, source="https://www.esox-rybar.sk/galeria/1_1819/flame-set-privlacova-udica-navijak-default.jpg" }
            };
            blogs.ForEach(b => context.post.Add(b));
            context.SaveChanges();
        }
    }
}