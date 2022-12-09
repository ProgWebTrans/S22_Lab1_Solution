using Microsoft.EntityFrameworkCore;
using Moq;
using PresseMots_DataAccess.Context;
using PresseMots_DataModels.Entities;
using PresseMots_Web.Services.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vereyon.Web;

namespace PresseMots_WebTests
{
    public class StoryServiceTest
    {

        public const string LoremIpsumFirst300 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nunc lobortis mattis aliquam faucibus. Amet consectetur adipiscing elit ut aliquam purus sit. Elementum nisi quis eleifend quam adipiscing vitae. Nibh sed pulvinar proin gravid";


        private DbContextOptions<PresseMotsDbContext> SetUpInMemory(string uniqueName, bool longContent = false)
        {
            var options = new DbContextOptionsBuilder<PresseMotsDbContext>().UseInMemoryDatabase(uniqueName).Options;
            SeedInMemoryStore(options, longContent);
            return options;
        }

        private void SeedInMemoryStore(DbContextOptions<PresseMotsDbContext> options, bool longContent)
        {
            using (var context = new PresseMotsDbContext(options))
            {


                if (!context.Stories.Any())
                {
                    context.Stories.AddRange(
                        new Story()
                        {
                            Id = 1,
                            Content = longContent ? @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nunc lobortis mattis aliquam faucibus. Amet consectetur adipiscing elit ut aliquam purus sit. Elementum nisi quis eleifend quam adipiscing vitae. Nibh sed pulvinar proin gravida hendrerit lectus. Ut enim blandit volutpat maecenas. Vitae proin sagittis nisl rhoncus mattis rhoncus urna neque viverra. Auctor urna nunc id cursus metus aliquam eleifend. Amet cursus sit amet dictum. Felis eget velit aliquet sagittis id consectetur purus ut faucibus. Elementum integer enim neque volutpat ac. Ultrices vitae auctor eu augue ut lectus arcu bibendum at. Enim facilisis gravida neque convallis a cras semper. Pellentesque sit amet porttitor eget dolor morbi non. Malesuada bibendum arcu vitae elementum curabitur vitae nunc sed velit. Viverra aliquet eget sit amet tellus cras adipiscing enim eu. Ullamcorper eget nulla facilisi etiam. Non blandit massa enim nec. Id nibh tortor id aliquet lectus proin. Enim sed faucibus turpis in eu mi.
Volutpat est velit egestas dui id ornare arcu odio ut.Ultrices eros in cursus turpis massa tincidunt dui.Vel orci porta non pulvinar neque laoreet suspendisse interdum.Aenean vel elit scelerisque mauris pellentesque.Malesuada nunc vel risus commodo viverra maecenas accumsan.Nibh mauris cursus mattis molestie a iaculis.Lacus vestibulum sed arcu non odio euismod lacinia at quis.Enim diam vulputate ut pharetra sit amet aliquam.Facilisi morbi tempus iaculis urna id.Vestibulum sed arcu non odio euismod lacinia at quis.Nunc vel risus commodo viverra maecenas accumsan lacus vel facilisis.Tempus egestas sed sed risus.Enim lobortis scelerisque fermentum dui faucibus in ornare quam.Vitae semper quis lectus nulla at volutpat diam.Semper auctor neque vitae tempus quam pellentesque nec.Bibendum ut tristique et egestas quis.Odio eu feugiat pretium nibh ipsum consequat nisl vel.
Nulla malesuada pellentesque elit eget gravida cum sociis natoque.Ultrices in iaculis nunc sed augue.Sit amet consectetur adipiscing elit pellentesque habitant.Ac orci phasellus egestas tellus rutrum tellus pellentesque eu tincidunt.Imperdiet nulla malesuada pellentesque elit.Risus sed vulputate odio ut enim blandit volutpat maecenas.Blandit turpis cursus in hac habitasse.Consectetur adipiscing elit pellentesque habitant morbi.Malesuada nunc vel risus commodo viverra maecenas accumsan.Egestas fringilla phasellus faucibus scelerisque eleifend.Tortor vitae purus faucibus ornare suspendisse sed.Tincidunt lobortis feugiat vivamus at augue eget arcu dictum.Scelerisque fermentum dui faucibus in ornare.Turpis tincidunt id aliquet risus feugiat in ante metus dictum.Urna cursus eget nunc scelerisque viverra mauris in. Dui sapien eget mi proin sed libero.Suspendisse in est ante in nibh mauris cursus mattis molestie.Felis eget nunc lobortis mattis aliquam faucibus purus in.
Orci nulla pellentesque dignissim enim sit amet.Aliquam malesuada bibendum arcu vitae elementum curabitur.Facilisis leo vel fringilla est ullamcorper eget nulla.Nullam eget felis eget nunc lobortis.Elementum sagittis vitae et leo duis ut diam.Diam phasellus vestibulum lorem sed risus.Eu sem integer vitae justo eget magna fermentum iaculis eu.Nam libero justo laoreet sit amet cursus sit amet dictum.Eu tincidunt tortor aliquam nulla facilisi cras fermentum odio.Sem fringilla ut morbi tincidunt augue.Nunc aliquet bibendum enim facilisis gravida neque.Rhoncus urna neque viverra justo.Nisi lacus sed viverra tellus in hac habitasse.Vel elit scelerisque mauris pellentesque pulvinar pellentesque.
Placerat orci nulla pellentesque dignissim enim sit amet venenatis urna.Sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae.Proin nibh nisl condimentum id venenatis a condimentum.Tempus urna et pharetra pharetra massa massa ultricies mi quis.Sem nulla pharetra diam sit.Congue mauris rhoncus aenean vel elit scelerisque mauris pellentesque.Aliquet risus feugiat in ante metus dictum at.Massa vitae tortor condimentum lacinia quis vel eros.Praesent semper feugiat nibh sed.Volutpat ac tincidunt vitae semper quis lectus nulla at.Commodo nulla facilisi nullam vehicula ipsum a.Sit amet consectetur adipiscing elit duis.Urna nunc id cursus metus aliquam eleifend mi in nulla.Ultrices eros in cursus turpis massa tincidunt dui ut.Id volutpat lacus laoreet non.Quam viverra orci sagittis eu volutpat odio facilisis mauris sit.Et netus et malesuada fames ac turpis egestas." : "Lorem Ipsum Set",
                            CreationTime = new DateTime(2022, 01, 01),
                            Draft = false,
                            LastEditTime = new DateTime(2022, 01, 02),
                            OwnerId = 1,
                            PublishTime = new DateTime(2022, 02, 01),
                            Title = "Paroles de la chanson Lorem Ipsum",



                        },
                        new Story()
                        {
                            Id = 2,
                            Content =   "Lorem Ipsum Set2",
                            CreationTime = new DateTime(2022, 02, 01),
                            Draft = false,
                            LastEditTime = new DateTime(2022, 02, 02),
                            OwnerId = 1,
                            PublishTime = new DateTime(2022, 03, 01),
                            Title = "Paroles de la chanson Lorem Ipsum v2",



                        }

                        );
                    context.SaveChanges();
                }


                if (!context.Comments.Any())
                {
                    context.Comments.AddRange(
                     new Comment { Id = 1, Content = "First", DisplayName = "Julie", Email = "julie@pressemots.com", Hidden = false, Rating = 2.5m, StoryId = 1 /*…*/  },
                      new Comment { Id = 2, Content = "Second", DisplayName = "Fred", Email = "fred@pressemots.com", Hidden = false, Rating = 3m, StoryId = 1 /*…*/  },
                    new Comment { Id = 3, Content = "First", DisplayName = "Julie", Email = "julie@pressemots.com", Hidden = false, Rating = 2.5m, StoryId = 2 /*…*/  });
                    context.SaveChanges();
                }

                if (!context.Tags.Any()) {


                    context.Tags.AddRange(
                        new Tag() { Id = 1, Name = "Tag1" },
                        new Tag() { Id = 2, Name = "Tag2" },
                        new Tag() { Id = 3, Name = "Tag3" }
                        );
                    context.SaveChanges();
                }


                if (!context.StoryTags.Any()) {

                    context.StoryTags.AddRange(new StoryTag() { Id=1, StoryId=1, TagId=1});
                    context.SaveChanges();
                }


            }
        }



