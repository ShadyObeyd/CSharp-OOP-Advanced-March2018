// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Text;

    [TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void PerformSetsReturnsNothingIfNoSongsArePresent()
	    {
            IStage stage = new Stage();
            stage.AddSet(new Short("Set1"));
            Performer performer = new Performer("Ivan", 20);

            performer.AddInstrument(new Guitar());


            SetController setController = new SetController(stage);

            StringBuilder expectedResult = new StringBuilder();

            expectedResult.AppendLine("1. Set1:");
            expectedResult.AppendLine("-- Did not perform");

            string result = expectedResult.ToString().TrimEnd();

            Assert.That(setController.PerformSets(), Is.EqualTo(result));
		}

        [Test]
        public void InstrumentsWearDown()
        {
            IStage stage = new Stage();
        
            ISet set = new Short("Short");
        
            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));
        
            IPerformer performer = new Performer("Ivan", 20);

            performer.AddInstrument(new Guitar());
        
            set.AddSong(song);
            set.AddPerformer(performer);
        
            stage.AddSet(set);
        
            SetController setController = new SetController(stage);

            setController.PerformSets();

            int expectedResult = 40;

            Assert.That(performer.Instruments.First().Wear, Is.EqualTo(expectedResult));
        }
	}
}