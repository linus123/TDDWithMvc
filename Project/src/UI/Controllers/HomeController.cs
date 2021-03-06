﻿using System;
using System.Web.Mvc;
using UI.Helpers;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private IIndexModelRepository _indexModelRepository;

        public HomeController(
            IIndexModelRepository indexModelRepository)
        {
            _indexModelRepository = indexModelRepository;
        }

        public ViewResult Index()
        {
            var indexModel = new IndexModel();

            _indexModelRepository.HydrateIndexModel(indexModel);

            return View(indexModel);
        }

        [HttpPost]
        public ActionResult Index(
            IndexModel indexModel)
        {
            if (!ModelState.IsValid)
            {
                _indexModelRepository.HydrateIndexModel(indexModel);

                return View(indexModel);
            }

            _indexModelRepository.SaveIndexModel(indexModel);

            return RedirectToAction("OrderSaved");
        }

        public ViewResult OrderSaved()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }
    }
}

/* 002
 * using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var indexModel = new IndexModel();

            indexModel.MembershipOptions = GetMembershipOptionModels();

            return View(indexModel);
        }

        private MembershipOptionModel[] GetMembershipOptionModels()
        {
            var membershipOptionModels1 = new MembershipOptionModel[3];

            membershipOptionModels1[0] = new MembershipOptionModel { Id = 0, Name = "Highfaluting Membership 1 Year - $99" };
            membershipOptionModels1[1] = new MembershipOptionModel { Id = 1, Name = "Highfaluting Membership 2 Years - $198" };
            membershipOptionModels1[2] = new MembershipOptionModel { Id = 2, Name = "Highfaluting Membership 3 Year - $259" };
            return membershipOptionModels1;
        }

        public ViewResult About()
        {
            return View();
        }
    }
}
*/

/* 001
 * 
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var indexModel = new IndexModel();

            var membershipOptionModels1 = new MembershipOptionModel[3];

            membershipOptionModels1[0] = new MembershipOptionModel { Id = 0, Name = "Highfaluting Membership 1 Year - $99" };
            membershipOptionModels1[1] = new MembershipOptionModel { Id = 1, Name = "Highfaluting Membership 2 Years - $198" };
            membershipOptionModels1[2] = new MembershipOptionModel { Id = 2, Name = "Highfaluting Membership 3 Year - $259" };

            var membershipOptionModels = membershipOptionModels1;

            indexModel.MembershipOptions = membershipOptionModels;

            return View(indexModel);
        }

        public ViewResult About()
        {
            return View();
        }
    }
}
 * 
*/