        [Fact]
        public void SearchByTagNameTest() {


            using (var context = new PresseMotsDbContext(SetUpInMemory("SearchByTagNameTest"))) {
                //arrange
                //j'ai du trouver l'interface de HtmlSanitizer en faisant un ctrl+clic. 
                var htmlSanitize = new Mock<IHtmlSanitizer>();
                var service = new StoryService(context, htmlSanitize.Object);

                //act
                var result = service.SearchByTagName("tag1");

                //assert
                Assert.Collection(result,x=>Assert.Equal(1,x.Id));
            
            }
        
        }

        [Fact]
        public void SearchByTagNameTest_NotFound()
        {


            using (var context = new PresseMotsDbContext(SetUpInMemory("SearchByTagNameTest")))
            {
                //arrange
                //j'ai du trouver l'interface de HtmlSanitizer en faisant un ctrl+clic. 
                var htmlSanitize = new Mock<IHtmlSanitizer>();
                var service = new StoryService(context, htmlSanitize.Object);

                //act
                var result = service.SearchByTagName("tag not in db");

                //assert
                Assert.Equal(0,result.Count);

            }

        }



        [Fact]
        public void CreateTest() {

         
         

            using (var context = new PresseMotsDbContext(SetUpInMemory("CreateTest")))
            {
                //arrange
                //j'ai du trouver l'interface de HtmlSanitizer en faisant un ctrl+clic. 
                var htmlSanitize = new Mock<IHtmlSanitizer>(); 
                var sanatizeReturn = "Html sanatized";
                htmlSanitize.Setup(x => x.Sanitize(It.IsAny<string>())).Returns(sanatizeReturn);
              
                var service = new StoryService(context, htmlSanitize.Object);

                var story = new Story()
                {
                    Id = 0,
                    Content = "Lorem Ipsum Set3",
                    CreationTime = new DateTime(2022, 02, 01),
                    Draft = false,
                    LastEditTime = new DateTime(2022, 02, 02),
                    OwnerId = 1,
                    PublishTime = new DateTime(2022, 03, 01),
                    Title = "Paroles de la chanson Lorem Ipsum v3",



                };


                var startDate = DateTime.Now;
                //act
                var result = service.Create(story);

                var finishDate = DateTime.Now;

                //assert
                Assert.Equal(3, result.Id);
                Assert.True(result.CreationTime > startDate);
                Assert.True(result.CreationTime < finishDate);
                Assert.Equal(sanatizeReturn, result.Content);
                Assert.True(result.Draft);
                Assert.Null(result.LastEditTime);
                Assert.Null(result.PublishTime);

            }


        }

