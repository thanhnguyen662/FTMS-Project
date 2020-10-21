using FTMS.Models;
using FTMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace FTMS.Controllers
{
	public class ManageTraineesController : Controller
	{
		private ApplicationDbContext _context;
		public ManageTraineesController()
		{
			_context = new ApplicationDbContext();
		}

		public ActionResult Index()
		{
			var managetrainees = _context.ManageTrainees.Include(m => m.Course)
														.Include(m => m.Trainee)
														.ToList();
			return View(managetrainees);
		}

		[HttpGet]
		public ActionResult Create()
		{
			var viewModel = new TraineeCourseViewModel
			{
				Courses = _context.Courses.ToList(),
				Trainees = _context.Users.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(ManageTrainee manageTrainee)
		{
			var newTrainee = new ManageTrainee
			{
				TraineeId = manageTrainee.TraineeId,
				CourseId = manageTrainee.CourseId
			};

			_context.ManageTrainees.Add(newTrainee);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Delete(int id)
		{
			var traineeCourseInDb = _context.ManageTrainees.SingleOrDefault(c => c.Id == id);
			if (traineeCourseInDb == null)
			{
				return HttpNotFound();
			}
			_context.ManageTrainees.Remove(traineeCourseInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}