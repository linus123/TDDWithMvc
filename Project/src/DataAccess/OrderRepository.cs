using System;
using System.Collections.Generic;
using Core.Domain;
using Core.Services;
using WebMatrix.Data;

namespace DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        public const string InsertOrderQuery =
            @"INSERT INTO [MembershipOrder]
           ([FirstName]
           ,[LastName]
           ,[EmailAddress]
           ,[DateOfBirth]
           ,[CreditCardNumber]
           ,[CreditCardTypeCode]
           ,[MembershipOfferId]
           ,[DateCreated])
     VALUES
           (@0
           ,@1
           ,@2
           ,@3
           ,@4
           ,@5
           ,@6
           ,@7)

SELECT SCOPE_IDENTITY() AS [Id]
";

        public MembershipOffer[] GetAllActiveMembershipOffers()
        {
            var membershipOffers = new List<MembershipOffer>();

            RunDatabaseOperation(
                database =>
                    {
                        var membershipOfferDatas = database.Query("SELECT * FROM MembershipOffer");

                        foreach (var membershipOfferData in membershipOfferDatas)
                        {
                            var membershipOffer = new MembershipOffer();

                            membershipOffer.Id = membershipOfferData.Id;
                            membershipOffer.InternalName = membershipOfferData.InternalName;
                            membershipOffer.ExternalName = membershipOfferData.ExternalName;
                            membershipOffer.DiscountPrice = membershipOfferData.DiscountPrice;
                            membershipOffer.Price = membershipOfferData.Price;
                            membershipOffer.IsActive = membershipOfferData.IsActive;
                            membershipOffer.TermInMonths = membershipOfferData.TermInMonths;
                            membershipOffer.TermInYears = membershipOfferData.TermInYears;

                            membershipOffers.Add(membershipOffer);
                        }
                    });

            return membershipOffers.ToArray();
        }

        public int SaveMembershipOrder(MembershipOrder membershipOrder)
        {
            dynamic queryValue;

            RunDatabaseOperation(
                database =>
                {
                    queryValue = database.QuerySingle(InsertOrderQuery,
                                                        membershipOrder.FirstName,
                                                        membershipOrder.LastName,
                                                        membershipOrder.EmailAddress,
                                                        membershipOrder.DateOfBirth,
                                                        membershipOrder.CreditCardNumber,
                                                        membershipOrder.CreditCardType.Code,
                                                        membershipOrder.MembershipOffer.Id,
                                                        membershipOrder.DateCreated);

                    membershipOrder.OrderId = Convert.ToInt32(queryValue.Id);
                });


            return membershipOrder.OrderId;
        }

        public void RunDatabaseOperation(
            Action<Database> operationAction)
        {
            var database = Database.Open("IntegrationTests.Properties.Settings.TDDWithMVCConnectionString");

            try
            {
                operationAction(database);
            }
            finally
            {
                database.Close();
            }

            database.Close();
        }
    }
}