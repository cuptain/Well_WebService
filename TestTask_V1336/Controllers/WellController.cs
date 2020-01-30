using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestTask_V1336.Models;
using static TestTask_V1336.Models.Well;
using TestTask_V1336.Models.ViewModels;
using static TestTask_V1336.Models.WellCollection;
using System.Web.Mvc;

namespace TestTask_V1336.Controllers
{
    public class WellController : Controller
    {
        // GET api/wells
        [System.Web.Mvc.AcceptVerbs(HttpVerbs.Get)]
        public ActionResult WellList()
        {
            List<Well> wellCollection = Wells.OrderBy(w => w.Id).ToList();
            List<OperationTypeEnum> operTypes = new List<OperationTypeEnum>();
            foreach (OperationTypeEnum ot in Enum.GetValues(typeof(OperationTypeEnum)))
                operTypes.Add(ot);
            ViewBag.OperTypes = operTypes.AsEnumerable();
            ViewData["Wells"] = wellCollection;
            return View(new WellSearchModel());
        }

        [System.Web.Mvc.AcceptVerbs(HttpVerbs.Post)]
        public ActionResult WellList(WellSearchModel model)
        {
            List<Well> wellSearchResult = WellSearch(model);
            List<OperationTypeEnum> operTypes = new List<OperationTypeEnum>();
            foreach (OperationTypeEnum ot in Enum.GetValues(typeof(OperationTypeEnum)))
                operTypes.Add(ot);
            ViewBag.OperTypes = operTypes.AsEnumerable();
            ViewData["Wells"] = wellSearchResult;
            return View();
        }

        // GET api/wells/id
        public ActionResult WellDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Well well = Wells.Find(w => w.Id == id);
            if (well == null)
            {
                return HttpNotFound();
            }
            WellAllModel wellDetails = new WellAllModel()
            {
                ID = well.Id,
                Name = well.Name,
                Group = well.Group,
                Field = well.Field,
                Factory = well.Factory,
                ControllerID = well.ControllerId,
                OperTypes = well.OperationType
            };
            return View(wellDetails);
        }

        // POST api/wells
        public ActionResult WellCreate()
        {
            List<OperationTypeEnum> operTypes = new List<OperationTypeEnum>();
            foreach (OperationTypeEnum ot in Enum.GetValues(typeof(OperationTypeEnum)))
                operTypes.Add(ot);
            ViewBag.OperTypes = operTypes.AsEnumerable();
            return View();
        }

        // POST api/wells
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WellCreate(WellAllModel well)
        {
            List<OperationTypeEnum> operTypes = new List<OperationTypeEnum>();
            foreach (OperationTypeEnum ot in Enum.GetValues(typeof(OperationTypeEnum)))
                operTypes.Add(ot);
            ViewBag.OperTypes = operTypes.AsEnumerable();

            if (ModelState.IsValid)
            {
                if (well.Name == null || well.Name.Trim() == "")
                {
                    ModelState.AddModelError("Well", "Некорректно введено название скважины");
                    return View(well);
                }
                if (well.Group == null || well.Group.Trim() == "")
                {
                    ModelState.AddModelError("Well", "Некорректно введено название куста");
                    return View(well);
                }
                if (well.Field == null || well.Field.Trim() == "")
                {
                    ModelState.AddModelError("Well", "Некорректно введено название месторождения");
                    return View(well);
                }
                if (well.Factory == null || well.Factory.Trim() == "")
                {
                    ModelState.AddModelError("Well", "Некорректно введено название ЦДНГ");
                    return View(well);
                }
                if (well.ControllerID <= 0)
                {
                    ModelState.AddModelError("Well", "Некорректно введен ID контроллера");
                    return View(well);
                }
                if (well.OperTypes == 0)
                {
                    ModelState.AddModelError("Well", "Не выбран тип эксплуатации");
                    return View(well);
                }

                int ID;
                if (Wells.Count == 0)
                    ID = 1;
                else
                    ID = Wells.Max(w => w.Id) + 1;

                Well newWell = new Well()
                {
                    Id = ID,
                    Name = well.Name,
                    Group = well.Group,
                    Field = well.Field,
                    Factory = well.Factory,
                    ControllerId = well.ControllerID,
                    OperationType = well.OperTypes
                };
                Wells.Add(newWell);
                return RedirectToAction("WellList", "Well");
            }
            ModelState.AddModelError("Well", "Некорректно введены данные");
            return View(well);
        }

