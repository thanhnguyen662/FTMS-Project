using FTMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FTMS.ViewModels;
using Microsoft.AspNet.Identity;

namespace FTMS.Controllers
{
	public class ManageTrainersController : Controller
	{
		private ApplicationDbContext _context;
		public ManageTrainersController()
		{
			_context = new ApplicationDbContext();
		}

		public ActionResult Index()
		{
			var managetrainers = _context.ManageTrainers.Include(m => m.Topic)
														.Include(m => m.Trainer)
														.ToList();
			return View(managetrainers);
		}

		[HttpGet]
		public ActionResult Create()
		{
			var viewModel = new TrainerTopicViewModel
			{
				Topics = _context.Topics.ToList(),
				Trainers = _context.Users.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(ManageTrainer manageTrainer)
		{
			var newTrainer = new ManageTrainer
			{
				TrainerId = manageTrainer.TrainerId,
				TopicId = manageTrainer.TopicId
			};

			_context.ManageTrainers.Add(newTrainer);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Delete(int id)
		{
			var trainerTopicInDb = _context.ManageTrainers.SingleOrDefault(c => c.Id == id);
			if (trainerTopicInDb == null)
			{
				return HttpNotFound();
			}
			_context.ManageTrainers.Remove(trainerTopicInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}