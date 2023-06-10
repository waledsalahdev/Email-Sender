using Email_Sender.Data;
using Email_Sender.Models;
using Email_Sender.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Email_Sender.Controllers
{
    public class EmailsRequestController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IMailservice _mailservice;

        public EmailsRequestController(AppDbContext context, IMailservice mailservice)
        {
            this._db = context;
            this._mailservice = mailservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //var MailsEeq = await _db.MailRequests.ToListAsync();
            var display = new CreateVM
            {
                dis = await _db.MailRequests.ToListAsync(),

            };


            return View(display);
        }
        [HttpPost]
        public async Task<IActionResult> Add(MailRequest mailRequest)

        {
            if (ModelState.IsValid)
            {
                await _db.AddAsync(new MailRequest
                {
                    Subject = mailRequest.Subject,
                    Message = mailRequest.Message,

                });
                await _db.SaveChangesAsync();
            }


            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Send(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public async Task<IActionResult> SendTo(SendMailVm model)
        {

            var mailfromDb = await _db.MailRequests.FindAsync(model.Id);
            MailReqVm mailReqVm = new MailReqVm
            {
                Subject = mailfromDb.Subject,
                Message = mailfromDb.Message,
            };

            if (mailfromDb == null)
            {
                return BadRequest(ModelState);
            }

            List<string> emailadress = new List<string>();
            var mailto = model.ToEmail.Split(',');
            foreach (var mail in mailto)
            {
                emailadress.Add(mail);
            }
         
                await _mailservice.SendEmailAsync(emailadress, mailReqVm.Subject, mailReqVm.Message);

            
        


            return Ok();
        }
    }
}