        // PUT api/values/5
        public ActionResult WellEdit(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Well well = Wells.Find(w => w.Id == id);
            if (well == null)
            {
                return HttpNotFound();
            }
            List<OperationTypeEnum> operTypes = new List<OperationTypeEnum>();
            foreach (OperationTypeEnum ot in Enum.GetValues(typeof(OperationTypeEnum)))
                operTypes.Add(ot);
            ViewBag.OperTypes = operTypes.AsEnumerable();
            WellAllModel wellEdit = new WellAllModel()
            {
                ID = well.Id,
                Name = well.Name,
                Group = well.Group,
                Field = well.Field,
                Factory = well.Factory,
                ControllerID = well.ControllerId,
                OperTypes = well.OperationType
            };
            return View(wellEdit);
        }

        // PUT api/values/5
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  WellEdit(WellAllModel well)
        {
            List<OperationTypeEnum> operTypes = new List<OperationTypeEnum>();
            foreach (OperationTypeEnum ot in Enum.GetValues(typeof(OperationTypeEnum)))
                operTypes.Add(ot);
            ViewBag.OperTypes = operTypes.AsEnumerable();

            if (ModelState.IsValid)
            {
                if (well.Name == null || well.Name.Trim() == "")
                {
                    ModelState.AddModelError("Well", "Некорректно введено название скважины");
                    return View(well);
                }
                if (well.Group == null || well.Group.Trim() == "")
                {
                    ModelState.AddModelError("Well", "Некорректно введено название куста");
                    return View(well);
                }
                if (well.Field == null || well.Field.Trim() == "")
                {
                    ModelState.AddModelError("Well", "Некорректно введено название месторождения");
                    return View(well);
                }
                if (well.Factory == null || well.Factory.Trim() == "")
                {
                    ModelState.AddModelError("Well", "Некорректно введено название ЦДНГ");
                    return View(well);
                }
                if (well.ControllerID <= 0)
                {
                    ModelState.AddModelError("Well", "Некорректно введен ID контроллера");
                    return View(well);
                }
                if (well.OperTypes == 0)
                {
                    ModelState.AddModelError("Well", "Не выбран тип эксплуатации");
                    return View(well);
                }

                foreach (Well upWell in Wells.Where(w => w.Id == well.ID))
                {
                    upWell.Name = well.Name;
                    upWell.Group = well.Group;
                    upWell.Field = well.Field;
                    upWell.Factory = well.Factory;
                    upWell.ControllerId = well.ControllerID;
                    upWell.OperationType = well.OperTypes;
                }
                return RedirectToAction("WellList", "Well");
            }
            ModelState.AddModelError("Well", "Некорректно введены данные");
            return View(well);
        }

        // DELETE api/wells/id
        public ActionResult WellDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Well well = Wells.Find((w => w.Id == id));
            if (well == null)
            {
                return HttpNotFound();
            }
            return View(well);
        }

        // DELETE api/wells/id
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("WellDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult WellDelete(int id)
        {
            Well well = Wells.Find((w => w.Id == id));
            Wells.Remove(well);
            return RedirectToAction("WellList", "Well");
        }

        public List<Well> WellSearch(WellSearchModel model)
        {

            if ((model.ID != null && model.ID != "") || (model.ControllerID != null 
                && model.ControllerID != "") || (model.OperTypes != 0))
            {
                var select = from wells in Wells select wells;
                if (model.ID != null && model.ID != "")
                {
                    select = from wells in @select
                             where wells.Id.ToString() == model.ID
                             select wells;
                }
                if (model.ControllerID != null && model.ControllerID != "")
                {
                    select = from wells in @select
                             where wells.ControllerId.ToString() == model.ControllerID
                             select wells;
                }
                if (model.OperTypes != 0)
                {
                    select = from wells in @select
                             where wells.OperationType == model.OperTypes
                             select wells;
                }
                List<Well> wellSearchResult = select.ToList();
                return wellSearchResult;
            }
            else
            {
                return Wells;
            }
        }
    }
}
