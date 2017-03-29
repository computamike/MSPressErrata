﻿using MSPress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSPress.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {

            DashboardModel m = new DashboardModel();
            m.Errata = new HighLight()
            {
                Glyph = "fa-comments",
                Colour = "panel-yellow",
                Title = "Errata",
                Count = 26,
                Details = "Errata"
            };

            m.FlaggedItems = new HighLight()
            {
                Glyph = "fa-flag",
                Colour = "panel-red",
                Count = 12,
                Title = "Flagged Items"

            };

            m.Users = new HighLight()
            {
                Glyph = "fa-user",
                Colour = "panel-green",
                Count = 12,
                Title = "Users"
            };

            m.Users = new HighLight()
            {
                Glyph = "fa-question",
                Colour = "panel-green",
                Count = 3,
                Title = "Questions"
            };




            return View(m);
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
