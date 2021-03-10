using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;
using PhoneBook.ViewModels;

namespace PhoneBook.Controllers
{
    [Authorize]
    public class PhoneBookController : Controller
    {
        private IPhoneBookService service;
        private IStatusService statusService;
        private IUserService userService;
        private IMapper mapper;

        public PhoneBookController(IPhoneBookService service, IStatusService statusService, IUserService userService, IMapper mapper)
        {
            this.mapper = mapper;
            this.statusService = statusService;
            this.service = service;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var pageSize = 10;

            var records = await this.service.GetPageOfPhoneNumbers((page - 1) * pageSize, pageSize);

            var pageVM = new PageViewModel(await this.service.TotalPhoneNumbers(), page, pageSize);

            var viewModel = new IndexViewModel
            {
                PageViewModel = pageVM,
                PhoneNumbers = this.mapper.Map<IEnumerable<PhoneNumberViewModel>>(records)
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var statuses = await this.statusService.Statuses();
            ViewBag.Statuses = statuses.Select(s => s.StatusType);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhoneNumberViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var record = this.mapper.Map<PhoneNumber>(model);
                    var creatorId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                    record.Creator = await this.userService.GetById(creatorId);
                    record.Added = DateTime.Now;
                    record.Updated=DateTime.Now;
                    record.Status =
                        await this.statusService.Where(s => s.StatusType.Equals(model.Status)).SingleAsync();
                    record.Id = Guid.NewGuid();

                    await this.service.Create(record);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                return View();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var statuses = await this.statusService.Statuses();
            ViewBag.Statuses = statuses.Select(s => s.StatusType);
            
            return View(this.mapper.Map<PhoneNumberViewModel>(await this.service.GetById(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PhoneNumberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var record = this.mapper.Map<PhoneNumber>(model);
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                if (model.Id != userId)
                {
                    return RedirectToAction("Index");
                }

                await this.service.Update(record, userId);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            return View(this.mapper.Map<PhoneNumberViewModel>(await this.service.GetById(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(PhoneNumberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                if (model.Id != userId)
                {
                    return RedirectToAction("Index");
                }

                await this.service.Delete(model.Id, userId);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
