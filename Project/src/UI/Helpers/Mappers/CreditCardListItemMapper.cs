using System.Collections.Generic;
using System.Web.Mvc;
using Core.Domain;

namespace UI.Helpers.Mappers
{
    public class CreditCardListItemMapper
    {
        public SelectListItem[] MapCreditCardsToListItems(
            CreditCardType[] creditCardsType)
        {
            var listItems = new List<SelectListItem>();

            var selectItemEntry = new SelectListItem() { Value = "", Text = "-- Select Item --", Selected = true };
            listItems.Add(selectItemEntry);

            foreach (var creditCard in creditCardsType)
            {
                var selectListItem = new SelectListItem() { Value = creditCard.Code, Text = creditCard.Name };
                listItems.Add(selectListItem);
            }

            return listItems.ToArray();
        }
    }
}