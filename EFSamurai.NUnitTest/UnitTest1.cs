using NUnit.Framework;
using EFSamurai.Data;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFSamurai.NUnitTest
{
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            using (var context = new SamuraiContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }


        [Test]
        public void Test_AddOneSamuraiTwice()
        {
            EfMethods.AddOneSamurai("Zelda");
            EfMethods.AddOneSamurai("Link"); 
            string[] result = EfMethods.GetAllSamuraiNames();
            CollectionAssert.AreEqual(new[] { "Zelda", "Link" }, result);

            Assert.Pass();

        }

        [Test]
        public void Test_AddOneSamuraiWithSecretIdentity()
        { var samurai = new Samurai()

            { Name = "Ganondorf Dragmire", 
                HairStyle = HairStyle.Western,};

            int samuraiId = EfMethods.AddOneSamurai(samurai);
            EfMethods.UpdateSamuraiSetSecretIdentity(samuraiId, "Ganon"); 

            Samurai actualSamurai = EfMethods.GetSamurai(samuraiId); 
            Assert.AreEqual("Ganondorf Dragmire", actualSamurai.Name); 
            Assert.AreEqual(HairStyle.Western, actualSamurai.HairStyle);
            Assert.AreEqual("Ganon", actualSamurai.SecretIdentity.RealName); }
    }
}