        [Fact]
        public void EditTest() { 

            

            using (var context = new PresseMotsDbContext(SetUpInMemory("CreateTest")))
            {
                //arrange
                //j'ai du trouver l'interface de HtmlSanitizer en faisant un ctrl+clic. 
                var htmlSanitize = new Mock<IHtmlSanitizer>(); 
                var sanatizeReturn = "Html sanatized";
                htmlSanitize.Setup(x => x.Sanitize(It.IsAny<string>())).Returns(sanatizeReturn);
              
                var service = new StoryService(context, htmlSanitize.Object);

                var story = new Story()
                {
                    Id = 2,
                    Content = "Lorem Ipsum Set2 edited",
                    CreationTime = new DateTime(2022, 02, 01),
                    Draft = false,
                    LastEditTime = new DateTime(2022, 02, 02),
                    OwnerId = 1,
                    PublishTime = new DateTime(2022, 04, 01),
                    Title = "Paroles de la chanson Lorem Ipsum v2 edited",

                };


                var startDate = DateTime.Now;
                //act
                service.Edit(story);

                var finishDate = DateTime.Now;


                var result = context.Stories.Find(story.Id);


                //assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Id);
                Assert.True(result.LastEditTime > startDate);
                Assert.True(result.LastEditTime < finishDate);
                Assert.Equal(sanatizeReturn, result.Content);
                Assert.Equal(new DateTime(2022, 02, 01), result.CreationTime);
                Assert.Equal(new DateTime(2022, 04, 01), result.PublishTime);


            }






        }




    }
}
