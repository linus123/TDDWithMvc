using System.Web.Mvc;
using Core.Domain;
using Core.Services;
using Moq;
using NUnit.Framework;
using UI.Helpers;
using UI.Helpers.Mappers;
using UI.Models;

namespace UnitTests.UI.Helpers
{
    [TestFixture]
    public class IndexModelRepositoryTests
    {
        private Mock<IOrderRepository> _mockOrderRepository;
        private Mock<IIndexModelMapper> _mockIndexModelMapper;
        private Mock<ICreditCardListItemMapper> _mockCreditCardListItemMapper;
        private IndexModelRepository _indexModelRepository;

        [SetUp]
        public void Init()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockIndexModelMapper = new Mock<IIndexModelMapper>();
            _mockCreditCardListItemMapper = new Mock<ICreditCardListItemMapper>();

            _indexModelRepository = new IndexModelRepository(
                _mockOrderRepository.Object,
                _mockIndexModelMapper.Object,
                _mockCreditCardListItemMapper.Object);
        }

        [Test]
        public void HydrateIndexModelShouldSetTheCreditCardTypesAndMembershipOptions()
        {
            var indexModel = new IndexModel();

            var membershipOffers = new MembershipOffer[0];

            _mockOrderRepository.Setup(
                repos => repos.GetAllActiveMembershipOffers())
                .Returns(membershipOffers);

            var membershipOptionModels = new MembershipOptionModel[0];

            _mockIndexModelMapper.Setup(
                mapper => mapper.MapDomainToModels(
                    membershipOffers))
                .Returns(membershipOptionModels);

            var selectListItems = new SelectListItem[0];

            _mockCreditCardListItemMapper.Setup(
                mapper => mapper.MapCreditCardsToListItems(
                    It.IsAny<CreditCardType[]>()))
                .Returns(selectListItems);

            _indexModelRepository.HydrateIndexModel(
                indexModel);

            Assert.That(indexModel.MembershipOptions, Is.EqualTo(membershipOptionModels));
            Assert.That(indexModel.CreditCardTypes, Is.EqualTo(selectListItems));
        }

        [Test]
        public void SaveIndexModelShouldSaveNewOrder()
        {
            var indexModel = new IndexModel();
            var membershipOrder = new MembershipOrder();

            _mockIndexModelMapper.Setup(
                mapper => mapper.GetMembershipOrderForIndexModel(
                    indexModel,
                    _mockOrderRepository.Object))
                .Returns(membershipOrder);

            _indexModelRepository.SaveIndexModel(
                indexModel);

            _mockOrderRepository.Verify(
                repos => repos.SaveMembershipOrder(
                    membershipOrder));
        }
    }
}