using Microsoft.EntityFrameworkCore;
using Moq;
using PresseMots_DataAccess.Context;
using PresseMots_DataModels.Entities;
using PresseMots_Utility;
using PresseMots_Web.Services;
using PresseMots_Web.Services.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseMots_WebTests
{
    public class CommentServiceTests
    {
        private DbContextOptions<PresseMotsDbContext> SetUpInMemory(string uniqueName)
        {
            var options = new DbContextOptionsBuilder<PresseMotsDbContext>().UseInMemoryDatabase(uniqueName).Options;
            SeedInMemoryStore(options);
            return options;
        }

        private void SeedInMemoryStore(DbContextOptions<PresseMotsDbContext> options)
        {
            using (var context = new PresseMotsDbContext(options))
            {
                if (!context.Comments.Any())
                {
                    context.Comments.AddRange(
                     new Comment { Id = 0, Content = "First", DisplayName="Julie", Email = "julie@pressemots.com", Hidden = false, Rating = 2.5m, StoryId=1 /*…*/  });
                    context.SaveChanges();
                }
            }
        }

        [Fact]
        public async Task DeleteAsyncPutHiddenToTrue() {
            using (var context = new PresseMotsDbContext(SetUpInMemory("DeleteAsyncPutHiddenToTrue"))) {

                //arrange
                var wordCounterMock = new Mock<WordCounter>();
                //Setup not needed. 
                //wordCounterMock.Setup(x=>x.Count(It.IsAny<string>())).Returns(0);
                //wordCounterMock.Setup(x => x.Count(It.IsAny<IWordCountable>())).Returns(1);

                ICommentService service = new CommentService(context, wordCounterMock.Object);

                //act
                await service.DeleteAsync(1);

                //assert 
                var comment = context.Comments.Find(1);
                Assert.NotNull(comment);
                Assert.True(comment?.Hidden);

            
            
            }
        
        
        }






    }
}
